using OnlineShop.Components.MenuBarComponent;
using OnlineShop.Components.ShopCarComponent;
using OnlineShop.Models;
using OnlineShop.Models.Entities;
using OnlineShop.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OnlineShop.Forms
{
    public partial class OrderForm : Form
    {
        List<ProductModel> products = CarService.GetProductList();
        string payInfo;
        public OrderForm()
        {
            InitializeComponent();
            DataBase data = new DataBase();


            //var delivers = data.Deliver.Select(x => new KeyValueModel()
            //{
            //    Value = x.DeliverID,
            //    Key = x.Translation
            //}).ToList();
            //Deliver_comboBox.DataSource = delivers;
            //Deliver_comboBox.DisplayMember = "Key";
            //Deliver_comboBox.ValueMember = "Value";

            MenuBar bar = MenuBar.GetMenuBar;
            bar.button1.Enabled = false;
            bar.Location = new Point(88, 11);
            this.Controls.Add(bar);
            EventHandlers.Login(true);

            //List<ProductModel> products = CarService.GetProductList();
            foreach (var product in products)
            {
                ProductInCar car = new ProductInCar(product);
                car.numericUpDown1.Enabled = false;
                car.button1.Visible = false;
                flowLayoutPanel1.Controls.Add(car);
            }
            this.label6.Text = products.Sum(x => x.price * x.count).ToString();
            this.label8.Text = PointService.CountDiscountPoint(Guid.Parse(LoginState.CustomerID), int.Parse(label6.Text)).ToString();
            int total = int.Parse(label6.Text) - int.Parse(label8.Text);
            this.total_LB.Text = Math.Abs(total).ToString(); //維持正數
        }


        private void CheckOut(object sender, EventArgs e)
        {
            OrderModel orderModel = new OrderModel(Name_textBox.Text, Phone_textBox.Text, int.Parse(total_LB.Text));
            OrderModel.OrderId = Guid.NewGuid();
            orderModel.Products = CarService.GetProductList();

            if (string.IsNullOrWhiteSpace(Name_textBox.Text) ||
                string.IsNullOrWhiteSpace(Phone_textBox.Text))
            {
                MessageBox.Show("請填上所有資料");
            }
            else
            {
                payInfo = CheckOutService.BeforePay(orderModel, int.Parse(total_LB.Text), products);

                string html = LogisticsService.CreateLogistics(orderModel);
                LogisticsForm logisticsForm = new LogisticsForm(html);
                logisticsForm.FormClosed += LogisticsForm_FormClosed;
                logisticsForm.Show();
            }
        }

        private void LogisticsForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            PayForm payForm = new PayForm(payInfo, int.Parse(label8.Text));
                payForm.Show();
        }

        private void BackToCar(object sender, EventArgs e)
        {
            this.Hide();
            MenuBar.shopCarForm.Show();
        }

        private void CloseCar(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }


    }
}
