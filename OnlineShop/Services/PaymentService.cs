using OnlineShop.Models;
using OnlineShop.Utility;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace OnlineShop.Services
{
    internal class PaymentService
    {
        public static string CreatPayPage(List<ProductModel> products, int Price)
        {
            var PayDictionary = new Dictionary<string, string>();
            PayDictionary.Add("MerchantID", "3002607");
            PayDictionary.Add("MerchantTradeNo", "ORD" + DateTime.Now.ToString("yyyyMMddHHmmss"));
            PayDictionary.Add("MerchantTradeDate", DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"));
            PayDictionary.Add("PaymentType", "aio");
            //int total = products.Sum(x => x.price * x.count);
            PayDictionary.Add("TotalAmount", Math.Abs(Price).ToString());
            PayDictionary.Add("TradeDesc", "平台購買商品");
            string productsName = "";
            foreach (var item in products)
            {
                string productName = item.name;
                productsName += (item.count > 1) ? productName + "-數量:" + item.count + "#" : productName + "#";
            }
            PayDictionary.Add("ItemName", productsName);
            PayDictionary.Add("ReturnURL", "http://localhost:5032/api/CheckOut/chckout");
            PayDictionary.Add("ChoosePayment", "Credit");
            PayDictionary.Add("EncryptType", "1");
            PayDictionary.Add("CheckMacValue", CreatCheckMacValue(PayDictionary));

            OrderDictionaryModel.MerchantTradeNo = PayDictionary["MerchantTradeNo"];
            OrderDictionaryModel.TradeAmt = int.Parse(PayDictionary["TotalAmount"]);
            OrderDictionaryModel.ItemCount = products.Count();

            StringBuilder s = new StringBuilder();
            s.AppendFormat("<form id='payForm' action='{0}' method='post'>", "https://payment-stage.ecpay.com.tw/Cashier/AioCheckOut/V5");
            foreach (KeyValuePair<string, string> item in PayDictionary)
            {
                s.AppendFormat("<input type='text' name='{0}' value='{1}' />", item.Key, item.Value);
            }

            s.Append(@"</form> <script type='text/javascript'>
                     window.onload = function() {
                     document.getElementById('payForm').submit();
                            }
                    </script> ");

            return s.ToString();
        }

        private static string CreatCheckMacValue(Dictionary<string, string> PayDictionary)
        {
            string szParameters = RenderControlAndParamenter(PayDictionary);
            string temp = "HashKey=pwFHCqoQZGmho4w6" + szParameters + "&HashIV=EkRm7iFT261dpevs";
            string szCheckMacValue = HttpUtility.UrlEncode(temp).ToLower();
            string CheckMacValue = SHA256Encoder.Encrypt(szCheckMacValue);
            return CheckMacValue;
        }

        private static string RenderControlAndParamenter(Dictionary<string, string> PayDictionary)
        {
            string szParameters = String.Empty;
            ArrayList aryKeys = null;

            aryKeys = new ArrayList(PayDictionary.Keys);
            aryKeys.Sort();

            foreach (string szKey in aryKeys)
            {
                string szValue = String.Empty;
                object oValue = PayDictionary[szKey];
                szParameters += BuildParamenter(szKey, oValue);
            }

            return szParameters;
        }

        private static string BuildParamenter(string id, object value)
        {
            string szValue = "";
            string szParameter ="";

            if (null != value)
            {
                if (value.GetType().Equals(typeof(DateTime)))
                    szValue = ((DateTime)value).ToString("yyyy/MM/dd HH:mm:ss");
                else
                    szValue = value.ToString();
            }

            szParameter = String.Format("&{0}={1}", id, szValue);

            return szParameter;
        }
    }
}
