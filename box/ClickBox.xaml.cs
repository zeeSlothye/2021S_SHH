using System.Collections.Generic;
using System.Text.RegularExpressions;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;

namespace BoxStation.box
{
    public partial class ClickBox : ContentPage
    {

        //user가 입력한 비밀번호, 보관한 물건 정보를 입력받아 저장. 
        public ClickBox()
        {
   
            InitializeComponent();

        }

        Data.Boxes box;
        //Dictionary<string, string> boxForJson = new Dictionary<string, string>();
        Dictionary<string, string> parameters = new Dictionary<string, string>();
        public void ShowClickBoxPage(Dictionary<string, string> parameters)
        {
            //box = Data.BoxDataSource.boxDataSource[lockerIdx];
            this.parameters = parameters;
            NUIApplication.GetDefaultWindow().GetDefaultNavigator().Push(this);
        }
        
        private void back_Clicked(object sender, ClickedEventArgs e)
        {
            NUIApplication.GetDefaultWindow().GetDefaultNavigator().Pop();
        }

        private void startUse_Clicked(object sender, ClickedEventArgs e)
        {
            parameters.Add("title", stuff.Text);
            parameters.Add("info", info.Text);
            parameters.Add("password", enterPW.Text);
            parameters.Add("trusterId", Data.Resources.user.UserPhone);
            Reserve reserve = new Reserve();
            reserve.ShowPopup(parameters);

        }

        private bool enterPW_TouchEvent(object source, TouchEventArgs e)
        {
            SetPasswordOnlyDigit(enterPW);
            return true;
        }

        private void enterPW_MaxLengthReached(object sender, TextEditor.MaxLengthReachedEventArgs e)
        {
            
        }
        private void SetPasswordOnlyDigit(TextField field)
        {

            /*hide password 
             * PropertyMap passwordMap = new PropertyMap();
            passwordMap.Add(HiddenInputProperty.Mode, new PropertyValue((int)HiddenInputModeType.HideAll));
            passwordMap.Add(HiddenInputProperty.SubstituteCharacter, new PropertyValue(0x2022));
            field.HiddenInputSettings = passwordMap;*/

            InputMethod inputMethod = new InputMethod();
            inputMethod.PanelLayout = InputMethod.PanelLayoutType.Password;
            field.InputMethodSettings = inputMethod.OutputMap;

            field.TextChanged += (s, e) =>
            {
                string str = Regex.Replace(e.TextField.Text, @"[\D_]", "");
                e.TextField.Text = str;
            };
        }

        private void stuff_TextChanged(object sender, TextEditor.TextChangedEventArgs e)
        {
            //update
        }

        private void enterPW_TextChanged(object sender, TextField.TextChangedEventArgs e)
        {
        }
    }
}
