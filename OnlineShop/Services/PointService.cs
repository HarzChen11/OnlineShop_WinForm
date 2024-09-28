
using OnlineShop.Models;
using OnlineShop.Models.Entities;
using OnlineShop.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Services
{
    internal class PointService
    {
        static List<PointModel> pointList = new List<PointModel>();


        public static List<PointModel> GetPointByUser()
        {
            Guid cusID = Guid.Parse(LoginState.CustomerID);
            pointList = PointRepository.GetPointByUser(cusID);
            return pointList;
        }

        // 取得未使用點數資料
        public static int GetPointTotal(string CustomerID)
        {
            Guid cusID = Guid.Parse(CustomerID);
            GetPointByUser();
            int PointTotal = pointList.Where(x => x.Used == true).Sum(x => x.Point);
            return PointTotal;
        }

        public static void CreatTradePoint(Guid OrderID,int Discount)
        {
            PointRepository.CreatPoint(OrderID, "消費獲得",Discount, "未使用");
            EventHandlers.RanderPoint();
        }

        public static string GetExpirePoint(Guid CustomerId)
        {
            pointList = PointRepository.GetPointByUser(CustomerId);
            int ExpiredTotal = 0;
            DateTime date = DateTime.Today;
            foreach (var points in pointList)
            {
                DateTime Expiredday;
                bool isValidDate = DateTime.TryParseExact(points.ExpireDate, "yyyy-MM-dd", null, System.Globalization.DateTimeStyles.None, out Expiredday);

                if (isValidDate && Expiredday.AddDays(-30) < date)
                {
                    ExpiredTotal += points.Point;
                }
            }
            return ExpiredTotal.ToString(); ;
        }

        public static List<PointsSystem> LockPoint(Guid CustomerId, int Discount)
        {
            List<PointsSystem> LockPoints = PointRepository.LockPoint(CustomerId, Discount);
            return LockPoints;
        }

        public static int CountDiscountPoint(Guid CustomerId, int Price)
        {
            int points = PointRepository.CountDiscountPoint(CustomerId, Price);
            return points;
        }

        public static void DeductionPoint(Guid OrderId, int deduct)
        {
            PointRepository.DeductionPoint(OrderId, deduct);
        }

        public static void ChangePointStatus(Guid CustomerID)
        {
            PointRepository.ChangePointStatus(CustomerID);
        }


    }
}
