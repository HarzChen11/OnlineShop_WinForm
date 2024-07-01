using OnlineShop.Components.MenuBarComponent;
using OnlineShop.Components.ShopCarComponent;
using OnlineShop.Models;
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
    public partial class ShopCarForm : Form
    {
       
     
        public ShopCarForm()
        {
            InitializeComponent();

            MenuBar bar = MenuBar.GetMenuBar;
            bar.button1.Enabled = false;
            bar.Location = new Point(478, 11);
            this.Controls.Add(bar);

            EventHandlers.Login(true);
            EventHandlers.randerCar += EventHandlers_randerCar;
            List<ProductModel> modles = CartService.getList();

            foreach (var model in modles)
            {
                ProductInCar car = new ProductInCar(model);
                flowLayoutPanel1.Controls.Add(car);
            }
        }


        private void EventHandlers_randerCar(object sender, EventArgs e)
        {
            flowLayoutPanel1.Controls.Clear();
            List<ProductModel> models = CartService.getList();
            foreach(var item in models)
            {
                ProductInCar car = new ProductInCar(item);
                flowLayoutPanel1.Controls.Add(car);
            }
        }

        private void CloseCar(object sender, FormClosingEventArgs e)
        {
            e.Cancel=true;
            this.Hide();
            //this.Dispose(true);
            //GC.Collect();
        }


        private void GetOrder(object sender, EventArgs e)
        {
            this.Hide();
            Form OrderForm = new OrderForm();
            OrderForm.Show();
        }
    }
}
