using OnlineShop.Components;
using OnlineShop.Components.ShopCarComponent;
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

namespace OnlineShop.Forms
{
    public partial class HistoryForm : Form
    {
        public HistoryForm()
        {
            InitializeComponent();
            List<BoughtOrderModel> boughtOrders = OrderService.GetBoughtListByUser(Guid.Parse(LoginState.CustomerID));

            string tempDate = null;
            HistoryComponent historyComponent = null;

            foreach (var history in boughtOrders)
            {
                if (tempDate != history.CreatTime)
                {
                    historyComponent = new HistoryComponent(history);
                    flowLayoutPanel1.Controls.Add(historyComponent);
                    tempDate = history.CreatTime;
                }

                foreach (var product in history.Details)
                {
                    ProductInCar productInCar = new ProductInCar(product);
                    foreach (var control in historyComponent.Controls)
                    {
                        if (control is FlowLayoutPanel panel)
                        {
                            panel.Controls.Add(productInCar);
                        }
                    }
                }
            }
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
