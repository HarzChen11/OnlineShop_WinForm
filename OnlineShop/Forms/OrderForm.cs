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
<<<<<<< HEAD
        List<ProductModel> products = CarService.GetProductList();
        string payInfo;
=======
>>>>>>> 8101e26593e1c25fcacf35b07ec8373dd546f8f2
        public OrderForm()
        {
            InitializeComponent();
            DataBase data = new DataBase();
<<<<<<< HEAD


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
=======
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
>>>>>>> 8101e26593e1c25fcacf35b07ec8373dd546f8f2
            foreach (var product in products)
            {
                ProductInCar car = new ProductInCar(product);
                car.numericUpDown1.Enabled = false;
                car.button1.Visible = false;
                flowLayoutPanel1.Controls.Add(car);
            }
<<<<<<< HEAD
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
=======

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
>>>>>>> 8101e26593e1c25fcacf35b07ec8373dd546f8f2
            {
                MessageBox.Show("請填上所有資料");
            }
            else
            {
<<<<<<< HEAD
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
=======
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



>>>>>>> 8101e26593e1c25fcacf35b07ec8373dd546f8f2
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
<<<<<<< HEAD


=======
>>>>>>> 8101e26593e1c25fcacf35b07ec8373dd546f8f2
    }
}
