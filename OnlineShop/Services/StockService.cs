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
        public static List<StockModel> GetStock()
        {
            List<StockModel> stockModels = StockRepository.GetStock();
            return stockModels;
        }

        public static StockModel CheckStock()
        {
            StockModel stock = StockRepository.CheckStock();
            return stock;
        }

        public static void CreatStock(StockModel stock)
        {
            StockRepository.CreatStock(stock);
        }
    }
}
