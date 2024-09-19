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

            List<StockModel> Models = new List<StockModel>();
            foreach (var stock in datas)
            {
                StockModel stockModel = new StockModel();
                stockModel.ProductName = stock.ProductName;
                stockModel.ProductID = stock.ProductID;
                stockModel.ProductQuantity = stock.ProductQuantity;
                stockModel.ProductSafeQuantity = stock.ProductSafeQuantity;
                Models.Add(stockModel);
            }

            return Models;
        }
    }
}
