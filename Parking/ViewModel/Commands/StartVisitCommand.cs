using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Parking.Model;

namespace Parking.ViewModel.Commands {
    class StartVisitCommand : ICommand {
        public event EventHandler CanExecuteChanged {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }

        private VehiclesViewModel vm;
        public StartVisitCommand(VehiclesViewModel vm) {
            this.vm = vm;
        }

        public bool CanExecute(object parameter) {
            return vm.CanStartVisit;
        }

        public void Execute(object parameter) {
            Visit visit = vm.Visits.Create(vm.SelectedVehicle.Id);
            vm.CanStartVisit = false;
            vm.UpdateVehicleDetails(visit);
        }
    }
}
