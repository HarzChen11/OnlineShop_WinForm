using OnlineShop.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Models
{
    internal class LoginState
    {
        public static string CustomerID { get; set; }

        public static string Name { get; set; }
        public static string Password { get; set; }

        public static string Phone { get; set; }
        public static string Address { get; set; }
        public static string City { get; set; }
        public static string Email { get; set; }
        
        public static void SetLoginState(Customer customer)
        {
            CustomerID = customer.CustomerID.ToString();
            customer.Name = Name;
            customer.Password = Password;
            customer.Phone = Phone;
            customer.Address = Address;
            customer.City = City;
            customer.Email = Email;
        }
    }
}
