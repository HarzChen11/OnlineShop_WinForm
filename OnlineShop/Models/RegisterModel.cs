using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Models
{
    internal class RegisterModel
    {
        //public static string CustomerID { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }

        public string Phone { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Email { get; set; }

        public RegisterModel(string Name, string Password, string Phone, string Address, string City, string Email)
        {
            this.Name = Name;
            this.Password = Password;
            this.Phone = Phone;
            this.Address = Address;
            this.City = City;
            this.Email = Email;
        }
    }

  
}
