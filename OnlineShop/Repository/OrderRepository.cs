using OnlineShop.Models;
using OnlineShop.Models.Entities;
using OnlineShop.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Repository
{
    internal class OrderRepository
    {
        public static void CreatOrder(OrderModel orderModel)
        {
            DataBase data = new DataBase();
            var Carinfo = data.Trolley.FirstOrDefault(x => x.Customer == orderModel.CustomerID && x.OrderStatus == false);
            if (Carinfo != null)
            {
                Order order = new Order();
                order.OrderID = OrderModel.OrderId;
                order.CustomerID = Guid.Parse(LoginState.CustomerID);
                order.OrderNumber = DateTime.Now.ToString("ODyyMMddHHmm");
                order.PaymentStatus = "待付款";
                order.Deliver = null;
                order.Ordering = "未出貨";
                order.CreateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                order.TrolleyID = Carinfo.TrolleyID;
                data.Order.Add(order);
                data.SaveChanges();
                CreatOrderDetail(orderModel);
            }
        }

        private static void CreatOrderDetail(OrderModel orderModel)
        {
            EventHandlers.Login(true);
            DataBase data = new DataBase();
            foreach (var product in orderModel.Products)
            {
                OrderDetails detail = new OrderDetails();
                detail.OrderDetailsID = Guid.NewGuid();
                detail.OrderID = OrderModel.OrderId;
                detail.ProductID = product.ProducId;
                detail.ProductColor = "隨機";
                detail.ProductSpec = "正常";
                detail.ProductQuantity = product.count;
                detail.Price = product.price;
                data.OrderDetails.Add(detail);
            }
            data.SaveChanges();
        }

        // 順便加上點數的狀態
        public static void ChangeStatus(Guid CustomerID, Guid OrderID)
        {
            DataBase data = new DataBase();
            var info = data.Order.Where(x => x.CustomerID == CustomerID && x.OrderID == OrderID)
                .Join(data.Trolley, order => order.TrolleyID, Trolley => Trolley.TrolleyID,
                 (order, Trolley) => new { Order = order, Trolley = Trolley }).FirstOrDefault();

            if (info != null)
            {
                info.Trolley.OrderStatus = true;
                info.Order.PaymentStatus = "已付款";
            }

            ChangePointStatus(CustomerID);

            data.SaveChanges();
        }

        // 更改點數狀態
        private static void ChangePointStatus(Guid CustomerID)
        {
            DataBase data = new DataBase();
            var LockPoints = data.PointsSystem.Where(x => x.CustomerID == CustomerID && x.Status == "已鎖定").ToList();
            foreach (var point in LockPoints)
            {
                point.Status = "已使用";
                point.Used = false;
                point.Point = -point.Point;
            }
            data.SaveChanges();
        }



        // 取得使用者的已完成結帳的購物車資料
        public static List<BoughtOrderModel> GetBoughtListByUser(Guid CustomerId, string OrderNumber)
        {
            DataBase data = new DataBase();
            List<BoughtOrderModel> boughtOrders = data.Order.Where(x => x.CustomerID == CustomerId && x.OrderNumber == OrderNumber && x.PaymentStatus == "已付款").Select(x => new BoughtOrderModel
            {
                OrderID = x.OrderID.ToString(),
                OrderNumber = x.OrderNumber,
                InvoiceNo = x.InvoiceNo,
                CreatTime = x.CreateTime.ToString(),
                Discount = x.LockPoint.ToString(),
                Details = x.OrderDetails.Select(y => new ProductModel
                {
                    OrderDetailsID = y.OrderDetailsID,
                    name = y.Product.ProductName,
                    count = y.ProductQuantity,
                    price = y.Price * y.ProductQuantity,
                    img = y.Product.ProductImg,

                }).ToList()
            }).ToList();
            return boughtOrders;
        }

        public static List<BoughtOrderModel> GetBoughtListByUser(Guid CustomerId, Guid OrderID)
        {
            DataBase data = new DataBase();
            List<BoughtOrderModel> boughtOrders = data.Order.Where(x => x.CustomerID == CustomerId && x.OrderID == OrderID && x.PaymentStatus == "已付款").Select(x => new BoughtOrderModel
            {
                OrderID = x.OrderID.ToString(),
                OrderNumber = x.OrderNumber,
                InvoiceNo = x.InvoiceNo,
                CreatTime = x.CreateTime.ToString(),
                Discount = x.LockPoint.ToString(),
                Details = x.OrderDetails.Select(y => new ProductModel
                {
                    name = y.Product.ProductName,
                    ProducId = y.Product.ProductID,
                    OrderDetailsID = y.OrderDetailsID, 
                    count = y.ProductQuantity,
                    price = y.Price,
                    img = y.Product.ProductImg,

                }).ToList()
            }).ToList();
            return boughtOrders;
        }

        public static List<BoughtOrderModel> GetBoughtListByUser(Guid CustomerId)
        {
            DataBase data = new DataBase();
            List<BoughtOrderModel> boughtOrders = data.Order.Where(x => x.CustomerID == CustomerId && x.PaymentStatus == "已付款").Select(x => new BoughtOrderModel
            {
                OrderID = x.OrderID.ToString(),
                OrderNumber = x.OrderNumber,
                InvoiceNo= x.InvoiceNo,
                CreatTime = x.CreateTime.ToString(),
                Discount = x.LockPoint.ToString(),
                 Details = x.OrderDetails.Select(y => new ProductModel
                 {
                     name = y.Product.ProductName,
                     count = y.ProductQuantity,
                     price = y.Price*y.ProductQuantity,
                     img = y.Product.ProductImg,
                     
                 }).ToList()

            }).ToList();
            return boughtOrders;
        }

        public static bool OrderSuccCheck(Guid OrderID)
        {
            DataBase data = new DataBase();
            var orderInfo = data.Order.Where(x => x.OrderID == OrderID && x.PaymentStatus == "已付款").FirstOrDefault();
            if (orderInfo != null)
                return false;
            return true;
        }

        public static int FindLockPoint(Guid OrderId)
        {
            DataBase data = new DataBase();
            var order = data.Order.Where(x => x.OrderID == OrderId).FirstOrDefault();
            return (int)order.LockPoint;
        }
    }
}
