using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Models
{
    public class ReturnModel
    {
        public Guid OrderId { get; set; }
        public string LogisticsID { get; set; }
        public string LogisticsSubType { get; set; }

        public int Price { get; set; }
        public int Qty { get; set; }
        public int Point { get; set; }
        public string ReturnTime { get; set; }
        public string GoodsName { get; set; }
        
       
    }
}
