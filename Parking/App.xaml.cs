using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Parking.View;
using Parking.ViewModel;
namespace Parking {
    /// <summary>
    /// Logika interakcji dla klasy App.xaml
    /// </summary>
    public partial class App : Application {
        private VehiclesViewModel vvm;

        public App() {
            vvm = new VehiclesViewModel();
            VehiclesWindow vehicles = new VehiclesWindow { DataContext = vvm };
            vehicles.Show();
            vehicles.Closing += OnVehiclesClose;
        }

        public void OnVehiclesClose(object sender, EventArgs e) {
            vvm.Dispose();
        }
    }
}
