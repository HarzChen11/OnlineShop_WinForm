using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Models.ReponseModel
{
    internal class LogisticsResponse
    {
        public string MerchantID { get; set; }
        public Rpheader RpHeader { get; set; } = new Rpheader();
        public int TransCode { get; set; }
        public string TransMsg { get; set; }
        public string Data { get; set; }

        public class Rpheader
        {
            public string Timestamp { get; set; } =  DateTimeOffset.Now.ToUnixTimeSeconds().ToString();
        }

        public class LogisticsResponseData
        {
            public string RtnCode { get; set; }
            public string RtnMsg { get; set; }

            public string LogisticsID { get; set; }
        }

    }
}
