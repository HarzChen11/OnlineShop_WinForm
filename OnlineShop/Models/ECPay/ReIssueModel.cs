using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Models.ECPay
{
    internal class ReIssueModel
    {
        public string MerchantID { get; set; } = "2000132";
        public Rqheader RqHeader { get; set; } = new Rqheader();
        public string Data { get; set; }

        public class Rqheader
        {
            public int Timestamp { get; set; } = (int)DateTimeOffset.Now.ToUnixTimeSeconds();
        }

        public class ReIssueDataModel
        {
            public string MerchantID { get; set; } = "2000132";
            public Voidmodel VoidModel { get; set; } 
            public Issuemodel IssueModel { get; set; }

            public class Voidmodel
            {
                public string InvoiceNo { get; set; }
                public string VoidReason { get; set; }
            }

            public class Issuemodel
            {
                public string RelateNumber { get; set; }
                public string InvoiceDate { get; set; }
                public string CustomerID { get; set; } = LoginState.CustomerID.ToString().Replace("-", "").Substring(0, 20);
                public string CustomerIdentifier { get; set; } = "";
                public string CustomerName { get; set; } = LoginState.Name;
                public string CustomerAddr { get; set; } = LoginState.Address;
                public string CustomerPhone { get; set; } = LoginState.Phone;
                public string CustomerEmail { get; set; } = "qqq@gmail.com.tw";
                public string ClearanceMark { get; set; } = "1";
                public string Print { get; set; } = "1";
                public string Donation { get; set; } = "0";
                public string CarrierType { get; set; } = "";
                public string CarrierNum { get; set; } = "";
                public string TaxType { get; set; } = "1";
                public int SalesAmount { get; set; }
                public string InvoiceRemark { get; set; }
                public string InvType { get; set; } = "07";
                public string vat { get; set; } = "1";
                public IssueItem[] Items { get; set; }

                public class IssueItem
                {
                    public int ItemSeq { get; set; }
                    public string ItemName { get; set; }
                    public int ItemCount { get; set; }
                    public string ItemWord { get; set; }
                    public int ItemPrice { get; set; }
                    public string ItemTaxType { get; set; }
                    public int ItemAmount { get; set; }
                    public string ItemRemark { get; set; }
                }
            }
        }


     

       
    }

}
