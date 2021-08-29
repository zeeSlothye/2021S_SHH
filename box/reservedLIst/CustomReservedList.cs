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
    class CustomReservedList: RecyclerViewItem
    {
        private Button btn;
        private TextLabel stationLabel;
        private TextLabel boxNumberLabel;
        private TextLabel pWLabel;
        private TextLabel presentCostLabel;
        public CustomReservedList()
        {
            float sizeW = Window.Instance.WindowSize.Width * 0.9f;
            float sizeH = Window.Instance.WindowSize.Width * 0.1f;
            Size = new Size(sizeW, sizeH);

            //버튼(틀), 클릭시 detail info
            btn = new Button()
            {
                StyleName = "ReservedListButton",
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.MatchParent,
                ParentOrigin = Tizen.NUI.ParentOrigin.Center,
                PivotPoint = Tizen.NUI.PivotPoint.Center,
                PositionUsesPivotPoint = true,
                BackgroundColor = new Tizen.NUI.Color("#7474ff"),
            };
            
            btn.Clicked += Btn_Clicked;
            Add(btn);

            //StationName
            stationLabel = new TextLabel()
            {
                PointSize = 100,
                ParentOrigin = Tizen.NUI.ParentOrigin.CenterLeft,
                PivotPoint = Tizen.NUI.PivotPoint.CenterLeft,
                PositionUsesPivotPoint = true,
            };
            Add(stationLabel);
            //stationLabel.SetBinding(TextLabel.TextProperty, "StationName");
            stationLabel.Text = "충남대학교 정류장";

            //BoxNumber
            boxNumberLabel = new TextLabel()
            {
                PointSize = 100,
                ParentOrigin = Tizen.NUI.ParentOrigin.Center,
                PivotPoint = Tizen.NUI.PivotPoint.Center,
                PositionUsesPivotPoint = true,
            };
            Add(boxNumberLabel);
            boxNumberLabel.SetBinding(TextLabel.TextProperty, "BoxNumber");

            pWLabel = new TextLabel()
            {
                PointSize = 30,
                ParentOrigin = Tizen.NUI.ParentOrigin.BottomCenter,
                PivotPoint = Tizen.NUI.PivotPoint.BottomCenter,
                PositionUsesPivotPoint = true,
            };
            Add(pWLabel);
            //pWLabel.SetBinding(TextLabel.TextProperty, "PW");
            pWLabel.Text = "1234";


            //Cost
            presentCostLabel = new TextLabel()
            {
                PointSize = 100,
                ParentOrigin = Tizen.NUI.ParentOrigin.CenterRight,
                PivotPoint = Tizen.NUI.PivotPoint.CenterRight,
                PositionUsesPivotPoint = true,
            };
            Add(presentCostLabel);
            //reservedStuffLabel.SetBinding(TextLabel.TextProperty, "ReservedDate");
            presentCostLabel.Text = "2134123";

        }

        private void Btn_Clicked(object sender, ClickedEventArgs e)
        {
            ReservedListPopup reservedListPopup = new ReservedListPopup();
            reservedListPopup.BindingContext = this.BindingContext;
            reservedListPopup.ShowPopUpPage();
        }
    }
}
