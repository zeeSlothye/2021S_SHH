using BoxStation.Data.models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Binding;
using Tizen.NUI.Components;
using System.Net;
using System.Text.Json;
using System.IO;

namespace BoxStation.box.reserve
{
    public partial class Form : ContentPage
    {
        /*ContentPage, Home/box/reserve/Form
         * 서버로부터 Locker을 받음. ->화면에 보여줘야 하는것 정류장 이름, 각 박스의 isOpen
         * 남은우산수 및 마스크는 어케 처리하지,,
         * 버튼
         *  취소: 해당화면 다시 로드(입력한 정보들 reset)
         *  예약하기: 사용자가 입력한 locker, titile, pw를 받아 다음 페이지로 전달. 
         */

        Dictionary<string, string> parameters = new Dictionary<string, string>();

        public Form()
        {
            InitializeComponent();


            //일단 비콘 UUID설정함. 
            string uuid = "123412341234"; //TODO 서버로부터 받아와야함. 

            //서버로부터, UUID에 따라 station정보 받아오기.

            //일단 그냥 station 정보들 받아옴. 
            Dictionary<string, Data.Stations> stationDataSource = new Dictionary<string, Data.Stations>();
            foreach (var item in Data.Resources.Stations)
            {
                //("충남대학교 정류장","0000","10","5"),
                stationDataSource.Add(item.uuid, new Data.Stations(item.bst, item.uuid, item.umb, item.msk));
            }

            //UUID에 따른 정류장 저장
            Data.Stations station = stationDataSource[uuid];

            //textlabel 설정
            stationName.Text = station.BusStation;
            remainUmbrella.Text = station.Umbrella;
            remainMask.Text = station.Mask;

            //서버로부터 정류장에 따른 locker받아오고, 이를 바탕으로 occupied matching 하기. 
            List<OccupiedLocker> occupiedLockerS = new List<OccupiedLocker>(); //null
            async void saveOccupiedLockerS()
            {
                occupiedLockerS = await temp_set_things();
            }
            
            saveOccupiedLockerS();

            //CollectionView를 통해 locker정보를 보여줌. 
            CollectionView boxContainerView = new CollectionView()
            {
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.MatchParent,
                ItemsSource = occupiedLockerS, //Get_occupiedLockerS의 return값. 
                ItemsLayouter = new GridLayouter(),
                ItemTemplate = new DataTemplate(() =>
                {
                    CustomBox customBox = new CustomBox();
                    selectedLockerIdx = customBox.selectedBoxIdx;
                    return new CustomBox();
                })
            };

            lockerContainer.Add(boxContainerView);
            
        }

        //변수
        private string selectedLockerIdx;

        //버튼클릭, startUse_Clicked로 정보 전달. 
        private void startUse_Clicked(object sender, ClickedEventArgs e)
        {
            parameters.Add("stationName", stationName.Text); //정류장 이름
            parameters.Add("lockerIdx", selectedLockerIdx); //locker번호 - CustomBox의 return값. 
            parameters.Add("title", stuff.Text); //보관한 물품
            parameters.Add("password", enterPW.Text); //비밀번호
            parameters.Add("trusterId", Data.Resources.user.UserPhone); //trusterId

            Submit submit = new Submit(parameters);
            submit.ShowSubmitPage();
        }

        private void cancel_Clicked(object sender, ClickedEventArgs e)
        {
            NUIApplication.GetDefaultWindow().GetDefaultNavigator().Pop();
        }

        //서버로부터 데이터 받아오는 함수들. 
        public async Task<List<OccupiedLocker>> temp_set_things()
        {
            //서버로부터 받아온 locker정보와 occupied정보를 matching함. 
            string lockerIdxS = "";
            foreach (Locker locker in new Data.Resources().lockerDIctS.Keys)
            {
                lockerIdxS += ("," + locker.Idx);
            }
            lockerIdxS = lockerIdxS.Substring(1);
            //Data.Resources.locker에 있는애들의 locker각 index만 뽑아서 list로 만들기. 


            parameters.Add("lockerIdxS", lockerIdxS);
            //정보 전달 완료 
            List<OccupiedLocker> occupiedLockerS = await Get_occupiedLockerS("http://52.79.205.194:8000/locker/occupied/get/lockerIdxS", parameters);

            return occupiedLockerS;


        }


        // await Get_occupiedLockerS("http://52.79.205.194:8000/locker/occupied/get/lockerIdxS", parameters);
        private async Task<List<OccupiedLocker>> Get_occupiedLockerS(string uri, Dictionary<string, string> parameters)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
            request.Method = "POST";
            request.ContentType = "application/json";
            request.Timeout = 30 * 1000;
            //request.Headers.Add("Authorization", "BASIC SGVsbG8=");
            // POST할 데이타를 Request Stream에 쓴다
            byte[] bytes = JsonSerializer.SerializeToUtf8Bytes(parameters);
            request.ContentLength = bytes.Length; // 바이트수 지정
            using (Stream reqStream = request.GetRequestStream())
            {
                reqStream.Write(bytes, 0, bytes.Length);
            }
            // Response 처리
            string responseText = string.Empty;
            using (WebResponse resp = request.GetResponse())
            {
                Stream respStream = resp.GetResponseStream();
                using (StreamReader sr = new StreamReader(respStream))
                {
                    responseText = sr.ReadToEnd();
                }
            }

            JArray temp_occupiedLockerS = JArray.Parse(responseText);

            List<OccupiedLocker> occupiedLockerS = new List<OccupiedLocker>();
            for (int i = 0; i < temp_occupiedLockerS.Count; i++)
            {
                occupiedLockerS.Add(temp_occupiedLockerS[i].ToObject<OccupiedLocker>());
            }

            return occupiedLockerS;
        }

        //사용자의 입력 설정
        private void stuff_TextChanged(object sender, TextEditor.TextChangedEventArgs e)
        {
            //유저로 입력받은값 전달. 
        }
        private bool enterPW_TouchEvent(object source, TouchEventArgs e)
        {
            SetPasswordOnlyDigit(enterPW); //4자리 숫자만 입력으로 받음. 
            return true;
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
        private void enterPW_MaxLengthReached(object sender, TextField.MaxLengthReachedEventArgs e)
        {
            //Nothing
        }

        

        

    }



    class CustomBox : RecyclerViewItem
    {
        private Button btn;
        private TextLabel label;
        public string selectedBoxIdx;
        //private string boxNumb;
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
            btn.Clicked += GetSelectedLockerNumber;


            //조건부 path
            btn.Icon.SetBinding(ImageView.ResourceUrlProperty, "IsOpen");
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
       
        private void GetSelectedLockerNumber(object sender, ClickedEventArgs e)
        {
            //버튼이 눌렸을떄, 박스번호를 저장함. 
            selectedBoxIdx=label.Text;
        }
    }
}
