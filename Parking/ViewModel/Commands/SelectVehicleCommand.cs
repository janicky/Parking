﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Parking.ViewModel.Commands {
    class SelectVehicleCommand : ICommand {
        public event EventHandler CanExecuteChanged;

        public SelectVehicleCommand(VehiclesViewModel vm) {
        }

        public bool CanExecute(object parameter) {
            throw new NotImplementedException();
        }

        public void Execute(object parameter) {
            throw new NotImplementedException();
        }
    }
}
