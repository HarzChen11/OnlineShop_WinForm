using OnlineShop.Models;
using OnlineShop.Models.Entities;
using OnlineShop.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
                detail.Status = "正常";
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

            PointService.ChangePointStatus(CustomerID);

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
                //InvoiceStatus = x.InvoiceStatus,
                CreatTime = x.CreateTime.ToString(),
                Discount = (int)(x.LockPoint ?? 0),
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
                Discount = (int)(x.LockPoint ?? 0),
                Details = x.OrderDetails.Select(y => new ProductModel
                {
                    name = y.Product.ProductName,
                    ProducId = y.Product.ProductID,
                    OrderDetailsID = y.OrderDetailsID,
                    count = y.ProductQuantity,
                    price = y.Price,
                    img = y.Product.ProductImg,
                    Status = y.Status,

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
                InvoiceNo = x.InvoiceNo,
                CreatTime = x.CreateTime.ToString(),
                Discount = (int)(x.LockPoint ?? 0),
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
            return (int)(order.LockPoint ?? 0);
        }
        public static void CreatOrder(string UserID, List<ProductModel> products)
        {

            DataBase data = new DataBase();
            Guid cusID = Guid.Parse(UserID);
            var addDetail = data.Order.FirstOrDefault(x => x.CustomerID == cusID);
            if (products.Count >= 1)
            {
                OrderDetails detail = new OrderDetails();
                detail.OrderDetailsID = Guid.NewGuid();
                detail.OrderID = addDetail.OrderID;
                for (int i = 0; i < products.Count(); i++)
                {
                    detail.ProductID = products[i].ProducId;
                    detail.ProductColor = "隨機";
                    detail.ProductSpec = "正常";
                    detail.ProductQuantity = products[i].count;
                    detail.Price = products[i].price;
                }
                data.OrderDetails.Add(detail);

                int res = data.SaveChanges();
                if (res != 0)
                {
                    MessageBox.Show("結帳成功");
                }
            }
        }

        public static void ChangeStatus(List<ProductModel> ReturnProducs)
        {
            DataBase data = new DataBase();
            var products = data.OrderDetails.Select(x => x.ProductID).ToList();
            foreach (var item in ReturnProducs)
            {
                if (products.Contains(item.ProducId))
                {
                    var product = data.OrderDetails.FirstOrDefault(x => x.ProductID == item.ProducId);
                    product.Status = "已退貨";
                }

            }
            data.SaveChanges();
        }
    }
}
