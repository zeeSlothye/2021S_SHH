using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;

namespace BoxStation
{
    public partial class Test : ContentPage
    {
        public Test(string str)
        {
            InitializeComponent();
            TestLabel.Text = str;

        }
    }
}
