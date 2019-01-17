using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Parking.ViewModel.Commands {
    public class AddVehicleCommand : ICommand {
        public event EventHandler CanExecuteChanged {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }

        private VehiclesViewModel vm;
        public AddVehicleCommand(VehiclesViewModel vm) {
            this.vm = vm;
        }

        public bool CanExecute(object parameter) {
            return vm.AddVehicleWindow == null || !vm.AddVehicleWindow.IsEnabled;
        }

        public void Execute(object parameter) {
            vm.AddVehicle();
        }
    }
}
