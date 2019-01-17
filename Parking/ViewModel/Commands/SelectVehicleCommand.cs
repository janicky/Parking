using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Parking.Model;

namespace Parking.ViewModel.Commands {
    public class SelectVehicleCommand : ICommand {
        public event EventHandler CanExecuteChanged;
        private VehiclesViewModel vm;

        public SelectVehicleCommand(VehiclesViewModel vm) {
            this.vm = vm;
        }

        public bool CanExecute(object parameter) {
            return true;
        }

        public void Execute(object parameter) {
            Visit visit = vm.GetVisitForSelectedVehicle();
            vm.UpdateVehicleDetails(visit);
        }
    }
}
