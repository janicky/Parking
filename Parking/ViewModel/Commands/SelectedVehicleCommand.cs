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
            var visit = vm.Visits.GetForVehicle(vm.SelectedVehicle.Id);
            bool unfinishedVisit = false;
            if (visit != null) {
                vm.VehicleDetails.Update(visit);
                unfinishedVisit = !visit.Finished;
            }
            vm.VehicleDetails.Visible = visit != null;
            vm.CanStartVisit = !unfinishedVisit;
        }
    }
}
