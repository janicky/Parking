using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Parking.Model;

namespace Parking.ViewModel.Commands {
    class DeleteVehicleCommand : ICommand {
        public event EventHandler CanExecuteChanged {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }

        private VehiclesViewModel vm;
        public DeleteVehicleCommand(VehiclesViewModel vm) {
            this.vm = vm;
        }

        public bool CanExecute(object parameter) {
            return vm.SelectedVehicle != null && vm.CanStartVisit;
        }

        public void Execute(object parameter) {
            MessageBoxResult result = MessageBox.Show("Czy aby na pewno chcesz usunąć ten pojazd?", "Potwierdzenie usunięcia", System.Windows.MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes) {
                vm.DeleteVehicle();
            }
        }
    }
}
