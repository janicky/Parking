using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Parking.ViewModel.Commands;
using Parking.ViewModel.Common;

namespace Parking.ViewModel {
    class VehicleFormViewModel : ViewModel, ICloseable {

        private string _title = "Formularz pojazdu";
        private string _id;
        private int _vehicleType = 0;

        private Action<string, int> OnSaveMethod;

        public event EventHandler<EventArgs> RequestClose;
        public ICommand CloseCommand { get; private set; }

        public SaveVehicleFormCommand SaveVehicleFormCommand { get; set; }

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

        public VehicleFormViewModel(Action<string, int> OnSaveMethod) {
            SaveVehicleFormCommand = new SaveVehicleFormCommand(this);
            this.OnSaveMethod = OnSaveMethod;
        }

        public void HandleSave() {
            RequestClose.Invoke(this, EventArgs.Empty);
            OnSaveMethod(Id, VehicleType + 1);
        }


    }

}
