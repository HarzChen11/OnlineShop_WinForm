using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Models
{
    internal class ReturnGoodModel
    {
        public string MerchantID { get; set; } = "2000132";
        public Rqheader RqHeader { get; set; } = new Rqheader();
        public string Data { get; set; }

        public class Rqheader
        {
            public string Timestamp { get; set; } = DateTimeOffset.Now.ToUnixTimeSeconds().ToString();
        }

        public class ReturnGoodData
        {
            public string MerchantID { get; set; } = "2000132";
            public string LogisticsID { get; set; }
            public string ServerReplyURL { get; set; } = "http://localhost:5031/swagger/index.html";
            public string GoodsName { get; set; }
            public int GoodsAmount { get; set; }
            public string ServiceType { get; set; } = "4";
            public string SenderName { get; set; } = LoginState.Name;
            public string SenderPhone { get; set; } = LoginState.Phone;
        }

    }
}
