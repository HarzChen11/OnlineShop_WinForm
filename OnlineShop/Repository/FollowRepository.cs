using OnlineShop.Models;
using OnlineShop.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Repository
{
    internal class FollowRepository
    {
        public static void CreatFollow(Guid ProductID, Guid CustomerID, string Email)
        {
            DataBase data = new DataBase();
            FollowUp follow = new FollowUp();
            follow.FollowUpID = Guid.NewGuid();
            follow.ProductID = ProductID;
            follow.CustomerID = CustomerID;
            follow.Email = Email;
            data.FollowUp.Add(follow);
            data.SaveChanges();
        }

       
    }
}
