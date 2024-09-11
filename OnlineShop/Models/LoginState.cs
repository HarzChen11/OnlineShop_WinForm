using OnlineShop.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Models
{
<<<<<<< HEAD
    public class LoginState
=======
    internal class LoginState
>>>>>>> 8101e26593e1c25fcacf35b07ec8373dd546f8f2
    {
        public static string CustomerID { get; set; }

        public static string Name { get; set; }
        public static string Password { get; set; }

        public static string Phone { get; set; }
        public static string Address { get; set; }
        public static string City { get; set; }
        public static string Email { get; set; }
<<<<<<< HEAD

        
        public static void SetLoginState(Customer customer)
        {
            LoginState.CustomerID = customer.CustomerID.ToString();
            LoginState.Name = customer.Name;
            LoginState.Password = customer.Password;
            LoginState.Phone = customer.Phone;
            LoginState.Address = customer.Address;
            LoginState.City = customer.City;
            LoginState.Email = customer.Email;

=======
        
        public static void SetLoginState(Customer customer)
        {
            CustomerID = customer.CustomerID.ToString();
            customer.Name = Name;
            customer.Password = Password;
            customer.Phone = Phone;
            customer.Address = Address;
            customer.City = City;
            customer.Email = Email;
>>>>>>> 8101e26593e1c25fcacf35b07ec8373dd546f8f2
        }
    }
}
