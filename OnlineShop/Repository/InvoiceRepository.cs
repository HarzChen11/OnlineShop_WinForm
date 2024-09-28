using OnlineShop.Models;
using OnlineShop.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static OnlineShop.Models.AllowanceModel;

namespace OnlineShop.Repository
{
    internal class InvoiceRepository
    {
        public static void UpDateInvoice(Guid Orderid, ResponseDataModel dataModel)
        {
            DataBase data = new DataBase();
            var order = data.Order.Where(x => x.OrderID == Orderid && x.PaymentStatus == "已付款").FirstOrDefault();
            order.InvoiceNo = dataModel.InvoiceNo;
            order.InvoiceDate = dataModel.InvoiceDate;
            order.InvoiceStatus = "首開發票";
            data.SaveChanges();

        }


        public static AllowanceData GetInvoiceFromUser(Guid Orderid)
        {
            DataBase data = new DataBase();
            var order = data.Order.Where(x => x.OrderID == Orderid && x.PaymentStatus == "已付款").FirstOrDefault();

            var allowanceData = new AllowanceData
            {
                InvoiceNo = order.InvoiceNo,
                InvoiceDate = DateTime.Parse(order.InvoiceDate).ToString("yyyy-MM-dd")
            };
            return allowanceData;

        }

        public static void CreatReIssueData()
        {

        }

    }

}
