using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Models
{
    internal class AllowanceModel
    {
        public string MerchantID { get; set; } = "2000132";
        public Rqheader RqHeader { get; set; } = new Rqheader();
        public string Data { get; set; }

        public class Rqheader
        {
            public int Timestamp { get; set; } = (int)DateTimeOffset.Now.ToUnixTimeSeconds();
        }

        public class AllowanceData
        {
            public int MerchantID { get; set; } = 2000132;
            public string InvoiceNo { get; set; }
            public string InvoiceDate { get; set; }
            public string AllowanceNotify { get; set; } = "E";
            public string CustomerName { get; set; }
            public string NotifyMail { get; set; }
            public int AllowanceAmount { get; set; }
            public AllowanceItem[] Items { get; set; }
            public string ReturnURL { get; set; } = "http://localhost:5031/swagger/index.html";

            public class AllowanceItem
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
}
