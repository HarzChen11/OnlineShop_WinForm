using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Models.ReponseModel
{
    internal class AllowanceReponse
    {
        public string MerchantID { get; set; }
        public Rpheader RpHeader { get; set; }
        public int TransCode { get; set; }
        public string TransMsg { get; set; }
        public string Data { get; set; }
        public class Rpheader
        {
            public int Timestamp { get; set; }
        }

        public class AllowanceResponseData
        {
            public int RtnCode { get; set; }
            public string RtnMsg { get; set; }
            public string InvoiceNo { get; set; }
            public string InvoiceDate { get; set; }
            public string RandomNumber { get; set; }
        }
    }
}
