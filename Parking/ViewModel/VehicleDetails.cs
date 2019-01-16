using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parking.ViewModel {
    class VehicleDetails : ViewModel {
        private bool _visible;
        private int _visitId;
        private string _visitStartDate;
        private string _visitEndDate;
        private string _visitDuration;
        private string _visitPrice;
        private bool _visitFinished;

        public bool Visible {
            get => _visible;
            set { _visible = value; OnPropertyChanged("Visible"); OnPropertyChanged("Hidden"); }
        }

        public bool Hidden {
            get => !_visible;
        }

        public int VisitId {
            get => _visitId;
            set { _visitId = value; OnPropertyChanged("VisitId"); }
        }

        public string VisitStartDate {
            get => _visitStartDate;
            set { _visitStartDate = value; OnPropertyChanged("VisitStartDate"); }
        }

        public string VisitEndDate {
            get => _visitEndDate;
            set { _visitEndDate = value; OnPropertyChanged("VisitEndDate"); }
        }

        public string VisitDuration {
            get => _visitDuration;
            set { _visitDuration = value; OnPropertyChanged("VisitDuration"); }
        }

        public string VisitPrice {
            get => _visitPrice;
            set { _visitPrice = value.ToString() + " PLN"; OnPropertyChanged("VisitPrice"); }
        }

        public bool VisitFinished {
            get => _visitFinished;
            set { _visitFinished = value; OnPropertyChanged("VisitFinished");  OnPropertyChanged("VisitFinishedString"); }
        }

        public string VisitFinishedString {
            get => (_visitFinished ? "Tak" : "Nie");
        }
    }
}
