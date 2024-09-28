using OnlineShop.Models;
using OnlineShop.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Services
{
    internal class StockService
    {
        //public static List<StockModel> GetStockList()
        //{
        //    List<StockModel> stockModels = StockRepository.GetStockList();
        //    return stockModels;
        //}

        public static List<StockModel> CreatStock(List<StockModel> ProductStocks)
        {
            List<StockModel> stockModels = StockRepository.GetStockList();

            var ProductIds = stockModels.Select(x => x.ProductID).ToHashSet();
            List<StockModel> extraItems = ProductStocks.Where(x => !ProductIds.Contains(x.ProductID)).ToList();

            if (extraItems != null)
            {
                foreach (var item in extraItems)
                {
                    StockRepository.CreatStock(item);
                }
            }
            return extraItems;
        }
    }
}
