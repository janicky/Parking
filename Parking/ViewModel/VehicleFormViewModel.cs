using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Parking.ViewModel.Commands;
using Parking.ViewModel.Common;
using Parking.Model;
using System.ComponentModel;

namespace Parking.ViewModel {
    public class VehicleFormViewModel : ViewModel, ICloseable, IDataErrorInfo {

        private string _title = "Formularz pojazdu";
        private string _button = "Zapisz";
        private string _plate;
        private int _vehicleType = 0;

        private Action<string, int> OnSaveMethod;

        public event EventHandler<EventArgs> RequestClose;
        public ICommand CloseCommand { get; private set; }

        public SaveVehicleFormCommand SaveVehicleFormCommand { get; set; }

        public string Title {
            get => _title;
            set { _title = value; OnPropertyChanged("Title"); }
        }

        public string Button {
            get => _button;
            set { _button = value; OnPropertyChanged("Button"); }
        }

        public string Plate {
            get => _plate;
            set { _plate = value; OnPropertyChanged("Plate"); }
        }

        public int VehicleType {
            get => _vehicleType;
            set { _vehicleType = value; OnPropertyChanged("VehicleType"); }
        }

        public string Error => throw new NotImplementedException();

        public string this[string propertyName] {
            get {
                return OnValidate(propertyName);
            }
        }

        public VehicleFormViewModel(Action<string, int> OnSaveMethod, string title = "Formularz", string button = "Zapisz", Vehicle vehicle = null) {
            SaveVehicleFormCommand = new SaveVehicleFormCommand(this);
            this.OnSaveMethod = OnSaveMethod;
            Title = title;
            Button = button;

            if (vehicle != null) {
                Plate = vehicle.Plate;
                VehicleType = vehicle.VehicleType - 1;
            }
        }

        public void HandleSave() {
            try {
                if (string.IsNullOrEmpty(Plate) || Plate.Length > 15) {
                    throw new Exception("Nieprawidłowa tablica rejestracyjna.");
                }

                RequestClose.Invoke(this, EventArgs.Empty);
                OnSaveMethod(Plate, VehicleType + 1);
            } catch (Exception e) {
                MessageBox.Show(e.Message, "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        protected virtual string OnValidate(string propertyName) {
            string result = string.Empty;

            if (propertyName == "Plate") {
                if (string.IsNullOrEmpty(Plate)) {
                    result = "Tablica rejestracyjna jest wymagana";
                }
                if (Plate != null && Plate.Length > 15) {
                    result = "Tablica rejestracyjna jest zbyt długa";
                }
            }
            if (propertyName == "VehicleType") {
                if (VehicleType != 0 && VehicleType != 1) {
                    result = "Nieprawidłowy typ pojazdu";
                }
            }
            return result;
        }

    }

}
