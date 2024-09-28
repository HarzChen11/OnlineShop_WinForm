using Newtonsoft.Json;
using OnlineShop.Models;
using OnlineShop.Models.Enums;
using OnlineShop.Models.ReponseModel;
using OnlineShop.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static OnlineShop.Models.ReponseModel.ReturnResponse;
using static OnlineShop.Models.ReturnGoodModel;

namespace OnlineShop.Services
{
    internal class ReturnService
    {
        public static string FindUrl(string SubType)
        {
            string url = "";
            switch (SubType)
            {

                case "FAMI":
                    url = "https://logistics-stage.ecpay.com.tw/Express/v2/ReturnUniMartCVS";
                    break;
                case "UNIMART":
                    url = "https://logistics-stage.ecpay.com.tw/Express/v2/ReturnCVS";
                    break;
                case "HILIFE":
                    url = "https://logistics-stage.ecpay.com.tw/Express/v2/ReturnHilifeCVS";
                    break;
                case "HOME":
                    url = "https://logistics-stage.ecpay.com.tw/Express/v2/ReturnHome";
                    break;
            }
            return url;
        }

        // 發送逆物流請求到綠界
        public static void CreateReturn(ReturnModel returnModel, string value)
        {
            var ReturnData = new ReturnGoodData
            {
                LogisticsID = returnModel.LogisticsID,
                GoodsName = returnModel.GoodsName,
                GoodsAmount = returnModel.Price,
            };

            string Data = UniversalCryptoService.Encrypt(ReturnData, Keys.Logistics);
            ReturnGoodModel returnGood = new ReturnGoodModel();
            returnGood.Data = Data;
            var result = HttpRequests.PostRequest<ReturnResponse>(value, returnGood, true);
            string DecodeResult = UniversalCryptoService.Decrypt(result.Item1.Data, Keys.Logistics);
            ResponseData dataModel = JsonConvert.DeserializeObject<ResponseData>(DecodeResult);
            Console.WriteLine(dataModel.RtnOrderNo);
        }

        // 處理退或發票("折讓>重開"或"作廢")
        public static void ReturnInvoice(Guid OrderId, int price, List<ProductModel> ReturnProducs, string OrderNumber)
        {
            InvoiceService.CheckReturn(OrderId, price, ReturnProducs, OrderNumber);
            OrderService.ChangeStatus(ReturnProducs);
        }

    }
}
