using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text.Json;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;

namespace BoxStation.box.reserve
{
    public partial class Submit : ContentPage
    {
        /*ContentPage, Home/box/reserve/Form/Submit
         *Form으로부터 OccupiedLocker를 받음. 
         *locker isOpen됨 -> 사용자가 물건을 넣음 -> 사용자가 문을 닫음 -> locker !isOpen됨. 
         *버튼- 예약확인: 사용자가 입력한 데이터및 예약확인을 눌렀을떄의 시간을 서버에 보냄. 
         */

        private Dictionary<string, string> parameters;
        public Submit(Dictionary<string, string> parameters)
        {
            InitializeComponent();
            this.parameters = parameters;
        }
        

        //버튼
        private bool startReserve_TouchEvent(object source, TouchEventArgs e)
        {
            Create_occupiedLocker("http://52.79.205.194:8000/locker/occupied/create", parameters);
            Complete complete = new Complete(parameters);
            NUIApplication.GetDefaultWindow().GetDefaultNavigator().Push(complete);
            return true;
        }

        //네비게이터
        public void ShowSubmitPage()
        {
            NUIApplication.GetDefaultWindow().GetDefaultNavigator().Push(this);
        }

        //서버로 데이터 전송
        // await Create_occupiedLocker("http://52.79.205.194:8000/locker/occupied/create", parameters);
        private async void Create_occupiedLocker(string uri, Dictionary<string, string> parameters)
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
        }
    }
}
