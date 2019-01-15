using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLitePCL;

namespace Parking.Services {
    public partial class DataRepository {
        private DataContext dataContext = new DataContext();
        private string connectionString;

        public DataRepository(string connectionString = "W:/C#/Parking/Parking.Services/database.db") {
            this.connectionString = connectionString;
            Batteries_V2.Init();
        }
    }
}
