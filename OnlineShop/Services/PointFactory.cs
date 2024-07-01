using OnlineShop.Models;
using OnlineShop.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Services
{
    internal class PointFactory
    {
        public static PointsSystem CreatPoint(Guid OrderId,bool Used,string status, string remark, Guid? OrderDetailsID = null, int? points = null, int price = 1, int Discount = 1, string ExpireTime = null)
        {
            PointsSystem point = new PointsSystem();
            point.PointSystemID = Guid.NewGuid();
            point.OrderDetailsID = OrderDetailsID ?? null;
            point.OrderID = OrderId;
            if (points != null)
            {
                point.Point = (int)points;
            }
            else
            {
                point.Point = CountPoint((int)price, (int)Discount);
            }
            
            point.CustomerID = Guid.Parse(LoginState.CustomerID);
            point.Used = Used;
            point.Status = status;
            DateTime now = DateTime.Now;
            point.CreatDate = now.ToString("yyyy-MM-dd HH:mm:s");
            point.ExpireTime = now.AddMonths(3).ToString("yyyy-MM-dd");
            point.PointRemark = remark;
            return point;
        }

        public static int CountPoint(int price, int Discount)
        {
            double Price = price - Discount;
            int Point = (int)Math.Floor(Price / 30);
            return Point;
        } 
    }
}
