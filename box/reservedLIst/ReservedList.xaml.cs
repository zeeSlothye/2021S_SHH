﻿using System.Collections.Generic;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Binding;
using Tizen.NUI.Components;
using System.IO;
using System.Text.Json;
using System.Net;
using ReservedList.xaml.cs;


namespace BoxStation
{
    public partial class ReservedList : ContentPage
    {
        public ReservedList()
        {
            InitializeComponent();

            Dictionary<string, string> trusterIdDict = new Dictionary<string, string>();

            Create_occupiedLocker("http://52.79.205.194:8000/locker/occupied/get/trusterId",trusterIdDict);

            List<Data.Boxes> dataSource = new List<Data.Boxes>();
            foreach (var item in Data.Resources.Boxes)
            {
                dataSource.Add(new Data.Boxes(item.bst, item.bxn, item.isO, item.isP,item.stf,item.pw,item.date));
            }

            CollectionView reservedListContainerView = new CollectionView()
            {
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.MatchParent,
                Padding= new Extents(10, 100, 100, 10),
                ItemsSource = dataSource,
                ItemsLayouter = new LinearLayouter(),
                ItemTemplate = new DataTemplate(() =>
                {
                    return new box.CustomReservedList();
                }),

            };
            reservedList.Add(reservedListContainerView);

        }

        public async Task<List<OccupiedLocker>> temp_set_things()
        {
            //서버로부터 받아온 locker정보와 occupied정보를 matching함. 
            string usedRecordS = "";
            foreach (Locker record in new Data.Resources().lockerDIctS.Keys)
            {
                usedRecordS += ("," + locker.Idx);
            }
            usedRecordS = lockerIdxS.Substring(1);
            //Data.Resources.locker에 있는애들의 locker각 index만 뽑아서 list로 만들기. 


            parameters.Add("trusterId", usedRecordS);
            //정보 전달 완료 
            List<OccupiedLocker> occupiedLockerS = await Get_occupiedLockerS("http://52.79.205.194:8000/locker/occupied/get/trusterId", trusterIdDict);

            return occupiedLockerS;


        }

        // await Create_occupiedLocker("http://52.79.205.194:8000/locker/occupied/get/trusterId", parameters);
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

