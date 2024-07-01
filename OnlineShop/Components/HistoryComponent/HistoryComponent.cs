using OnlineShop.Components.ShopCarComponent;
using OnlineShop.Forms;
using OnlineShop.Models;
using OnlineShop.Models.Entities;
using OnlineShop.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OnlineShop.Components
{
    public partial class HistoryComponent : UserControl
    {
        BoughtOrderModel boughtOrder;
        public HistoryComponent(BoughtOrderModel boughtOrder)
        {
            InitializeComponent();
            this.boughtOrder = boughtOrder;
            this.CreatDay_Lb.Text = boughtOrder.CreatTime;
            int total = 0;

            foreach (var item in boughtOrder.Details)
            {
                label3.Text = boughtOrder.OrderNumber;
                total = (item.price * item.count);
                
            }

            this.Total_Lb.Text = (total- int.Parse(boughtOrder.Discount)).ToString();
        }


        private void MoreInfo_Click(object sender, EventArgs e)
        {
            flowLayoutPanel1.Visible = !flowLayoutPanel1.Visible;

            this.Size = flowLayoutPanel1.Visible ? new Size(895, 482) : new Size(895, 90);
            flowLayoutPanel1.AutoScroll = true;
        }


        public static ReturnForm form = null;
        private void Return_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            
            button.Tag = boughtOrder.OrderNumber;
            if (form == null || form.IsDisposed)
            {
                form = new ReturnForm(boughtOrder.OrderID, boughtOrder.OrderNumber);
            }
            else
            {
                // 點選不同申請退貨，重新載入商品
                form.LoadData(button.Tag.ToString());
            }

            form.Show();
        }
    }
}
