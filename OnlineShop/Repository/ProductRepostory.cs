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
    }
}
