using OnlineShop.Models;
using OnlineShop.Models.Entities;
using OnlineShop.Models.Enums;
using OnlineShop.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Services
{
    internal class CartService
    {
        static List<ProductModel> productList = new List<ProductModel>();

        public CartService()
        {
            productList = CarRepository.GetProductListByUser(Guid.Parse(LoginState.CustomerID));
        }

        public static List<ProductModel> getList()
        {
            return CarRepository.GetProductListByUser(Guid.Parse(LoginState.CustomerID));
        }

        public static int getTotal { get { return productList.Sum(x => x.count); } }

        // 前端加入購物車
        public static void AddToCar(CartAction action, ProductModel product)
        {

            var item = productList.Where(x => x.Id == product.Id).FirstOrDefault();

            if (item == null)
            {
                productList.Add(product);
            }
            else if (item.count == 0)
            {
                productList.Remove(item);
            }
            else if (action == CartAction.Button)
            {
                item.count++;
            }
            else if (action == CartAction.NumberUpDown)
            {
                item.count = product.count;
            }
            Guid customerID = Guid.Parse(LoginState.CustomerID);

            CarRepository.AddItem(customerID,productList);

            //int total = productList.Sum(x => x.count);
            EventHandlers.AddItem(productList.Sum(x => x.count));
            EventHandlers.RanderCar();
        }



        // 前端移除購物車
        public void RemoveCar(ProductModel product)
        {
            var item = productList.Where(x => x.Id == product.Id).FirstOrDefault();
            item.count = 0;
            productList.Remove(item);

            Guid customerID = Guid.Parse(LoginState.CustomerID);
            CarRepository.RemoveItem(customerID,item);

            EventHandlers.AddItem(productList.Sum(x => x.count));
            EventHandlers.RanderCar();
        }

    

    }
}
