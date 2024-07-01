using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Models
{
    internal class InvoiceResponseModel
    {

        public int PlatformID { get; set; }
        public int MerchantID { get; set; }
        public Rpheader RpHeader { get; set; }
        public int TransCode { get; set; }
        public string TransMsg { get; set; }
        public string Data { get; set; }


    }

    public class Rpheader
    {
        public int Timestamp { get; set; }
        public string RqID { get; set; }
        public object Revision { get; set; }
    }

    public class ResponseDataModel
    {
        public int RtnCode { get; set; }
        public string RtnMsg { get; set; }
        public string InvoiceNo { get; set; }
        public string InvoiceDate { get; set; }
        public string RandomNumber { get; set; }
    }
}
