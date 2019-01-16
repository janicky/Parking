using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Parking.Model;

namespace Parking.ViewModel.Commands {
    class AddVehicleCommand : ICommand {
        public event EventHandler CanExecuteChanged {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }

        private VehiclesViewModel vm;
        public AddVehicleCommand(VehiclesViewModel vm) {
            this.vm = vm;
        }

        public bool CanExecute(object parameter) {
            return !vm.AddVehicleWindow.IsEnabled;
        }

        public void Execute(object parameter) {
            // ...
        }
    }
}
