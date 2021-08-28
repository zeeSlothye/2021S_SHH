using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;

namespace BoxStation.box
{
    public partial class ReservedListPopup : DialogPage
    {
        public ReservedListPopup()
        {
            InitializeComponent();
            reserveddStation.Text = "충남대학교";
            reserveddBoxNumb.Text ="1";
            reserveddStuff.Text ="ㅁㄴㅇㄹ";
            reserveddPW.Text ="1234";
            reserveddTime.Text ="5H50M";
            presentCost.Text ="29309";
        }

        public void ShowPopUpPage()
        {
            NUIApplication.GetDefaultWindow().GetDefaultNavigator().Push(this);
        }

        private bool goHome_TouchEvent(object source, TouchEventArgs e)
        {
            Navigator.Push(new NaviPage());
            return true;
        }

        private bool reservedListPopup_TouchEvent(object source, TouchEventArgs e)
        {
            NUIApplication.GetDefaultWindow().GetDefaultNavigator().Pop();
            return true;
        }
    }
}
