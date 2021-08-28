using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Binding;
using Tizen.NUI.Components;

namespace BoxStation.bus
{
    class CustomBus : RecyclerViewItem
    {
        private Button btn;
        private TextLabel busStationLabel;
        private TextLabel busNumberLabel;
        private TextLabel destinationLabel;
        private TextLabel minuteLabel;
        private TextLabel busLocationLabel;
        public CustomBus(Data.Buses bus, float temp)
        {
            //LG DISPLAY 1920 * 1080
            List<double> ratio = new List<double>();
            ratio.Add(Window.Instance.WindowSize.Width / 1920.0);
            ratio.Add(Window.Instance.WindowSize.Height / 1080.0);

            double minRatio = ratio.Min();
            float sizeW = Window.Instance.WindowSize.Width * 0.9f;
            float sizeH = Window.Instance.WindowSize.Height * temp;
            Size = new Size(sizeW, sizeH);


            btn = new Button()
            {
                //StyleName = "BusButton",
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.MatchParent,
                ParentOrigin = Tizen.NUI.ParentOrigin.Center,
                PivotPoint = Tizen.NUI.PivotPoint.Center,
                PositionUsesPivotPoint = true,
                BackgroundColor=Color.White,
                BackgroundImage="*Resource*/images/buxLine.png",
            };
            Add(btn);
            btn.Clicked += Btn_Clicked;
            



            Add(busStationLabel);
        //busStationLabel.SetBinding(TextLabel.TextProperty, bus.BusStation);

            busNumberLabel = new TextLabel()
            {
                PointSize = (float)Math.Round(minRatio * 100),
                ParentOrigin = Tizen.NUI.ParentOrigin.CenterLeft,
                PivotPoint = Tizen.NUI.PivotPoint.CenterLeft,
                Padding = new Extents(30,30,30,30),
                PositionUsesPivotPoint = true,
            };
            busNumberLabel.Text = bus.BusNumber;
            Add(busNumberLabel);
        //busNumberLabel.SetBinding(TextLabel.TextProperty, "BusNumber");

            destinationLabel = new TextLabel()
            {
                PointSize = (float)Math.Round(minRatio * 70),
                ParentOrigin = Tizen.NUI.ParentOrigin.BottomRight,
                PivotPoint = Tizen.NUI.PivotPoint.BottomRight,
                Padding = new Extents(30, 30, 30, 30),
                PositionUsesPivotPoint = true,
            };
            Add(destinationLabel);
            //destinationLabel.SetBinding(TextLabel.TextProperty, "Destination");
            destinationLabel.Text = bus.Destination;
            minuteLabel = new TextLabel()
            {
                PointSize = (float)Math.Round(minRatio * 100),
                ParentOrigin = Tizen.NUI.ParentOrigin.Center,
                PivotPoint = Tizen.NUI.PivotPoint.Center,
                Padding = new Extents(30, 30, 30, 30),
                PositionUsesPivotPoint = true,
            };
            Add(minuteLabel);
            //minuteLabel.SetBinding(TextLabel.TextProperty, "Minute");
            minuteLabel.Text = bus.Minute;
            busLocationLabel = new TextLabel()
            {
                PointSize = (float)Math.Round(minRatio * 70),
                ParentOrigin = Tizen.NUI.ParentOrigin.TopRight,
                PivotPoint = Tizen.NUI.PivotPoint.TopRight,
                Padding = new Extents(30, 30, 30, 30),
                PositionUsesPivotPoint = true,
            };
            Add(busLocationLabel);
            busLocationLabel.Text = bus.BusLocation;
            //busLocationLabel.SetBinding(TextLabel.TextProperty, "BusLocation");


        }
        private void Btn_Clicked(object sender, ClickedEventArgs e)
        {
            //승하차 알람 설정(먼 미래)
        }
    
    }
}
