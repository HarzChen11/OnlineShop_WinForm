using OnlineShop.Models.Entities;
using StockControl.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockControl
{
    public class FollowUpService
    {
        public static List<StockModel> SendNotify(StockModel stockModel)
        {
            List<StockModel> NewStock = FollowUpRepository.SendNotify(stockModel);
            return NewStock;
        }
    }
}
