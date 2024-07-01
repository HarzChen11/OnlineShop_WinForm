using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Models
{
    internal class OrderModel
    {

        public string OrderId { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Deliver { get; set; }
        public string Address { get; set; }

        public OrderModel(string OrderId, string Name, string phone, string Deliver,string Address)
        {
            this.OrderId = OrderId;
            this.Name = Name;
            this.Phone = Phone;
            this.Deliver = Deliver;
            this.Address = Address;
        }

      
    }
}
