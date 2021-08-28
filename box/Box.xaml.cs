using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;

namespace BoxStation.box
{
    public partial class Box : ContentPage
    {
        public Box()
        {
            InitializeComponent();
        }

        private void Button_Clicked_Add(object sender, ClickedEventArgs e)
        {
            Navigator.Push(new AddBoxPage());
        }

        private void Button_Clicked_Remove(object sender, ClickedEventArgs e)
        {
            Navigator.Push(new ReservedList());
        }
    }
}
