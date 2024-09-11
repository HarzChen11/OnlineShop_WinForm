using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Models
{
    internal class OrderModel
    {
<<<<<<< HEAD
        private static Guid _orderID;

        public Guid CustomerID { get; set; }
        public static Guid OrderId { get { return _orderID; } set { _orderID = value; } }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string CreatTime { get; set; }
        public string Deliver { get; set; }
        public Guid DeliverID { get; set; }
        public string Address { get; set; }
        public int Total { get; set; }
        public List<ProductModel> Products { get; set; }

        public OrderModel(string Name, string phone, int Total)
        {
            this.Name = Name;
            this.Phone = phone;
            this.Total = Total;
        }

       


=======

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

      
>>>>>>> 8101e26593e1c25fcacf35b07ec8373dd546f8f2
    }
}
