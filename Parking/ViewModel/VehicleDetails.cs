using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parking.ViewModel {
    class VehicleDetails : ViewModel {
        private bool _visible;
        private int _visitId;
        private long _visitStartDate;
        private long _visitEndDate;
        private bool _visitFinished;

        public bool Visible {
            get => _visible;
            set { _visible = value; OnPropertyChanged("Visible"); }
        }

        public int VisitId {
            get => _visitId;
            set { _visitId = value; OnPropertyChanged("VisitId"); }
        }

        public long VisitStartDate {
            get => _visitStartDate;
            set { _visitStartDate = value; OnPropertyChanged("VisitStartDate"); }
        }

        public long VisitEndDate {
            get => _visitEndDate;
            set { _visitEndDate = value; OnPropertyChanged("VisitEndDate"); }
        }

        public bool VisitFinished {
            get => _visitFinished;
            set { _visitFinished = value; OnPropertyChanged("VisitFinished"); }
        }
    }
}
