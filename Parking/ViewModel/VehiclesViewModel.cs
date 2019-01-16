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

        public VehiclesViewModel() {
            VehiclesCollection = new ObservableCollection<Vehicle>(Vehicles.All());
            SelectVehicleCommand = new SelectVehicleCommand(this);
            StartVisitCommand = new StartVisitCommand(this);
            EndVisitCommand = new EndVisitCommand(this);
            DeleteVehicleCommand = new DeleteVehicleCommand(this);
            AddVehicleCommand = new AddVehicleCommand(this);
        }

        public ObservableCollection<Vehicle> VehiclesCollection {
            get => vehicles;
            set {
                if (vehicles == value) return;
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

        public void AddVehicle() {
            VehicleFormViewModel vm = new VehicleFormViewModel(HandleAddVehicle);
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
    }
}
