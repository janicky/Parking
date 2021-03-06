﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Parking.Model;
using Parking.ViewModel.Commands;
using Parking.ViewModel.Helpers;
using Parking.View;
using Parking.ViewModel.Common;

namespace Parking.ViewModel {

    public class VehiclesViewModel : ViewModel, ICloseable, IDisposable {

        // Fields
        private Vehicle _selectedVehicle;
        private bool _canStartVisit = false;
        private VehicleFormWindow _addVehicleWindow;
        private VehicleFormWindow _editVehicleWindow;

        // Details
        private VehicleDetails _vehicleDetails = new VehicleDetails();

        // Model
        public readonly Vehicles Vehicles = new Vehicles();
        public readonly Visits Visits = new Visits();
        public readonly Payments Payments = new Payments();

        // Commands
        public SelectVehicleCommand SelectVehicleCommand { get; set; }
        public StartVisitCommand StartVisitCommand { get; set; }
        public DeleteVehicleCommand DeleteVehicleCommand { get; set; }
        public AddVehicleCommand AddVehicleCommand { get; set; }
        public EditVehicleCommand EditVehicleCommand { get; set; }

        public EndVisitCommand EndVisitCommand { get; set; }

        private ObservableCollection<Vehicle> vehicles;

        public event EventHandler<EventArgs> RequestClose;
        public ICommand CloseCommand { get; private set; }

        public bool CanStartVisit {
            get => _canStartVisit;
            set { _canStartVisit = value; OnPropertyChanged("CanStartVisit"); OnPropertyChanged("CanEndVisit"); }
        }

        public bool CanEndVisit {
            get => !_canStartVisit && SelectedVehicle != null;
        }

        public Vehicle SelectedVehicle {
            get => _selectedVehicle;
            set { _selectedVehicle = value; OnPropertyChanged("SelectedVehicle"); }
        }

        public VehicleDetails VehicleDetails {
            get => _vehicleDetails;
            set { _vehicleDetails = value; OnPropertyChanged("VehicleDetails"); }
        }

        public VehicleFormWindow AddVehicleWindow {
            get => _addVehicleWindow;
            set { _addVehicleWindow = value; OnPropertyChanged("AddVehicleWindow"); }
        }

        public VehicleFormWindow EditVehicleWindow {
            get => _editVehicleWindow;
            set { _editVehicleWindow = value; OnPropertyChanged("EditVehicleWindow"); }
        }

        public VehiclesViewModel() {
            VehiclesCollection = new ObservableCollection<Vehicle>(Vehicles.All());
            SelectVehicleCommand = new SelectVehicleCommand(this);
            StartVisitCommand = new StartVisitCommand(this);
            EndVisitCommand = new EndVisitCommand(this);
            DeleteVehicleCommand = new DeleteVehicleCommand(this);
            AddVehicleCommand = new AddVehicleCommand(this);
            EditVehicleCommand = new EditVehicleCommand(this);
        }

        public ObservableCollection<Vehicle> VehiclesCollection {
            get => vehicles;
            set {
                //if (vehicles == value) return;
                vehicles = value;
                OnPropertyChanged("VehiclesCollection");
            }
        }

        // Command <=> ViewModel
        public Visit GetVisitForSelectedVehicle() {
            if (SelectedVehicle == null) {
                return null;
            }
            return Visits.GetForVehicle(SelectedVehicle.Id);
        }

        public void UpdateVehicleDetails(Visit visit) {
            bool unfinishedVisit = false;
            if (visit != null) {
                VehicleDetails.Update(visit);
                unfinishedVisit = !visit.Finished;
            }
            VehicleDetails.Visible = visit != null;
            CanStartVisit = !unfinishedVisit;
        }

        public void StartVisit() {
            Visit visit = Visits.Create(SelectedVehicle.Id);
            CanStartVisit = false;
            UpdateVehicleDetails(visit);
        }

        public void EndVisit(Visit visit) {
            Payment payment = Payments.Create(visit.GetPrice());
            visit.PaymentId = payment.Id;
            visit.Finish();
            VehicleDetails.Update(visit);
            CanStartVisit = true;
            Visits.Update(visit);
        }

        public void DeleteVehicle() {
            Vehicles.Delete(SelectedVehicle.Id);
            VehiclesCollection.Remove(SelectedVehicle);
            CanStartVisit = false;
        }

        // Add vehicle
        public void AddVehicle(bool test = false) {
            VehicleFormViewModel vm = new VehicleFormViewModel(HandleAddVehicle, "Dodaj nowy pojazd", "Dodaj");
            AddVehicleWindow = new VehicleFormWindow { DataContext = vm };
            if (!test) {
                AddVehicleWindow.Show();
                AddVehicleWindow.Closing += OnAddWindowClose;
            }
        }

        public void HandleAddVehicle(string plate, int vehicleType) {
            if (Vehicles.IsUnique(plate)) {
                Vehicle vehicle = Vehicles.Create(plate, vehicleType);
                VehiclesCollection.Add(vehicle);
            } else {
                MessageBox.Show("Pojazd o takim numerze rejestracyjnym już istnieje", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public void OnAddWindowClose(object sender, CancelEventArgs e) {
            AddVehicleWindow = null;
        }

        // Edit vehicle
        public void EditVehicle(bool test = false) {
            VehicleFormViewModel vm = new VehicleFormViewModel(HandleEditVehicle, string.Format("Edytuj pojazd - {0}", SelectedVehicle.Plate), "Zapisz", SelectedVehicle);
            EditVehicleWindow = new VehicleFormWindow { DataContext = vm };
            if (!test) {
                EditVehicleWindow.Show();
                EditVehicleWindow.Closing += OnEditWindowClose;
            }
        }

        public void HandleEditVehicle(string plate, int vehicleType) {
            if (Vehicles.IsUnique(plate, SelectedVehicle.Id)) {
                var item = VehiclesCollection.FirstOrDefault(i => i.Id == SelectedVehicle.Id);
                if (item != null) {
                    item.Plate = plate;
                    item.VehicleType = vehicleType;

                    Vehicles.Update(SelectedVehicle);
                }
                VehiclesCollection = new ObservableCollection<Vehicle>(VehiclesCollection);
            } else {
                MessageBox.Show("Pojazd o takim numerze rejestracyjnym już istnieje", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public void OnEditWindowClose(object sender, CancelEventArgs e) {
            EditVehicleWindow = null;
        }

        public void Dispose() {
            VehiclesCollection.Clear();
        }
    }
}
