using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Models
{

    public class ProductModel
    {
        public Guid ProducId { get; set; }
        public Guid OrderDetailsID { get; set; }
        public string name { get; set; }
        public int price { get; set; }
        public int count { get; set; }
        public string img { get; set; }
        public string OrderCreateday { get; set; }
        public int Discount { get; set; }
    }
}
