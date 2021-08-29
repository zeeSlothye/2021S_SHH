using System.Collections.Generic;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;

namespace BoxStation.box.reserve
{
    public partial class Complete : DialogPage
    {
        /*DialogPage, Home/box/reserve/Form/Submit/Complete
         *예약이 완료되었음을 알려줌. 
         *정류장/사물함번호/보관한물건/비밀번호/시작시간
         *버튼- 홈 화면으로: 처음 화면으로 감. 
         */
        private Dictionary<string, string> parameters;
        public Complete(Dictionary<string, string> parameters)
        {
            this.parameters = parameters;
            InitializeComponent();
            reservedStation.Text =parameters["stationName"];
            reservedBoxNumb.Text = parameters["lockerIdx"];
            reservedStuff.Text = parameters["title"];
            reservedPW.Text = parameters["password"];
            reservedTime.Text = parameters[""];
        }
        public void ShowPopup()
        {
            NUIApplication.GetDefaultWindow().GetDefaultNavigator().Push(this);
        }


        
        //버튼
        private bool goHome_TouchEvent(object source, TouchEventArgs e)
        {
            Navigator.Push(new NaviPage());
            return true;
        }
        private bool completePopup_TouchEvent(object source, TouchEventArgs e)
        {
            NUIApplication.GetDefaultWindow().GetDefaultNavigator().Pop();
            return true;
        }
    }
}
