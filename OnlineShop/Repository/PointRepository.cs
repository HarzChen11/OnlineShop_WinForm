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
    internal class PointRepository
    {
        static int totalLockPoint = 0;
        public static void CreatPoint(Guid orderId, string remark, int Discount, string status)
        {
            DataBase data = new DataBase();
            var ProductDetails = data.OrderDetails.Where(x => x.OrderID == orderId).ToList();
            foreach (var product in ProductDetails)
            {
                for (int i = 0; i < product.ProductQuantity; i++)
                {
                    PointsSystem point = PointFactory.CreatPoint(orderId, true, "消費獲得", "未使用", product.OrderDetailsID, null, product.Price, Discount);
                    data.PointsSystem.Add(point);
                }
            }
            data.SaveChanges();
        }

        //取得使用者所有的點數資料
        public static List<PointModel> GetPointByUser(Guid CustomerId)
        {
            DataBase data = new DataBase();
            List<PointModel> PointList = data.PointsSystem.Where(x => x.CustomerID == CustomerId).OrderBy(x => x.CreatDate).Select(x => new PointModel()
            {
                Point = x.Point,
                TradeName = x.PointRemark,
                CreatDate = x.CreatDate,
                ExpireDate = x.ExpireTime,
                Status = x.Status,
                Used = x.Used

            }).ToList();

            return PointList;
        }

        // 下訂單後轉付款同時鎖住該筆訂能折抵點數
        public static List<PointsSystem> LockPoint(Guid CustomerId, int Discount)
        {
            DataBase data = new DataBase();
            var LockPoints = data.PointsSystem.Where(x => x.CustomerID == CustomerId && x.Used == true).OrderBy(x => x.CreatDate).ToList() as List<PointsSystem>;
            int temp = 0;
            foreach (var point in LockPoints)
            {
                if (temp + point.Point <= totalLockPoint)
                {
                    temp += point.Point;
                    //point.Used = false;
                    point.Status = "已鎖定";
                    point.PointRemark = "消費折抵";
                }
            }

            var order = data.Order.Where(x => x.CustomerID == CustomerId && x.OrderID == OrderModel.OrderId).FirstOrDefault();
            order.LockPoint = Discount;
            data.SaveChanges();
            return LockPoints;
        }

        public static void UpdatePoint(Guid CustomerId, int Price)
        {
            DataBase data = new DataBase();
            int Points = data.PointsSystem.Where(x => x.CustomerID == CustomerId && x.Used == true).Sum(x => x.Point);
        }

        // 計算能折抵的點數
        public static int CountDiscountPoint(Guid CustomerId, int Price)
        {
            DataBase data = new DataBase();
            var userPoints = data.PointsSystem.Where(x => x.CustomerID == CustomerId && x.Used == true).OrderBy(x => x.CreatDate).ToList();
            List<PointsSystem> LockPoints = userPoints;
            totalLockPoint = 0;
            if (userPoints.Count() != 0)
            {
                foreach (var CountPoint in userPoints)
                {
                    if (totalLockPoint + CountPoint.Point <= Price)
                    {
                        totalLockPoint += CountPoint.Point;
                        if (Price - totalLockPoint == 0)
                        {
                            totalLockPoint -= CountPoint.Point;
                        }
                    }
                    else
                    {
                        break;
                    }
                }
            }
            return totalLockPoint;
        }

        public static void DeductionPoint(Guid OrderID, int deduct)
        {
            // 扣除上筆消費獲得的，並更改原先獲得的點數狀態
            DataBase data = new DataBase();
            var temp = data.PointsSystem.Where(x => x.OrderID == OrderID && x.Used == true).ToList();
            int total = temp.Sum(x => x.Point);
            foreach (var item in temp)
            {
                item.Used = false;
                item.Status = "已扣除";
                item.PointRemark = "已扣除";
                item.CreatDate = null;
                item.ExpireTime = null;
            }
            PointsSystem point = PointFactory.CreatPoint(OrderID, false, "已扣除", "退貨扣除",null, -deduct, 1, 1,null);

            // 要補上退貨該筆訂單總點數扣除退貨後剩餘的點數
            int Remaining = total - deduct;
            PointsSystem RemainingPoint = PointFactory.CreatPoint(OrderID, true, "未使用", "補回剩餘點數", null, Remaining, 1, 1);

            

            // 補回上筆消費扣除的
            int LockPoint = OrderService.FindLockPoint(OrderID);
            if (LockPoint != 0)
            {
                PointsSystem RepairPoint = PointFactory.CreatPoint(OrderID, true, "未使用", "退回上筆交易使用點數", null, LockPoint, 1, 1, null);
                data.PointsSystem.Add(RepairPoint);
            }

            data.PointsSystem.Add(point);
            data.PointsSystem.Add(RemainingPoint);
            data.SaveChanges();


        }
        public static int FindGetPoint(Guid OrderId)
        {
            DataBase data = new DataBase();
            var point = data.PointsSystem.Where(x => x.OrderID == OrderId).FirstOrDefault();
            return (int)point.Point;
        }
    }
}


