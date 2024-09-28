using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Models.ECPay
{
    internal class InvalidModel
    {
        public string MerchantID { get; set; } = "2000132";
        public Rqheader RqHeader { get; set; } = new Rqheader();
        public string Data { get; set; }

        public class Rqheader
        {
            public int Timestamp { get; set; } = (int)DateTimeOffset.Now.ToUnixTimeSeconds();
        }
    }
    public class InvalidData
    {
        public string MerchantID { get; set; } = "2000132";
        public string InvoiceNo { get; set; }
        public string InvoiceDate { get; set; }
        public string Reason { get; set; }
    }
}
