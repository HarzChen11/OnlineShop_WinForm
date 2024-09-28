using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Models
{
    internal class TempLogisticsModel
    {
        public string MerchantID { get; set; } = "2000132";
        public Rqheader RqHeader { get; set; } = new Rqheader();
        public string Data { get; set; }

        public class Rqheader
        {
            public string Timestamp { get; set; } = DateTimeOffset.Now.ToUnixTimeSeconds().ToString();
        }

        internal class TempLogisticsDataModel
        {
            public string TempLogisticsID { get; set; }
            public int GoodsAmount { get; set; }
            public string IsCollection { get; set; } ="N";
            public string GoodsName { get; set; } ="雨傘線上公司產品";
            public string SenderName { get; set; } ="雨傘公司";
            public string SenderZipCode { get; set; } ="123";
            public string SenderAddress { get; set; } ="雨傘線上購物商城";
            public string Remark { get; set; } ="Enjoy";
            public string ServerReplyURL { get; set; } = "http://localhost:5031/api/Logistic/Create";
            public string ClientReplyURL { get; set; } = "http://localhost:5031/api/Logistic/Create";
            public string Temperature { get; set; } ="0001";
            public string Specification { get; set; } ="0001";
            public string ScheduledPickupTime { get; set; } ="1";
            public string ReceiverAddress { get; set; }
            public string ReceiverCellPhone { get; set; }
            //public string ReceiverPhone { get; set; }
            public string ReceiverName { get; set; }
            public string EnableSelectDeliveryTime { get; set; } ="N";
            public string EshopMemberID { get; set; } 
        }
    }
}
