using OnlineShop.Models;
using OnlineShop.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Services
{
    internal class FollowService
    {
        public static void CreatFollow(Guid ProductID, Guid CustomerID, string Email)
        {
            FollowRepository.CreatFollow(ProductID, CustomerID, Email);
        }

     
    }
}
