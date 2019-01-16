using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parking.ViewModel {
    class VehicleFormViewModel : ViewModel {

        private string _title = "Formularz pojazdu";

        public string Title {
            get => _title;
            set { _title = value; OnPropertyChanged("Title"); }
        }

    }
}
