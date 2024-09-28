using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using Newtonsoft.Json;
using OnlineShop.Models;
using static OnlineShop.Models.InvoiceModel;
using System.Security.Cryptography;
using static OnlineShop.Models.InvoiceDataModel;
using RestSharp;
using System.Net.Http;
using OnlineShop.Models.ReponseModel;
using OnlineShop.Utility;
using static OnlineShop.Models.ReponseModel.PrintInvoiceReponse;
using OnlineShop.Models.Enums;
using OnlineShop.Repository;
using static OnlineShop.Models.AllowanceModel;
using static OnlineShop.Models.AllowanceModel.AllowanceData;
using static OnlineShop.Models.ReponseModel.AllowanceReponse;
using static OnlineShop.Models.ECPay.ReIssueModel;
using OnlineShop.Models.ECPay;
using OnlineShop.Models.Reponse;
using static OnlineShop.Models.ECPay.ReIssueModel.ReIssueDataModel;
using static OnlineShop.Models.ECPay.ReIssueModel.ReIssueDataModel.Issuemodel;
using static OnlineShop.Models.Reponse.ReIssueReponse;
using static OnlineShop.Models.Reponse.InvalidReponse;

namespace OnlineShop.Services
{
    internal class InvoiceService
    {
        static ResponseDataModel dataModel;
        public static void CreateInvoice(string customerPhone, int Discount)
        {
            List<BoughtOrderModel> Orders = OrderService.GetBoughtListByUser(Guid.Parse(LoginState.CustomerID), OrderModel.OrderId);
            foreach (var item in Orders)
            {
                item.Details.Add(new ProductModel
                {
                    ProducId = Guid.NewGuid(),
                    name = "點數折扣",
                    price = 0 - Discount,
                    count = 1,
                    img = null
                });
            }

            var invoice = new InvoiceDataModel
            {
                MerchantID = "2000132",
                RelateNumber = OrderDictionaryModel.MerchantTradeNo,
                CustomerPhone = customerPhone,
                TaxType = "1",
                SalesAmount = OrderDictionaryModel.TradeAmt,
                InvType = "07",
                Vat = "1",
                Items = new List<Item>()
            };

            int i = 0;
            foreach (var order in Orders)
            {
                foreach (var item in order.Details)
                {
                    invoice.Items.Add(new Item
                    {
                        ItemSeq = i,
                        ItemName = item.name,
                        ItemCount = item.count,
                        ItemWord = "件",
                        ItemPrice = item.price * item.count,
                        ItemTaxType = "1",
                        ItemAmount = (item.price * item.count)
                    });
                    i++;
                }
            }

            // 做UrlEncode、AES加密資料
            string EncryptResult = UniversalCryptoService.Encrypt(invoice, Keys.Invoice);

            InvoiceModel invoiceModel = new InvoiceModel();
            invoiceModel.Data = EncryptResult;
            var result = HttpRequests.PostRequest<InvoiceResponseModel>("https://einvoice-stage.ecpay.com.tw/B2CInvoice/Issue", invoiceModel, true);
            string DecodeResult = UniversalCryptoService.Decrypt(result.Item1.Data, Keys.Invoice);
            dataModel = JsonConvert.DeserializeObject<ResponseDataModel>(DecodeResult);
            GetInvoiceImg(dataModel);
        }

        private static void GetInvoiceImg(ResponseDataModel dataModel)
        {
            var PrintData = new PrintDataModel()
            {
                InvoiceNo = dataModel.InvoiceNo,
                InvoiceDate = dataModel.InvoiceDate
            };

            string EncryptResult = UniversalCryptoService.Encrypt(PrintData, Keys.Invoice);
            PrintInvoiceModel printInvoice = new PrintInvoiceModel();
            printInvoice.Data = EncryptResult;
            var result = HttpRequests.PostRequest<PrintInvoiceReponse>("https://einvoice-stage.ecpay.com.tw/B2CInvoice/InvoicePrint", printInvoice, true);
            string DecodeResult = UniversalCryptoService.Decrypt(result.Item1.Data, Keys.Invoice);
            PrintInvoiceReponseData reponseData = JsonConvert.DeserializeObject<PrintInvoiceReponseData>(DecodeResult);
            SendInvoice(reponseData.InvoiceHtml);

        }

        // 更新結帳後訂單的發票資訊
        public static void UpDateInvoice(Guid OrderId)
        {
            InvoiceRepository.UpDateInvoice(OrderId, dataModel);
        }

        // 寄出發票
        private static void SendInvoice(string InvoiceUrl)
        {
            MailService.SendInvoiceMail(LoginState.Email, InvoiceUrl);
        }

        // 判斷發票是折讓(此訂單多個商品只退部分)還是作廢(此訂單只有一筆商品)
        public static void CheckReturn(Guid OrderId, int price, List<ProductModel> ReturnProducs, string OrderNumber)
        {
            List<BoughtOrderModel> Orders = OrderService.GetBoughtListByUser(Guid.Parse(LoginState.CustomerID), OrderId);
            if (Orders.Any(order => order.Details.Any(product => product.count > 1)))
            {
                CreatAllowance(OrderId, price, ReturnProducs, OrderNumber);
            }
            else
            {
                InvalidInvoice(OrderId);
            }
        }

