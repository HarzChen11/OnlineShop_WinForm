using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Models
{
    public class PointModel
    {
        public int Point { get; set; }

        public string TradeName { get; set; }
        public string CreatDate { get; set; }

        public string ExpireDate { get; set; }

        public string Status { get; set; }
        public bool Used { get; set; }
    }
}
