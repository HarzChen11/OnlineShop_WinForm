using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Models
{
<<<<<<< HEAD

    public class ProductModel
    {
        public Guid ProducId { get; set; }
        public Guid OrderDetailsID { get; set; }
=======
    public class ProductModel
    {
        public Guid Id { get; set; }
>>>>>>> 8101e26593e1c25fcacf35b07ec8373dd546f8f2
        public string name { get; set; }
        public int price { get; set; }
        public int count { get; set; }
        public string img { get; set; }
<<<<<<< HEAD
        public string OrderCreateday { get; set; }
        public int Discount { get; set; }
=======

       
>>>>>>> 8101e26593e1c25fcacf35b07ec8373dd546f8f2
    }
}
