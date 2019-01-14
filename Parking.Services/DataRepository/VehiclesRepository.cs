﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Parking.Model;
using SQLite;
using Microsoft.Data.Sqlite;

namespace Parking.Services {
    public partial class DataRepository {

        public IEnumerable<Vehicle> GetVehicles() {
            List<Vehicle> vehicles = new List<Vehicle>();
            SQLiteConnection conn = new SQLiteConnection(connectionString);
            return conn.Table<Vehicle>();

        }
    }
}
