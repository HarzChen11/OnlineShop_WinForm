using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace test
{
    internal class checkMac
    {
        public static string CreatPayPage()
        {
            var PayDictionary = new Dictionary<string, string>();
            PayDictionary.Add("MerchantID", "2000933");
            //PayDictionary.Add("MerchantTradeNo", "ORD" + DateTime.Now.ToString("yyyyMMddHHmmss"));
            //PayDictionary.Add("MerchantTradeNo", "20240818223724911");
            PayDictionary.Add("MerchantTradeDate", DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"));
            PayDictionary.Add("LogisticsType", "CVS");
            PayDictionary.Add("LogisticsSubType", "UNIMARTC2C");
            PayDictionary.Add("GoodsAmount", "1000");
            PayDictionary.Add("CollectionAmount", "1000");
            PayDictionary.Add("IsCollection", "N");
            PayDictionary.Add("GoodsName", "雨傘");
            PayDictionary.Add("SenderName ", "寄件人");
            PayDictionary.Add("SenderCellPhone ", "0941848839");
            PayDictionary.Add("ReceiverName", "收件人");
            PayDictionary.Add("ReceiverCellPhone", "0941848838");
            PayDictionary.Add("ServerReplyURL", "https://localhost:4200");
            PayDictionary.Add("ReceiverStoreID", "131386");
            PayDictionary.Add("CheckMacValue", CreatCheckMacValue(PayDictionary));



            StringBuilder s = new StringBuilder();
            s.AppendFormat("<form id='payForm' action='{0}' method='post'>", "https://logistics-stage.ecpay.com.tw/Express/Create");
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
            string temp = "HashKey=XBERn1YOvpM9nfZc" + szParameters + "&HashIV=h1ONHk4P4yqbl5LK";
            string szCheckMacValue = HttpUtility.UrlEncode(temp).ToLower();
            string CheckMacValue = MD5Encoder.Encrypt(szCheckMacValue);
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

            //szParameters=szParameters.TrimStart('&');
            return szParameters;
        }

        private static string BuildParamenter(string id, object value)
        {
            string szValue = "";
            string szParameter = "";

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
