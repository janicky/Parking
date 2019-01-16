using System;
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

    class VehiclesViewModel : ViewModel, ICloseable {

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
        public void AddVehicle() {
            VehicleFormViewModel vm = new VehicleFormViewModel(HandleAddVehicle, "Dodaj nowy pojazd", "Dodaj");
            AddVehicleWindow = new VehicleFormWindow { DataContext = vm };
            AddVehicleWindow.Show();
            AddVehicleWindow.Closing += OnAddWindowClose;
        }

        public void HandleAddVehicle(string id, int vehicleType) {
            Vehicle vehicle = Vehicles.Create(id, vehicleType);
            VehiclesCollection.Add(vehicle);
        }

        public void OnAddWindowClose(object sender, CancelEventArgs e) {
            AddVehicleWindow = null;
        }

        // Edit vehicle
        public void EditVehicle() {
            VehicleFormViewModel vm = new VehicleFormViewModel(HandleEditVehicle, string.Format("Edytuj pojazd - {0}", SelectedVehicle.Id), "Zapisz", SelectedVehicle);
            EditVehicleWindow = new VehicleFormWindow { DataContext = vm };
            EditVehicleWindow.Show();
            EditVehicleWindow.Closing += OnEditWindowClose;
        }

        public void HandleEditVehicle(string id, int vehicleType) {
            var item = VehiclesCollection.FirstOrDefault(i => i.Id == SelectedVehicle.Id);
            if (item != null) {
                item.VehicleType = vehicleType;
                Vehicles.Update(SelectedVehicle);
            }
            VehiclesCollection = new ObservableCollection<Vehicle>(VehiclesCollection);
        }

        public void OnEditWindowClose(object sender, CancelEventArgs e) {
            EditVehicleWindow = null;
        }

    }
}
