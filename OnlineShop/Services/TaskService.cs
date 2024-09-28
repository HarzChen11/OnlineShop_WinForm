using Newtonsoft.Json;
using OnlineShop.Models;
using OnlineShop.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OnlineShop.Services
{
    internal class TaskService
    {
        public static async Task StartCheckingAsync()
        {

            Task checkStock = new Task(() =>
            {
                while (true)
                {
                    RabbitMQService.CreatConnection();

                    //Thread.Sleep(300000);
                    Thread.Sleep(10000);
                    DateTime dateTime = DateTime.Now;

                    // 從ProductDB中撈出庫存<水位的
                    List<StockModel> stockModel = ProductService.CheckStockQty();
                    List<StockModel> extraItems = StockService.CreatStock(stockModel);
                    if (extraItems.Count != 0)
                    {
                        string EncodeStock = JsonConvert.SerializeObject(extraItems);
                        RabbitMQService.creat(RabbitMQService.channel, EncodeStock);
                    }
                }
            });
            checkStock.Start();
        }


    }
}
