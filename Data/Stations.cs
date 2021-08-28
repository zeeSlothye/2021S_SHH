using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoxStation.Data 
{
    class Stations: INotifyPropertyChanged
    {
        //정류장이름/비콘정보/우산수/마스크수
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public Stations(string bst, string uuid, string umb, string msk)
        {
            BusStation = bst;
            UUID = uuid;
            Umbrella = umb;
            Mask = msk;

        }

        public string busStation;
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

        private string umbrella;
        public string Umbrella
        {
            get
            {
                return "남은 우산 수: " + umbrella;
            }
            set
            {
                umbrella = value;
                OnPropertyChanged("Umbrella");
            }
        }

        private string mask;
        public string Mask
        {
            get
            {
                return "남은 마스크 수: " + mask;
            }
            set
            {
                mask = value;
                OnPropertyChanged("Mask");
            }
        }

        private string uuid;
        public string UUID
        {
            get
            {
                return uuid;
            }
            set
            {
                uuid = value;
                OnPropertyChanged("UUID");
            }
        }

    }
}
