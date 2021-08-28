using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoxStation.Data
{
    class Buses: INotifyPropertyChanged
    {
        //버스정류장/버스번호/목적지/예정시간/버스의 현재 위치
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public Buses(string bst, string bsn, string desti, string min, string loc)
        {
            BusStation = bst;
            BusNumber = bsn;
            Destination = desti;
            Minute = min;
            BusLocation = loc;
        }
        
        private string busStation;
        public string BusStation
        {
            get
            {
                return busStation;
;
    }
            set
            {
                busStation = value;
                OnPropertyChanged("BusStation");
            }
        }

        private string busNumber;
        public string BusNumber
        {
            get
            {
                return busNumber;
            }
            set
            {
                busNumber = value;
                OnPropertyChanged("BusNumber");
            }
        }

        private string destination;
        public string Destination
        {
            get
            {
                return destination;
            }
            set
            {
                destination = value;
                OnPropertyChanged("Destination");
            }
        }

        private string minute;
        public string Minute
        {
            get
            {
                return minute;
            }
            set
            {
                minute = value;
                OnPropertyChanged("Minute");
            }
        }

        private string busLocation;
        public string BusLocation
        {
            get
            {
                return busLocation;
            }
            set
            {
                busLocation = value;
                OnPropertyChanged("BusLocation");
            }
        }

    }
}
