using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Parking.ViewModel.Commands {
    class SelectedVehicleCommand : ICommand {
        public event EventHandler CanExecuteChanged;
        private VehiclesViewModel vm;

        public SelectedVehicleCommand(VehiclesViewModel vm) {
            this.vm = vm;
        }

        public bool CanExecute(object parameter) {
            return true;
        }

        public void Execute(object parameter) {
            vm.VehicleVisit = vm.Visits.GetForVehicle(vm.SelectedVehicle.Id);
        }
    }
}
