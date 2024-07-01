using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Models
{
    internal class PrintInvoiceModel
    {
        public string MerchantID { get; set; } = "2000132";
        public Rqheader RqHeader { get; set; } = new Rqheader();
        public string Data { get; set; }
    }

    public class Rqheader
    {
        public int Timestamp { get; set; } = (int)DateTimeOffset.Now.ToUnixTimeSeconds();
    }


    public class PrintDataModel
    {
        public string MerchantID { get; set; } = "2000132";
        public string InvoiceNo { get; set; }
        public string InvoiceDate { get; set; }
        public int PrintStyle { get; set; } = 1;
        public int IsShowingDetail { get; set; } = 1;
    }

}
