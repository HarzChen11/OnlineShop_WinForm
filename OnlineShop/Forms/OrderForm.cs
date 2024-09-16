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
        OrderModel orderModel;
        public OrderForm()
        {
            InitializeComponent();
            DataBase data = new DataBase();

            MenuBar bar = MenuBar.GetMenuBar;
            bar.button1.Enabled = false;
            bar.Location = new Point(88, 11);
            this.Controls.Add(bar);
            EventHandlers.Login(true);




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
            this.label6.Text = Math.Abs(total).ToString(); //維持正數
        }


        private void CheckOut(object sender, EventArgs e)
        {
            orderModel = new OrderModel(Name_textBox.Text, Phone_textBox.Text, int.Parse(label6.Text));
            OrderModel.OrderId = Guid.NewGuid();
            orderModel.Products = CarService.GetProductList();

            if (string.IsNullOrWhiteSpace(Name_textBox.Text) || string.IsNullOrWhiteSpace(Phone_textBox.Text))
            {
                MessageBox.Show("請填入收件姓名、手機");
            }
            else
            {
                string html = LogisticsService.CreateLogistics(orderModel);
                LogisticsForm logisticsForm = new LogisticsForm(html);
                logisticsForm.FormClosed += LogisticsForm_FormClosed;
                logisticsForm.Show();
                int total = int.Parse(label6.Text);
                payInfo = CheckOutService.BeforePay(orderModel, total, products);
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

   
    }
}
  

      