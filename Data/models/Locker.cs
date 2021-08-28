using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoxStation.Data.models
{
    public class Locker : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public Locker(string json)
        {
            JObject jObject = JObject.Parse(json);
            idx = (int)jObject["idx"];
            type = (string)jObject["type"];
            number = (string)jObject["number"];
            stationName = (string)jObject["stationName"];
            stationUUID = (string)jObject["stationUUID"];
            stationLocation = (string)jObject["stationLocation"];
        }
         public Locker(int idx, string type, string number, string stationName, string stationUUID, string stationLocation)
        {
            this.idx = idx;
            this.type = type;
            this.number = number;
            this.stationName = stationName;
            this.stationUUID = stationUUID;
            this.stationLocation = stationLocation;
        }

        private int idx;
        public int Idx
        {
            get
            {
                return idx;
            }
            set
            {
                idx = value;
                OnPropertyChanged("Idx");
            }
        }

        private string type;
        public string Type
        {
            get
            {
                return type;
            }
            set
            {
                type = value;
                OnPropertyChanged("Type");
            }
        }

        private string number;
        public string Number
        {
            get
            {
                return number;
            }
            set
            {
                number = value;
                OnPropertyChanged("Number");
            }
        }

        private string stationName;
        public string StationName
        {
            get
            {
                return stationName;
            }
            set
            {
                stationName = value;
                OnPropertyChanged("StationName");
            }
        }

        private string stationUUID;
        public string StationUUID
        {
            get
            {
                return stationUUID;
            }
            set
            {
                stationUUID = value;
                OnPropertyChanged("StationUUID");
            }
        }

        private string stationLocation;
        private int v1;
        private int v2;
        private string v3;
        private string v4;
        private string v5;

        public string StationLocation
        {
            get
            {
                return stationLocation;
            }
            set
            {
                stationLocation = value;
                OnPropertyChanged("StationLocation");
            }
        }

    }
    
}
