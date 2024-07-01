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
        public OrderForm()
        {
            InitializeComponent();
            DataBase data = new DataBase();
            var delivers = data.Deliver.Select(x => new KeyValueModel()
            {
                Value = x.DeliverID,
                Key = x.Translation
            }).ToList();
            comboBox1.DataSource = delivers;
            comboBox1.DisplayMember = "Key";
            comboBox1.ValueMember = "Value";

            MenuBar bar = MenuBar.GetMenuBar;
            bar.button1.Enabled = false;
            bar.Location = new Point(478, 11);
            this.Controls.Add(bar);
            EventHandlers.Login(true);

            List<ProductModel> products = CartService.getList();
            foreach (var product in products)
            {
                ProductInCar car = new ProductInCar(product);
                car.numericUpDown1.Enabled = false;
                car.button1.Visible = false;
                flowLayoutPanel1.Controls.Add(car);
            }

            this.label6.Text = products.Sum(x => x.price * x.count).ToString();
        }

     

        private void CheckOut(object sender, EventArgs e)
        {
            string OrderId = Guid.NewGuid().ToString();
            OrderModel orderModal = new OrderModel(OrderId, textBox1.Text, textBox2.Text, comboBox1.Text, textBox4.Text);

            DataBase data = new DataBase();
            if (string.IsNullOrWhiteSpace(textBox1.Text) ||
                string.IsNullOrWhiteSpace(textBox2.Text) ||
                string.IsNullOrWhiteSpace(comboBox1.Text) ||
                string.IsNullOrWhiteSpace(textBox4.Text))
            {
                MessageBox.Show("請填上所有資料");
            }
            else
            {
                Guid cusID = Guid.Parse(LoginState.CustomerID);
                var Carinfo = data.Trolley.FirstOrDefault(x => x.Customer == cusID && x.OrderStatus == false);
                if (Carinfo != null)
                {
                    Carinfo.OrderStatus = true;
                    Order order = new Order();
                    order.OrderID = Guid.Parse(orderModal.OrderId);
                    order.CustomerID = Guid.Parse(LoginState.CustomerID);
                    order.OrderNumber = DateTime.Now.ToString("ODyyMMddHHmm");
                    order.PaymentStatus = "已付款";
                    order.Deliver = (Guid)comboBox1.SelectedValue;
                    order.Ordering = "待出貨";
                    order.CreateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    order.TrolleyID = Guid.NewGuid();
                    data.Order.Add(order);
                    int res = data.SaveChanges();
                    if (res != 0)
                    {
                        MessageBox.Show("新增成功");
                        this.Close();
                        Form form = new Form();
                        EventHandlers.Login(true);


                        OrderService.ServiceCreatOrder();
                    }

                }
                else
                {
                    MessageBox.Show("新增失敗");
                }


            }



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
