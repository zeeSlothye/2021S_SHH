using System;
using System.Collections.Generic;
using BoxStation.Data.models;
using Newtonsoft.Json.Linq;


namespace BoxStation.Data
{
    public static class Resources
    {
        public static Users user = new Users("01012345678", "12345678", "0000", "True");
        //public static Dictionary<Locker, OccupiedLocker> lockerDIctS = new Dictionary<Locker, OccupiedLocker>();

        public static Dictionary<Locker, OccupiedLocker> lockerDIctS = new Dictionary<Locker, OccupiedLocker>()
        {
            { new Locker(1,"1","1","홈플러스 앞","1234123412341234","1234123412341234"), null}
            /*
            { new Locker(2,2,"홈플러스 앞","1234123412341234","1234123412341234"),},
            { new Locker(3, 3, "홈플러스 앞", "1234123412341234", "1234123412341234"),},
            { new Locker(4, 4, "홈플러스 앞", "1234123412341234", "1234123412341234")},
            */
        };
        
        /*
        public static (string userPh, string userPw, string condBc, string autoPayment)[] Users =
        {
            ("01012345678","12345678","0000","True"),
            ("01028375982","asdkjflkas","0001","True"),
            ("01081397598","29ur0re9ewt","0002","True"),
            ("01018232942","dg234gewe","0003","True"),
        };
        */

        
        //Stations
        public static (string bst, string uuid, string umb, string msk)[] Stations =
        {
            ("충남대학교 정류장","0000","10","5"),
            ("다솔아파트 정류장","0001","8","2"),
            ("황실타운아파트 정류장","0002","5","6"),
            ("누리아파트 정류장","0003","1","9"),
        };

        //Buses
        public static (string bst, string bsn, string desti, string min, string loc)[] Buses =
        {
            ("충남대학교 정류장","102","대전역","3분","유성온천역 7번출구"),
            ("충남대학교 정류장","106","비래동","1분","온천교"),
            ("충남대학교 정류장","113","서남부터미널","13분","주유소"),
            ("충남대학교 정류장","706","대한통운","1분","온천교"),
        };

        //Boxes
        public static (string bst, string bxn, string isO, string isP, string stf, string pw, string date)[] Boxes =
        {
            ("충남대학교 정류장","1","isOpen_true.PNG","false","과자","1234","2021.01.19-AM.5:30"),
            ("충남대학교 정류장","2","isOpen_false.PNG","false","사탕","4562","2021.01.09-AM.4:30"),
            ("충남대학교 정류장","3","isOpen_true.PNG","false","초코비","3462","2021.01.29-AM.5:20"),
            ("충남대학교 정류장","4","isOpen_true.PNG","false","아이패드","8098","2021.01.05-AM.5:59"),
        };



    }
}
