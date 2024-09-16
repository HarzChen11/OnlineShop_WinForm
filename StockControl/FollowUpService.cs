using OnlineShop.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockControl
{
    public class FollowUpService
    {
        public static List<FollowModel> GetFollowList()
        {
            DataBase data = new DataBase();
            var followData = data.FollowUp.Select(x=>new FollowModel
            {
                Email = x.Email,
            }).ToList();

            return followData;
        }

    }
}
