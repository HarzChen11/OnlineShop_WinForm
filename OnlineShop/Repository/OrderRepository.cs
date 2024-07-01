using OnlineShop.Models;
using OnlineShop.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OnlineShop.Repository
{
    internal class OrderRepository
    {
        public static void CreatOrder(string UserID,List<ProductModel> products)
        {
           
            DataBase data = new DataBase();
            Guid cusID = Guid.Parse(UserID);
            var addDetail = data.Order.FirstOrDefault(x => x.CustomerID == cusID);
            if (products.Count >= 1)
            {
                OrderDetails detail = new OrderDetails();
                detail.OrderDetailsID = Guid.NewGuid();
                detail.OrderID = addDetail.OrderID;
                for (int i = 0; i < products.Count(); i++)
                {
                    detail.ProductID = products[i].Id;
                    detail.ProductColor = "隨機";
                    detail.ProductSpec = "正常";
                    detail.ProductQuantity = products[i].count;
                    detail.Price = products[i].price;
                }
                data.OrderDetails.Add(detail);

                int res = data.SaveChanges();
                if (res != 0)
                {
                    MessageBox.Show("結帳成功");
                }
            }


        }
    }
}
