using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text.Json;
using System.Threading.Tasks;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Binding;
using Tizen.NUI.Components;

namespace BoxStation.box
{
    public partial class Reserve : DialogPage
    {


        //이전화면에서 user가 "예약하기"를 누르면 다음 행동요령을 알려줌. 
        //사물함이 isOpen상태가 되고 -> user가 물건을 넣은 후 닫으면 -> !isOpen이 되고-> 이떄의 시간이 기록됨. 
        //user가 예약확인 누른 시간을 저장해야함. 
        public Reserve()
        {
            InitializeComponent();
        }

        Dictionary<string, string> parameters = new Dictionary<string, string>();

        public override bool IsCreateByXaml { get => base.IsCreateByXaml; set => base.IsCreateByXaml = value; }

        public void ShowPopup(Dictionary<string, string> parameters)
        {
            this.parameters = parameters;
            System.Console.WriteLine(parameters);
            NUIApplication.GetDefaultWindow().GetDefaultNavigator().Push(this);
        }

        private bool View_TouchEvent(object source, TouchEventArgs e)
        {
            NUIApplication.GetDefaultWindow().GetDefaultNavigator().Pop();
            return true;
        }

        private bool startReserve_TouchEvent(object source, TouchEventArgs e)
        {
            /*
            Dictionary<string, string> temp = new Dictionary<string, string>();
            temp.Add("lockerIdx", "1");
            temp.Add("title", "마스크");
            temp.Add("info", "");
            temp.Add("password", "qwer");
            temp.Add("trusterId", "abc");
            temp.Add("isPaid", "true");
            
            Ok
            */
            Create_occupiedLocker("http://52.79.205.194:8000/locker/occupied/create", parameters);
            Reserved reserved = new Reserved();
            NUIApplication.GetDefaultWindow().GetDefaultNavigator().Push(reserved);
            return true;
        }
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