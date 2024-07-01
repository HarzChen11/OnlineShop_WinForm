using OnlineShop.Models;
using OnlineShop.Models.Entities;
using OnlineShop.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace OnlineShop.Services
{
    internal class OrderService
    {
        public static void ServiceCreatOrder()
        {
            OrderRepository.CreatOrder(LoginState.CustomerID,CartService.getList());
        }
    }
}
