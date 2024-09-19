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
        public static List<StockModel> GetStock()
        {
            DataBase data = new DataBase();
            var datas = data.Stock
           .Join(data.Product,
               stock => stock.ProductID,
               product => product.ProductID,
               (stock, product) => new
               {
                   ProductID = stock.ProductID,
                   ProductName = product.ProductName,
                   ProductQuantity = stock.ProductQuantity,
                   ProductSafeQuantity = stock.ProductSafeQuantity,
               })
           .ToList();
            List<StockModel> stockModels = new List<StockModel>();
            foreach (var stock in datas)
            {
                StockModel stockModel = new StockModel();
                stockModel.ProductName = stock.ProductName;
                stockModel.ProductID = stock.ProductID;
                stockModel.ProductQuantity = stock.ProductQuantity;
                stockModel.ProductSafeQuantity = stock.ProductSafeQuantity;
                stockModels.Add(stockModel);
            }

            return stockModels;
        }

        public static StockModel CheckStock()
        {
            DataBase data = new DataBase();
            StockModel stock = data.Product.Where(x => x.ProductQuantity < x.ProductSafeQuantity).Select(x => new StockModel
            {
                ProductID = x.ProductID,
                ProductName = x.ProductName,
                ProductQuantity = x.ProductQuantity,
                ProductSafeQuantity = x.ProductSafeQuantity,
            }).FirstOrDefault();
            return stock;
        }

        public static void CreatStock(StockModel stockModel)
        {
            DataBase data = new DataBase();
            Stock stock = new Stock();
            stock.StockID = Guid.NewGuid();
            stock.ProductID = stockModel.ProductID;
            stock.ProductQuantity = stockModel.ProductQuantity;
            stock.ProductSafeQuantity = stockModel.ProductSafeQuantity;
            data.Stock.Add(stock);
            data.SaveChanges();
        }
    }
}
