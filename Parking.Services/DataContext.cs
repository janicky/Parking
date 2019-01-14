using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Parking.Model;

namespace Parking.Services {
    class DataContext {
        public ObservableCollection<Vehicle> vehicles;
        public ObservableCollection<Visit> visits;
        public ObservableCollection<Vehicle> payments;
    }
}
