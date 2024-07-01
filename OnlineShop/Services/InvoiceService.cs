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

        // 開立折讓
        public static void CreatAllowance(Guid OrderId, int price, List<ProductModel> ReturnProducs)
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

            string EncryptResult = UniversalCryptoService.Encrypt(allowanceData, Keys.Invoice);
            AllowanceModel allowanceModel = new AllowanceModel();
            allowanceModel.Data = EncryptResult;
            var result = HttpRequests.PostRequest<AllowanceReponse>("https://einvoice-stage.ecpay.com.tw/B2CInvoice/AllowanceByCollegiate", allowanceModel, true);
            string DecodeResult = UniversalCryptoService.Decrypt(result.Item1.Data, Keys.Invoice);
            AllowanceResponseData allowanceResponseData = JsonConvert.DeserializeObject<AllowanceResponseData>(DecodeResult);
            Console.WriteLine(allowanceResponseData.InvoiceNo);
        }

        // 註銷重開
        public static void CreatReIssue(Guid OrderId,string OrderNumber)
        {
            List<BoughtOrderModel> Orders = OrderService.GetBoughtListByUser(Guid.Parse(LoginState.CustomerID), OrderId);
            var voidModel = new Voidmodel();
            var issueModel = new Issuemodel();
            foreach (var order in Orders)
            {
                voidModel.InvoiceNo = order.InvoiceNo;
                voidModel.VoidReason = "註銷重開";

                issueModel.RelateNumber = OrderNumber;
                issueModel.InvoiceDate = order.CreatTime;
                issueModel.InvoiceRemark = "退貨退款";               
                foreach(var product in order.Details)
                {
                    issueModel.SalesAmount = product.price * product.count; //金額計算?
                }
            }

            var reIssueDataModel = new ReIssueDataModel();
        }
            
    }
}
