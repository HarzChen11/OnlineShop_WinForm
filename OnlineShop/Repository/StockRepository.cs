using OnlineShop.Models;
using OnlineShop.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Repository
{
    internal class StockRepository
    {
        //撈已存在stock db資料的
        public static List<StockModel> GetStockList()
        {
            DataBase data = new DataBase();
            List<StockModel> stocks = data.Stock.Select(x => new StockModel
            {
                StockID = x.StockID,
                ProductID = x.ProductID,
                ProductQuantity = x.ProductQuantity,
                ProductSafeQuantity = x.ProductSafeQuantity
            }).ToList();

            return stocks;
        }

        public static List<StockModel> CheckStock()
        {
            DataBase data = new DataBase();
            List<StockModel> stockList = data.Product.Where(x => x.ProductQuantity < x.ProductSafeQuantity).Select(x => new StockModel
            {
                ProductID = x.ProductID,
                ProductName = x.ProductName,
                ProductQuantity = x.ProductQuantity,
                ProductSafeQuantity = x.ProductSafeQuantity,
            }).ToList();
            return stockList;
        }

        public static void CreatStock(StockModel ProductStocks)
        {
            DataBase data = new DataBase();
            Stock stock = new Stock();
            stock.StockID = Guid.NewGuid();
            stock.ProductID = ProductStocks.ProductID;
            stock.ProductQuantity = ProductStocks.ProductQuantity;
            stock.ProductSafeQuantity = ProductStocks.ProductSafeQuantity;
            stock.Status = "未叫貨";
            data.Stock.Add(stock);
            data.SaveChanges();
        }
    }
}
