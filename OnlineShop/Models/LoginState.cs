using OnlineShop.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Models
{
    public class LoginState
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
            LoginState.CustomerID = customer.CustomerID.ToString();
            LoginState.Name = customer.Name;
            LoginState.Password = customer.Password;
            LoginState.Phone = customer.Phone;
            LoginState.Address = customer.Address;
            LoginState.City = customer.City;
            LoginState.Email = customer.Email;
        }
    }
}
