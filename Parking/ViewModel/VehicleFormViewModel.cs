using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parking.ViewModel {
    class VehicleFormViewModel : ViewModel {

        private string _title = "Formularz pojazdu";
        private string _id;
        private int _vehicleType = 0;

        public string Title {
            get => _title;
            set { _title = value; OnPropertyChanged("Title"); }
        }

        public string Id {
            get => _id;
            set { _id = value; OnPropertyChanged("Id"); }
        }

        public int VehicleType {
            get => _vehicleType;
            set { _vehicleType = value; OnPropertyChanged("VehicleType"); }
        }
    }
}
