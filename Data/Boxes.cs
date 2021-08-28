using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tizen.Applications;

namespace BoxStation.Data
{
    class Boxes: INotifyPropertyChanged 
    {
        //버스정류장/버스번호/열림여부/이용가능여부/보관물품/비밀번호/시작일

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public Boxes(string bst, string bxn, string isO, string isP, string stf, string pw, string date)
        {
            BusStation = bst;
            BoxNumber = bxn;
            IsOpen = isO;
            IsPaid = isP;
            Stuff = stf;
            PW = pw;
            StartDate = date;
        }

        private string busStation;
        public string BusStation
        {
            get
            {
                return "버스 정류장: "+ busStation;
            }
            set
            {
                busStation = value;
                OnPropertyChanged("BusStation");
            }
        }

        private string boxNumber;
        public string BoxNumber
        {
            get
            {
                return boxNumber;
            }
            set
            {
                boxNumber = value;
                OnPropertyChanged("BoxNumber");
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
        
        private string stuff;
        public string Stuff
        {
            get
            {
                return stuff;
            }
            set
            {
                stuff = value;
                OnPropertyChanged("Stuff");
            }
        }
        
        private string pw;
        public string PW
        {
            get
            {
                return pw;
            }
            set
            {
                pw = value;
                OnPropertyChanged("PW");
            }
        }
        
        private string startDate;
        public string StartDate
        {
            get
            {
                return startDate;
            }
            set
            {
                startDate = value;
                OnPropertyChanged("StartDate");
            }
        }


    }

}

