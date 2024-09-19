using OnlineShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OnlineShop.Services
{
    internal static class TaskService
    {
       
        static bool productExists;
        public static async Task StartCheckingAsync()
        {
            Task checkStock = new Task(() =>
            {
                while (true)
                {
                    List<StockModel> stockModels = StockService.GetStock();
                    //Thread.Sleep(300000);
                    Thread.Sleep(10000);
                    DateTime dateTime = DateTime.Now;

                    StockModel products = StockService.CheckStock();

                    bool productExists = stockModels.Any(x => x.ProductID == products.ProductID);
                    
                    if (!productExists)
                    {
                        StockService.CreatStock(products);
                    }
                }
            });
            checkStock.Start();
        }

    }
}
