using OnlineShop.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockControl.Repository
{

    internal class FollowUpRepository
    {
        public static List<StockModel> SendNotify(StockModel stockModel)
        {
            DataBase data = new DataBase();
            var follows = data.FollowUp.Where(x => x.ProductID == stockModel.ProductID).Select(x => new FollowModel
            {
                Email = x.Email,
                ProductName = stockModel.ProductName,
            }).ToList();

            // 從叫貨表移除已補貨並通知用戶的商品
            var item = data.Stock.Where(x => x.ProductID == stockModel.ProductID).FirstOrDefault();
            data.Stock.Remove(item);
            data.SaveChanges();

            var NewStock = (from stock in data.Stock
                            join product in data.Product on stock.ProductID equals product.ProductID
                            select new StockModel
                            {
                                ProductID = stock.ProductID,
                                ProductName = product.ProductName, 
                                ProductQuantity = stock.ProductQuantity,
                                ProductSafeQuantity = stock.ProductSafeQuantity,
                            }).ToList();

            // 發送郵件通知追蹤此商品的用戶
            if (follows.Count() != 0)
            {
                MailService.FollowMail(follows);
            }
            
            return NewStock;
        }
    }
}
