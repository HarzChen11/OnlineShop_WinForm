using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Models
{
    internal class FinalLogisticsModel
    {
        public string MerchantID { get; set; } = "2000132";
        public Rqheader RqHeader { get; set; } = new Rqheader();
        public string Data { get; set; }
        public class Rqheader
        {
            public string Timestamp { get; set; } = DateTimeOffset.Now.ToUnixTimeSeconds().ToString();
        }

        public class FinalLogisticsData
        {
            public string TempLogisticsID { get; set; }
            public string MerchantTradeNo { get; set; }
        }
    }

    
}
