using OnlineShop.Models;
using OnlineShop.Models.Entities;
using OnlineShop.Repository;
using OnlineShop.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Services
{
    internal class RegisterService
    {
        public static (Customer,string) CreatCustomer(RegisterModel registerModel)
        {
            Customer customer = RegisterRepository.CreatCustomer(registerModel);
            if (customer == null)
                return (null, null);
            string vaildPassword = SendNumberMail(customer);
            return (customer,vaildPassword);
        }

        private static string SendNumberMail(Customer customer)
        {
            Random random = new Random();
            string PassWord = random.Next(1000,9999).ToString();
            MailService.SendNumberMail(customer.Email.ToString(), PassWord);
            return PassWord;
        }

        public static bool ServiceAccountActivation(Guid CustomerID)
        {
            RegisterRepository.AccountActivation(CustomerID);
            return true;
        }
    }
}
