using OnlineShop.Models;
using OnlineShop.Models.Entities;
using OnlineShop.Models.Enums;
using OnlineShop.Models.ReponseModel;
using OnlineShop.Services;
using OnlineShop.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static OnlineShop.Models.FinalLogisticsModel;

namespace OnlineShop.Repository
{
    internal class LogisticsRepository
    {
        public static FinalLogisticsData SendFinalLogistics(string Name, string phone)
        {
            DataBase data = new DataBase();
            var temp = data.Logistics.Where(x => x.ReceiverName == Name && x.ReceiverCellPhone == phone && x.Status == false).FirstOrDefault();
            temp.OrderID = OrderModel.OrderId;
            temp.Email = LoginState.Email;
            data.SaveChanges();
            var lastLogisticsData = new FinalLogisticsData
            {
                TempLogisticsID = temp.TempLogisticsID,
                MerchantTradeNo = OrderModel.OrderId.ToString(),
            };

            return lastLogisticsData;
        }

        public static void UpDateLogisticsID(Guid OrderId,string LogisticsID)
        {
            DataBase data = new DataBase();
            var order = data.Logistics.Where(x => x.OrderID == OrderId&& x.StatusUpdate == "已付款，待出貨").FirstOrDefault();
            order.LogisticsID = LogisticsID;
            data.SaveChanges();
        }

        public static void ChangeStatus(string Name, string phone, Guid OrderID)
        {
            DataBase data = new DataBase();
            var LogisticsData = data.Logistics.Where(x => x.ReceiverName == Name && x.ReceiverCellPhone == phone && x.OrderID == OrderID && x.Status == false).FirstOrDefault();
            LogisticsData.Status = true;
            LogisticsData.StatusUpdate = "已付款，待出貨";
            data.SaveChanges();
        }

        public static ReturnModel GetLogisticsID(Guid OrderId)
        {
            DataBase data = new DataBase();
            ReturnModel returnModel = data.Logistics.Where(x => x.OrderID == OrderId).Select(x => new ReturnModel
            {
                OrderId = OrderId,
                LogisticsID = x.LogisticsID,
                LogisticsSubType = x.LogisticsSubType.Replace(" ", ""),
            }).FirstOrDefault();

            return returnModel; 
        }
    }
}
