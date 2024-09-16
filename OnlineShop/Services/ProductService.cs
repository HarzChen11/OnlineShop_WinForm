﻿using OnlineShop.Models;
using OnlineShop.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Services
{
    internal class ProductService
    {
        public static void ChangeQty(List<BoughtOrderModel> boughtOrders)
        {
            foreach (var order in boughtOrders)
            {
               foreach(var product in order.Details)
                {
                    ProductRepostory.ChangeQty(product);
                }
            }
        }

        public static int CheckQty(ProductModel model)
        {
            int Qty = ProductRepostory.CheckQty(model);
            return Qty;
        }
    }
}
