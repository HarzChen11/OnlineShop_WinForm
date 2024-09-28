using OnlineShop.Models;
using OnlineShop.Models.Entities;
using OnlineShop.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows;

namespace OnlineShop.Services
{
    internal class OrderService
    {

        public static void CreatOrder(OrderModel orderModel)
        {
            OrderRepository.CreatOrder(orderModel);
        }

        public static void ChangeStatus(Guid CustomerId, Guid OrderID)
        {
            OrderRepository.ChangeStatus(CustomerId, OrderID);
        }

        public static List<BoughtOrderModel> GetBoughtListByUser(Guid CustomerId, Guid OrderID)
        {
            List<BoughtOrderModel> boughtOrders = OrderRepository.GetBoughtListByUser(CustomerId,OrderID);
            return boughtOrders;
        }

        public static List<BoughtOrderModel> GetBoughtListByUser(Guid CustomerId, string OrderNumber)
        {
            List<BoughtOrderModel> boughtOrders = OrderRepository.GetBoughtListByUser(CustomerId, OrderNumber);
            return boughtOrders;
        }

        public static List<BoughtOrderModel> GetBoughtListByUser(Guid CustomerId)
        {
            List<BoughtOrderModel> boughtOrders = OrderRepository.GetBoughtListByUser(CustomerId);
            
            return boughtOrders;
        }

        public static bool OrderSuccCheck(Guid OrderID)
        {
            bool OrderStatus = OrderRepository.OrderSuccCheck(OrderID);
            return OrderStatus;
        }

        public static int FindLockPoint(Guid OrderId)
        {
            int LockPoint = OrderRepository.FindLockPoint(OrderId);
            return LockPoint;
        }

        // 商品退貨後更改OrderDetail的商品狀態
        public static void ChangeStatus(List<ProductModel> ReturnProducs)
        {
            OrderRepository.ChangeStatus(ReturnProducs);
        }
    }
}
