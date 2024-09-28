using OnlineShop.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockControl
{
    internal class StockRepository
    {
        public static List<StockModel> getStockList()
        {
            DataBase data = new DataBase();
            List<StockModel> stockList = (from stock in data.Stock join product in data.Product on stock.ProductID equals product.ProductID
                                          select new StockModel
                                          {
                                              ProductID = stock.ProductID,
                                              ProductName = product.ProductName,
                                              ProductQuantity = stock.ProductQuantity,
                                              ProductSafeQuantity = stock.ProductSafeQuantity,
                                              Status = stock.Status,    
                                          }).ToList();

            return stockList;
        }

        public static StockModel Ordered(StockModel stockModel)
        {
            DataBase data = new DataBase();
            var item = data.Stock.Where(x => x.ProductID == stockModel.ProductID).FirstOrDefault();
            item.Status = "已叫貨，未出貨";
            data.SaveChanges();

            StockModel stock = new StockModel
            {
                ProductID = item.ProductID,
                ProductQuantity = item.ProductQuantity,
                Status = item.Status,
            };

            return stock;
        }

        public static StockModel ReStock(StockModel stockModel)
        {
            DataBase data = new DataBase();
            var item = data.Stock.Where(x => x.ProductID == stockModel.ProductID).FirstOrDefault();
            int AddQty = stockModel.ProductQuantity + (stockModel.ProductSafeQuantity - stockModel.ProductQuantity);
            item.ProductQuantity = AddQty;
            item.Status = "已補貨";

            var item1 = data.Product.Where(X=>X.ProductID == stockModel.ProductID).FirstOrDefault();
            item1.ProductQuantity = AddQty;
            data.SaveChanges();

            StockModel stock = new StockModel
            {
                ProductID = item.ProductID,
                ProductQuantity = item.ProductQuantity,
                Status = item.Status,
            };
            
            return stock;
        }
    }
}
