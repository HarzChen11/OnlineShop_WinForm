using Newtonsoft.Json;
using OnlineShop.Models;
using OnlineShop.Models.Enums;
using OnlineShop.Models.ReponseModel;
using OnlineShop.Repository;
using OnlineShop.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static OnlineShop.Models.FinalLogisticsModel;
using static OnlineShop.Models.TempLogisticsModel;
using static OnlineShop.Models.ReponseModel.LogisticsResponse;
using System.Text.RegularExpressions;

namespace OnlineShop.Services
{
    internal class LogisticsService
    {
        static TempLogisticsModel logisticsModel;
        static string logisticsId;
        public static string CreateLogistics (OrderModel orderModel)
        {

            var logisticsData = new TempLogisticsDataModel
            {
                TempLogisticsID ="0",
                GoodsAmount =orderModel.Total,
                ReceiverAddress =orderModel.Address,
                ReceiverCellPhone =orderModel.Phone,
                ReceiverName =orderModel.Name,
                EshopMemberID = new string(LoginState.CustomerID.ToString().Replace("-", "").Substring(0, 24).OrderBy(c => char.IsDigit(c)).ThenBy(c => c).ToArray())
        };

            string EncryptResult = UniversalCryptoService.Encrypt(logisticsData, Keys.Logistics);
            logisticsModel = new TempLogisticsModel();
            logisticsModel.Data = EncryptResult;
            var result = HttpRequests.PostRequest<LogisticsResponse>("https://logistics-stage.ecpay.com.tw/Express/v2/RedirectToLogisticsSelection", logisticsModel, false);
            return result.Item2;
        }

   

        // 建立正式物流訂單
        public static void SendFinalLogistics(string Name, string phone)
        {
            var finalLogisticsData = LogisticsRepository.SendFinalLogistics(Name,phone);

            string EncryptResult = UniversalCryptoService.Encrypt(finalLogisticsData, Keys.Logistics);
            FinalLogisticsModel logisticsModel = new FinalLogisticsModel();
            logisticsModel.Data = EncryptResult;
            var result = HttpRequests.PostRequest<LogisticsResponse>("https://logistics-stage.ecpay.com.tw/Express/v2/CreateByTempTrade", logisticsModel, true);
            string DecodeResult = UniversalCryptoService.Decrypt(result.Item1.Data, Keys.Logistics);
            LogisticsResponseData reponseData = JsonConvert.DeserializeObject<LogisticsResponseData>(DecodeResult);
            logisticsId = reponseData.LogisticsID;
        }

        public static void ChangeStatus(string Name, string phone, Guid OrderID)
        {
            LogisticsRepository.ChangeStatus(Name, phone, OrderID);
            // 更新正式物流編
            LogisticsRepository.UpDateLogisticsID(OrderModel.OrderId, logisticsId);
            
        }

        public static ReturnModel GetLogisticsID(Guid OrderId)
        {
            ReturnModel returnModel = LogisticsRepository.GetLogisticsID(OrderId);
            return returnModel;
        }
    }
}
