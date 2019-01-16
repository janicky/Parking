﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Parking.Model;
using Parking.ViewModel.Commands;
using Parking.ViewModel.Helpers;

namespace Parking.ViewModel {
    
    class VehiclesViewModel : ViewModel {

        // Fields
        private Vehicle _selectedVehicle;
        private bool _canStartVisit = false;

        // Details
        private VehicleDetails _vehicleDetails = new VehicleDetails();

        // Model
        public readonly Vehicles Vehicles = new Vehicles();
        public readonly Visits Visits = new Visits();

        // Commands
        public SelectVehicleCommand SelectVehicleCommand { get; set; }
        public StartVisitCommand StartVisitCommand { get; set; }

        public EndVisitCommand EndVisitCommand { get; set; }

        private ObservableCollection<Vehicle> vehicles;

        public bool CanStartVisit {
            get => _canStartVisit;
            set { _canStartVisit = value; OnPropertyChanged("CanStartVisit"); OnPropertyChanged("CanEndVisit"); }
        }
        public bool CanEndVisit {
            get => !_canStartVisit;
        }

        public Vehicle SelectedVehicle {
            get => _selectedVehicle;
            set { _selectedVehicle = value; OnPropertyChanged("SelectedVehicle"); }
        }

        public VehicleDetails VehicleDetails {
            get => _vehicleDetails;
            set { _vehicleDetails = value; OnPropertyChanged("VehicleDetails"); }
        }

        public VehiclesViewModel() {
            VehiclesCollection = new ObservableCollection<Vehicle>(Vehicles.All());
            SelectVehicleCommand = new SelectVehicleCommand(this);
            StartVisitCommand = new StartVisitCommand(this);
            EndVisitCommand = new EndVisitCommand(this);
        }

        public ObservableCollection<Vehicle> VehiclesCollection {
            get => vehicles;
            set {
                if (vehicles == value) return;
                vehicles = value;
                OnPropertyChanged("VehiclesCollection");
            }
        }

        // Command <=> ViewModel
        public Visit GetVisitForSelectedVehicle() {
            return Visits.GetForVehicle(SelectedVehicle.Id);
        }

        public void UpdateVehicleDetails(Visit visit) {
            bool unfinishedVisit = false;
            if (visit != null) {
                VehicleDetails.Update(visit);
                unfinishedVisit = !visit.Finished;
            }
            VehicleDetails.Visible = visit != null;
            CanStartVisit = !unfinishedVisit;
        }

    }
}