        // 開立折讓
        public static void CreatAllowance(Guid OrderId, int price, List<ProductModel> ReturnProducs, string OrderNumber)
        {
            AllowanceData allowanceData = InvoiceRepository.GetInvoiceFromUser(OrderId);
            allowanceData.CustomerName = LoginState.Name;
            allowanceData.NotifyMail = LoginState.Email;
            allowanceData.AllowanceAmount = price;

            var items = new List<AllowanceItem>();

            int i = 0;
            foreach (var product in ReturnProducs)
            {
                var item = new AllowanceItem
                {
                    ItemSeq = i,
                    ItemName = product.name,
                    ItemCount = product.count,
                    ItemWord = "件",
                    ItemPrice = product.price * product.count,
                    ItemTaxType = "2",
                    ItemAmount = product.price * product.count
                };
                items.Add(item);
                i++;
            }
            allowanceData.Items = items.ToArray();
            string EncryptResult = UniversalCryptoService.Encrypt(allowanceData, Keys.Invoice);
            AllowanceModel allowanceModel = new AllowanceModel();
            allowanceModel.Data = EncryptResult;
            var result = HttpRequests.PostRequest<AllowanceReponse>("https://einvoice-stage.ecpay.com.tw/B2CInvoice/AllowanceByCollegiate", allowanceModel, true);
            string DecodeResult = UniversalCryptoService.Decrypt(result.Item1.Data, Keys.Invoice);
            AllowanceResponseData allowanceResponseData = JsonConvert.DeserializeObject<AllowanceResponseData>(DecodeResult);
            Console.WriteLine(allowanceResponseData.InvoiceNo);
            // 折讓後必須重開
            CreatReIssueModel(OrderId, OrderNumber, ReturnProducs);
        }

        // 註銷重開
        private static void CreatReIssueModel(Guid OrderId, string OrderNumber, List<ProductModel> ReturnProducs)
        {
            List<BoughtOrderModel> Orders = OrderService.GetBoughtListByUser(Guid.Parse(LoginState.CustomerID), OrderId);

            foreach (var returnProduct in ReturnProducs)
            {
                foreach (var order in Orders)
                {
                    var productToRemove = order.Details.FirstOrDefault(p => p.ProducId == returnProduct.ProducId);

                    if (productToRemove != null)
                    {
                        order.Details.Remove(productToRemove);
                    }
                }
            }

            var voidModel = new Voidmodel
            {
                InvoiceNo = Orders[0].InvoiceNo,
                VoidReason = "註銷重開"
            };

            int total = 0;
            foreach (var product in Orders[0].Details)
            {
                total += product.price * product.count;
            }

            var items = new List<IssueItem>();

            int i = 0;
            foreach (var product in Orders[0].Details)
            {
                var item = new IssueItem
                {
                    ItemSeq = i,
                    ItemName = product.name,
                    ItemCount = product.count,
                    ItemWord = "件",
                    ItemPrice = product.price,
                    ItemTaxType = "1",
                    ItemAmount = product.price,
                    ItemRemark = "註銷重開"
                };
                items.Add(item);
                i++;
            }

            var Issuemodel = new Issuemodel
            {
                RelateNumber = OrderNumber,
                InvoiceDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                SalesAmount = total,
                InvoiceRemark = "註銷重開",
                Items = items.ToArray(),
            };

            ReIssueDataModel reIssueDataModel = new ReIssueDataModel();
            reIssueDataModel.VoidModel = voidModel;
            reIssueDataModel.IssueModel = Issuemodel;
    

            string EncryptResult = UniversalCryptoService.Encrypt(reIssueDataModel, Keys.Invoice);
            ReIssueModel reIssueModel = new ReIssueModel();
            reIssueModel.Data = EncryptResult;
            var result = HttpRequests.PostRequest<ReIssueReponse>("https://einvoice-stage.ecpay.com.tw/B2CInvoice/VoidWithReIssue", reIssueModel, true);
            string DecodeResult = UniversalCryptoService.Decrypt(result.Item1.Data, Keys.Invoice);
            ReIssueReponseData reIssueReponseData = JsonConvert.DeserializeObject<ReIssueReponseData>(DecodeResult);
            Console.WriteLine(reIssueReponseData.InvoiceNo);
        }

        // 發票作廢
        private static void InvalidInvoice(Guid OrderId)
        {
            List<BoughtOrderModel> Orders = OrderService.GetBoughtListByUser(Guid.Parse(LoginState.CustomerID), OrderId);

            var InvalidData = new InvalidData
            {
                InvoiceNo = Orders[0].InvoiceNo,
                InvoiceDate = DateTime.Parse(Orders[0].CreatTime).ToString("yyyy-MM-dd"),
                Reason ="退貨後作廢",
            };

            string EncryptResult = UniversalCryptoService.Encrypt(InvalidData, Keys.Invoice);
            InvalidModel invalidModel = new InvalidModel();
            invalidModel.Data = EncryptResult;
            var result = HttpRequests.PostRequest<InvalidReponse>("https://einvoice-stage.ecpay.com.tw/B2CInvoice/Invalid", invalidModel, true);
            string DecodeResult = UniversalCryptoService.Decrypt(result.Item1.Data, Keys.Invoice);
            InvalidReponseData invalidReponseData = JsonConvert.DeserializeObject<InvalidReponseData>(DecodeResult);
            Console.WriteLine(invalidReponseData.RtnMsg);
        }
    }

}

   

