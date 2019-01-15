using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Parking.Model;

namespace Parking.ViewModel {
    
    class VehiclesViewModel : INotifyPropertyChanged {
        public event PropertyChangedEventHandler PropertyChanged;
        private ObservableCollection<Vehicle> vehicles;

        public VehiclesViewModel() {
            var newVehicles = new ObservableCollection<Vehicle>();
            newVehicles.Add(new Vehicle("XXX0001", Vehicle.Type.Car));
            VehiclesCollection = newVehicles;
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
