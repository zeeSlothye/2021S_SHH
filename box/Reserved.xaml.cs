using System.Collections.Generic;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;

namespace BoxStation.box
{
    public partial class Reserved : DialogPage
    {
        //최종적인 정보 확인.
        public Reserved()
        {
            InitializeComponent();
            /*
            Dictionary<string, Data.Boxes> boxDataSource = new Dictionary<string, Data.Boxes>();
            foreach (var item in AddBoxPage.)
            {
                boxDataSource.Add(item.BoxNumber, item);
            }
            */
            /*
            reservedStation.Text = Data.BoxDataSource.Source.
            reservedBoxNumb.Text =;
            reservedStuff.Text =;
            reservedPW.Text =;
            reservedTime.Text =;
            */
        }

        

        public void ShowPopup()
        {
            NUIApplication.GetDefaultWindow().GetDefaultNavigator().Push(this);
        }


        private bool reservePopup_TouchEvent(object source, View.TouchEventArgs e)
        {
            NUIApplication.GetDefaultWindow().GetDefaultNavigator().Pop();
            return true;
        }

        private bool goHome_TouchEvent(object source, TouchEventArgs e)
        {
            Navigator.Push(new NaviPage());
            return true;
        }
    }
}
