using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tizen.Applications;

namespace BoxStation.Data.models
{
    public class OccupiedLocker : INotifyPropertyChanged
    
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public OccupiedLocker(JObject jObject)
        {

            idx = (string)jObject["idx"];
            lockerIdx = (string)jObject["lockerIdx"];
            password = (string)jObject["password"];
            title = (string)jObject["title"];
            info = (string)jObject["info"];
            isOpen = (string)jObject["isOpen"];
            date = (string)jObject["date"];
            trusterId = (string)jObject["trusterId"];
            isPaid = (string)jObject["isPaid"];
        }
        public OccupiedLocker(string idx, string lockerIdx, string password, string title, string info, string isOpen, string date, string trusterId, string isPaid)
        {
            Idx = idx;
            LockerIdx = lockerIdx;
            Password = password;
            Title = title;
            Info = info;
            IsOpen = isOpen;
            Date = date;
            TrusterId = trusterId;
            IsPaid = isPaid;
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

        private string lockerIdx;
        public string LockerIdx
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
                if (isOpen=="true")
                {
                    return Application.Current.DirectoryInfo.Resource + "/images/isOpen/isOpen_true";
                }
                else
                {
                    return Application.Current.DirectoryInfo.Resource + "/images/isOpen/isOpen_false";
                }
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
