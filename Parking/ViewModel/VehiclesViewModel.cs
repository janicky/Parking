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
    
    class VehiclesViewModel : INotifyPropertyChanged {

        private readonly Vehicles Vehicles = new Vehicles();

        public event PropertyChangedEventHandler PropertyChanged;
        private ObservableCollection<Vehicle> vehicles;

        // Commands
        public ICommand SelectCommand;

        public VehiclesViewModel() {
            // Initialize commands
            SelectCommand = new SelectVehicleCommand();
            VehiclesCollection = new ObservableCollection<Vehicle>(Vehicles.All());
        }

        public ObservableCollection<Vehicle> VehiclesCollection {
            get => vehicles;
            set {
                if (vehicles == value) return;
                vehicles = value;
                OnPropertyChanged("VehiclesCollection");
            }
        }

        protected void OnPropertyChanged(string name) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("VehiclesCollection"));
        }
    }
}
