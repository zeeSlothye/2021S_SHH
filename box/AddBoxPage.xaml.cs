using BoxStation.Data.models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Binding;
using Tizen.NUI.Components;


namespace BoxStation.box
{
    public partial class AddBoxPage : ContentPage
    {
        Dictionary<string, string> parameters = new Dictionary<string, string>();

        public AddBoxPage()
        {
            InitializeComponent();
            
            //station 정보들 받아옴. 
            Dictionary<string, Data.Stations> stationDataSource = new Dictionary<string, Data.Stations>();
            foreach (var item in Data.Resources.Stations)
            {
                //("충남대학교 정류장","0000","10","5"),
                stationDataSource.Add(item.uuid, new Data.Stations(item.bst, item.uuid, item.umb, item.msk));
            }

            //UUID로 정류장 구분. ; uuid와 일치하는 정류장을 찾아서 저장함. 
            string uuid = "0000"; //TODO 서버로부터 받아와야함. 
            Data.Stations station = stationDataSource[uuid];

            //textlabel 설정
            stationName.Text = station.BusStation;
            remainUmbrella.Text = station.Umbrella;
            remainMask.Text = station.Mask;
            /*
            //Boxes에서 station.BusStation과 동일한 정보를 가진것만 뽑아서 dict에 추가. 
            List<Data.Boxes> boxesDataSource = new List<Data.Boxes>();
            foreach (var item in Data.Resources.Boxes)
            {
                if (item.bst == station.BusStation){
                    //("충남대학교 정류장","1","isOpen_true.PNG","false","과자","1234","2021.01.19-AM.5:30")
                    boxesDataSource.Add(new Data.Boxes(item.bst, item.bxn, item.isO, item.isP, item.stf, item.pw, item.date));
                }
            }
            

            //collectionView에 보여주기. 
           
            CollectionView boxContainerView = new CollectionView()
            {
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.MatchParent,
                ItemsSource = boxesDataSource,
                ItemsLayouter = new GridLayouter(),
                ItemTemplate = new DataTemplate(() =>
                {
                    return new CustomBox();
                }),
            };
            */
            temp_set_things();
            //boxInfo.Add(boxContainerView);

            //박스번호를 통해 박스 구분하도록 dict만듦. 
            //Data.BoxDataSource box = new Data.BoxDataSource();
            //box.BoxDict(boxesDataSource);
        }
        public async void temp_set_things()
        {
            string lockerIdxS = "";
            foreach(Locker locker in Data.Resources.lockerDIctS.Keys)
            {
                lockerIdxS += (","+ locker.Idx);
            }
            lockerIdxS = lockerIdxS.Substring(1);
            //Data.Resources.locker에 있는애들의 locker각 index만 뽑아서 list로 만들기. 
           
                
            parameters.Add("lockerIdxS", lockerIdxS);
            var occupiedLockerS = Get_occupiedLockerS("http://52.79.205.194:8000/locker/occupied/get", parameters);
            Task.WaitAll(occupiedLockerS);
            CollectionView boxContainerView = new CollectionView()
            {
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.MatchParent,
                ItemsSource = await occupiedLockerS,
                ItemsLayouter = new GridLayouter(),
                ItemTemplate = new DataTemplate(() =>
                {
                    return new CustomBox();
                }),
            };
        }
        

        private async Task<List<OccupiedLocker>> Get_occupiedLockerS(string uri, Dictionary<string, string> parameters)
        {
            //Json => model
            //https://stackoverflow.com/questions/2246694/how-to-convert-json-object-to-custom-c-sharp-object


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


            
            List<OccupiedLocker> lockerS = new List<OccupiedLocker>();



            JArray lockerJsonS = JArray.Parse(responseText);
            foreach (Locker locker in Data.Resources.lockerDIctS.Keys)
            {
                foreach(string lockerJson in lockerJsonS)
                {
                    OccupiedLocker occupiedLocker = JObject.Parse(lockerJson).ToObject<OccupiedLocker>();

                    if (locker.Idx == occupiedLocker.LockerIdx)
                    {
                        Data.Resources.lockerDIctS[locker] = occupiedLocker;
                        break;
                    } else
                    {
                        Data.Resources.lockerDIctS[locker] = null;
                    }
                }
            }





            return lockerS;
        }
        


    }
}
