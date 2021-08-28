using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;

namespace BoxStation.mypage
{
    public partial class MyPage : ContentPage
    {
        public MyPage()
        {
            InitializeComponent();
            userPN.Text = Data.Resources.user.UserPhone;
        }
        
    }
}
