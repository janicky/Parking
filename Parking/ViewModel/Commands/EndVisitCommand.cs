using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Parking.Model;

namespace Parking.ViewModel.Commands {
    class EndVisitCommand : ICommand {
        public event EventHandler CanExecuteChanged {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }

        private VehiclesViewModel vm;
        public EndVisitCommand(VehiclesViewModel vm) {
            this.vm = vm;
        }

        public bool CanExecute(object parameter) {
            return vm.CanEndVisit;
        }

        public void Execute(object parameter) {

            MessageBox.Show("Płatność została zapisana jako uregulowana.", "Koniec postoju");
        }
    }
}
