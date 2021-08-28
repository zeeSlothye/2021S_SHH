using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoxStation.Data.models
{
    public class OccupiedLocker : INotifyPropertyChanged
    
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public OccupiedLocker(string json)
        {
            JObject jObject = JObject.Parse(json);

            idx = (string)jObject["idx"];
            lockerIdx = (int)jObject["lockerIdx"];
            password = (string)jObject["password"];
            title = (string)jObject["title"];
            info = (string)jObject["info"];
            isOpen = (string)jObject["isOpen"];
            date = (string)jObject["date"];
            trusterId = (string)jObject["trustId"];
            isPaid = (string)jObject["isPaid"];
        }
        public OccupiedLocker(string idx, int lockerIdx, string password, string title, string info, string isOpen, string date, string trusterId, string isPaid)
        {
            this.idx = idx;
            this.lockerIdx = lockerIdx;
            this.password = password;
            this.title = title;
            this.info = info;
            this.isOpen = isOpen;
            this.date = date;
            this.trusterId = trusterId;
            this.isPaid = isPaid;
        }
        private string idx;
        public string Idx
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

        private int lockerIdx;
        public int LockerIdx
        {
            get
            {
                return lockerIdx;
            }
            set
            {
                lockerIdx = value;
                OnPropertyChanged("LockerIdx");
            }
        }
        
        private string password;
        public string Password
        {
            get
            {
                return password;
            }
            set
            {
                password = value;
                OnPropertyChanged("Password");
            }
        }

        private string title;
        public string Title
        {
            get
            {
                return title;
            }
            set
            {
                title = value;
                OnPropertyChanged("Title");
            }
        }
        
        private string info;
        public string Info
        {
            get
            {
                return info;
            }
            set
            {
                info = value;
                OnPropertyChanged("Info");
            }
        }

        private string isOpen;
        public string IsOpen
        {
            get
            {
                return isOpen;
            }
            set
            {
                isOpen = value;
                OnPropertyChanged("IsOpen");
            }
        }
        
        private string date;
        public string Date
        {
            get
            {
                return date;
            }
            set
            {
                date = value;
                OnPropertyChanged("Date");
            }
        }

        private string trusterId;
        public string TrusterId
        {
            get
            {
                return trusterId;
            }
            set
            {
                trusterId = value;
                OnPropertyChanged("TrusterId");
            }
        }
        
        private string isPaid;
        public string IsPaid
        {
            get
            {
                return isPaid;
            }
            set
            {
                isPaid = value;
                OnPropertyChanged("IsPaid");
            }
        }
    }
}
