using OnlineShop.Models;
using OnlineShop.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OnlineShop.Forms
{
    public partial class PayForm : Form
    {
        string payinfo;
        int Discount;
        public PayForm(string payInfo, int Discount)
        {
            InitializeComponent();
            this.payinfo = payInfo;
            this.Discount = Discount;
            PointService.LockPoint(Guid.Parse(LoginState.CustomerID), Discount);
            InitBrowser();
        }


        private async void InitBrowser()
        {
            await webView21.EnsureCoreWebView2Async(); // 初始化webView21
            Thread.Sleep(1000);
            webView21.CoreWebView2.NavigateToString(payinfo.ToString());
        }

        private void PaySucc_Click(object sender, EventArgs e)
        {
            //InvoiceModel invoice = new InvoiceModel(OrderDictionaryModel.MerchantTradeNo, OrderDictionaryModel.TradeAmt);

            CheckOutService.AfterPay(Guid.Parse(LoginState.CustomerID), OrderModel.OrderId, Discount);
            CarService.AllRemoveCar(CarService.GetProductList());
        }


        public static string CreatPayPage()
        {
            var PayDictionary = new Dictionary<string, string>();
            PayDictionary.Add("MerchantID", "2000132");
            PayDictionary.Add("MerchantTradeNo", "1723451916339b851d4ba05ab41d2");
            PayDictionary.Add("LogisticsType", "CVS");
            PayDictionary.Add("LogisticsSubType ", "UNIMART");
            PayDictionary.Add("IsCollection", "N");
            PayDictionary.Add("ServerReplyURL", "https://44d6-61-65-129-179.ngrok-free.app/api/TestAPI/Test");

          
            StringBuilder s = new StringBuilder();
            s.AppendFormat("<form id='payForm' action='{0}' method='post'>", "https://logistics-stage.ecpay.com.tw/Express/map");
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
    }
}
