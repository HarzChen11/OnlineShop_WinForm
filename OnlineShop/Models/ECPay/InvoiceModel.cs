using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Models
{

    internal class InvoiceModel
    {

        public string MerchantID { get; set; } = "2000132";
        public Rqheader RqHeader { get; set; } = new Rqheader();
        public string Data { get; set; }

        public class Rqheader
        {
            public int Timestamp { get; set; } = (int)DateTimeOffset.Now.ToUnixTimeSeconds();
        }

    }


    internal class InvoiceDataModel
    {

        public string MerchantID { get; set; }
        public string RelateNumber { get; set; }
        public string CustomerName { get; set; } = LoginState.Name;

        public string CustomerAddr { get; set; } = LoginState.Address;
        public string CustomerPhone { get; set; }
        public string Print { get; set; } = "1";
        public string TaxType { get; set; }
        public int SalesAmount { get; set; }
        public string InvType { get; set; }
        public string Vat { get; set; }
        public List<Item> Items { get; set; }

        public class Item
        {
            public int ItemSeq { get; set; }
            public string ItemName { get; set; }
            public int ItemCount { get; set; }
            public string ItemWord { get; set; }
            public int ItemPrice { get; set; }
            public string ItemTaxType { get; set; }
            public int ItemAmount { get; set; }
        }
    }
}
