using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Models
{
    public class BoughtOrderModel
    {

        public string OrderID { get; set; }
        public string OrderNumber { get; set; }
        public string InvoiceNo { get; set; }
        public string CreatTime { get; set; }
        public int Discount { get; set; }
        public List<ProductModel> Details { get; set; }

        public BoughtOrderModel()
        {
            Details = new List<ProductModel>();
        }
    }
}
