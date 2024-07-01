using LogisticsControl;
using OnlineShop.Models;
using OnlineShop.Models.Entities;
using OnlineShop.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LogisticsControl
{
    public partial class Search : Form
    {
        public Search()
        {
            InitializeComponent();
        }


        private void Send_Button_Click(object sender, EventArgs e)
        {
            DataBase data = new DataBase();
            var list = data.Logistics.Where(x => x.Status == true && x.StatusUpdate == "已付款，待出貨").ToList();
            
            foreach (var item in list)
            {
                item.StatusUpdate = "已出貨";
            }
            data.SaveChanges();
        }

        private void Center_Button_Click(object sender, EventArgs e)
        {
            DataBase data = new DataBase();
            var list = data.Logistics.Where(x => x.Status == true && x.StatusUpdate == "已出貨").ToList();
            foreach (var item in list)
            {
                item.StatusUpdate = "已抵達物流中心";
            }

            data.SaveChanges();
        }

        private void Store_Button_Click(object sender, EventArgs e)
        {
            Dictionary<string,string> orderInfo = new Dictionary<string, string>();
            DataBase data = new DataBase();
            var list = data.Logistics.Where(x => x.Status == true && x.StatusUpdate == "已抵達物流中心").ToList();
          
            foreach (var item in list)
            {
                item.StatusUpdate = "已送至指定取貨點";
                orderInfo.Add(item.ReceiverCellPhone,item.OrderID.ToString());
            }
            data.SaveChanges();
            MailService.SendPickUpMail(orderInfo);
        }

        private void PickUp_Button_Click(object sender, EventArgs e)
        {
            DataBase data = new DataBase();
            var list = data.Logistics.Where(x => x.Status == true && x.StatusUpdate == "已送至指定取貨點").ToList();
            foreach (var item in list)
            {
                item.StatusUpdate = "已取貨";
            }
            data.SaveChanges();
        }

        private void UnPickUp_Click(object sender, EventArgs e)
        {
            DataBase data = new DataBase();
            var list = data.Logistics.Where(x => x.Status == true && x.StatusUpdate == "已抵達物流中心").ToList();
            foreach (var item in list)
            {
                item.StatusUpdate = "已取貨";
            }
            data.SaveChanges();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Guid OrderId = Guid.Parse(textBox1.Text);
            DataBase data = new DataBase();
            var item = data.Logistics.Where(x => x.OrderID == OrderId && x.Status == true).FirstOrDefault();
            label3.Text = item.StatusUpdate;
        }
    }
}
