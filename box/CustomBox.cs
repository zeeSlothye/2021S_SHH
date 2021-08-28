using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Binding;
using Tizen.NUI.Components;

namespace BoxStation.box
{
    class CustomBox : RecyclerViewItem
    {
        private Button btn;
        private TextLabel label;
        private string boxNumb;
        public CustomBox()
        {
            float sizeW = Window.Instance.WindowSize.Width * 0.3f;
            Size = new Size(sizeW, sizeW);

            btn = new Button()
            {
                StyleName = "BoxButton",
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.MatchParent,
                ParentOrigin = Tizen.NUI.ParentOrigin.Center,
                PivotPoint = Tizen.NUI.PivotPoint.Center,
                PositionUsesPivotPoint = true,
            };
            btn.Icon.WidthSpecification = (int)(sizeW * 0.65f);
            btn.Icon.HeightSpecification = (int)(sizeW * 0.65f);


            //조건부 path
            btn.Icon.SetBinding(ImageView.ResourceUrlProperty, "IsOpen");
            btn.Clicked += Btn_Clicked;
            Add(btn);


            label = new TextLabel()
            {
                PointSize = 70,
                ParentOrigin = Tizen.NUI.ParentOrigin.BottomCenter,
                PivotPoint = Tizen.NUI.PivotPoint.BottomCenter,
                PositionUsesPivotPoint = true,
            };
            Add(label);

            label.SetBinding(TextLabel.TextProperty, "BoxNumber");


        }
        private void Btn_Clicked(object sender, ClickedEventArgs e)
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            ClickBox clickbox = new ClickBox();
            parameters.Add("lockerIdx", label.Text);
            clickbox.ShowClickBoxPage(parameters);
            //AddBoxPage의 init에 의해 Data.BoxDataSource.Source에 해당 정류장에 있는 box들 정보가 저장됨.
            //Data.BoxDataSource.Source에서 사용자가 클릭한 박스를 불러옴. 
            //해당 정보를 Reserve, Reserved, ReservedList, ReservedListPopup에 전달함. 
        }
    }
}
