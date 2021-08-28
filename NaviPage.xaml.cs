using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;

namespace BoxStation
{
    public partial class NaviPage : ContentPage
    {
        public NaviPage()
        {
            InitializeComponent();
        }

        private void Button_Clicked_Box(object sender, Tizen.NUI.Components.ClickedEventArgs e)
        {
            Navigator.Push(new box.Box());
        }

        private void Button_Clicked_Bus(object sender, Tizen.NUI.Components.ClickedEventArgs e)
        {
            Navigator.Push(new bus.Bus());
        }

        private void Button_Clicked_Mypage(object sender, Tizen.NUI.Components.ClickedEventArgs e)
        {
            Navigator.Push(new mypage.MyPage());
        }
    }
}
