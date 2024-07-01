using OnlineShop.Models;
using OnlineShop.Models.Entities;
using OnlineShop.Repository;
using OnlineShop.Utility;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows;

namespace OnlineShop.Services
{
    internal class CheckOutService
    {
        
        public static string BeforePay(OrderModel orderModel, int Price, List<ProductModel> products)
        {
            orderModel.CustomerID = Guid.Parse(LoginState.CustomerID);
            OrderService.CreatOrder(orderModel);

            string PayInfo = PaymentService.CreatPayPage(products, Price);
            return PayInfo;
        }

        public static void AfterPay(Guid CustomerId, Guid OrderID, int Discount)
        {
            bool OrderStatus = OrderService.OrderSuccCheck(OrderID);
            if (OrderStatus == true)
            {
                OrderService.ChangeStatus(CustomerId, OrderID);
                PointService.CreatTradePoint(OrderID, Discount);
                LogisticsService.SendFinalLogistics(LoginState.Name, LoginState.Phone);
                LogisticsService.ChangeStatus(LoginState.Name, LoginState.Phone, OrderModel.OrderId);
                InvoiceService.CreateInvoice(LoginState.Phone, Discount);
                InvoiceService.UpDateInvoice(OrderID);
            }
            else
            {
                MessageBox.Show("此訂單已完成付款");
            }
        }
    }
}
