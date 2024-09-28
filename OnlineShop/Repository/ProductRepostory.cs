using OnlineShop.Models;
using OnlineShop.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Repository
{
    internal class ProductRepostory
    {
        public static void ChangeQty(ProductModel model)
        {
            DataBase data = new DataBase();
            var product = data.Product.Where(x => x.ProductID == model.ProducId).FirstOrDefault();
            if (product.ProductQuantity - model.count >= 0)
            {
                product.ProductQuantity -= model.count;
            }
            data.SaveChanges();
        }

        public static int CheckQty(ProductModel model)
        {
            DataBase data = new DataBase();
            int Qty = data.Product.Where(x => x.ProductID == model.ProducId).Select(x => x.ProductQuantity).Single();
            return Qty;

        }

        // 撈product db中庫存<水位的
        public static List<StockModel> CheckStockQty()
        {
            DataBase data = new DataBase();
            List<StockModel> stocks = data.Product.Where(x => x.ProductQuantity < x.ProductSafeQuantity).Select(x => new StockModel
            {
                ProductID = x.ProductID,
                ProductName = x.ProductName,
                ProductQuantity = x.ProductQuantity,
                ProductSafeQuantity = x.ProductSafeQuantity,
            }).ToList();
            return stocks;
        }
    }
}
