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

namespace Parking.ViewModel {
    
    class VehiclesViewModel : ViewModel {

        // Fields
        private Vehicle _selectedVehicle;

        // Details
        private Visit _visit;

        // Model
        private readonly Vehicles Vehicles = new Vehicles();

        // Commands
        public SelectedVehicleCommand SelectedVehicleCommand { get; set; }

        private ObservableCollection<Vehicle> vehicles;

        public Vehicle SelectedVehicle {
            get => _selectedVehicle;
            set { _selectedVehicle = value; OnPropertyChanged("SelectedVehicle"); }
        }

        public Visit VehicleVisit {
            get => _visit;
            set { _visit = value; OnPropertyChanged("Visit"); }
        }

        public VehiclesViewModel() {
            VehiclesCollection = new ObservableCollection<Vehicle>(Vehicles.All());
            SelectedVehicleCommand = new SelectedVehicleCommand(this);
        }

        public ObservableCollection<Vehicle> VehiclesCollection {
            get => vehicles;
            set {
                if (vehicles == value) return;
                vehicles = value;
                OnPropertyChanged("VehiclesCollection");
            }
        }

    }
}
