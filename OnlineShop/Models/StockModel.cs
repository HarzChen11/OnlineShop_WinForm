using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Models
{
    internal class StockModel
    {
        public Guid StockID { get; set; }
        public Guid ProductID { get; set; }
        public int ProductQuantity { get; set; }
        public int ProductSafeQuantity { get; set; }
        public string ProductName { get; set; }
    }
}
