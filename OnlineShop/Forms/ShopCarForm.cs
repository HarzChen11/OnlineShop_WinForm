<<<<<<< HEAD
﻿
using OnlineShop.Components.MenuBarComponent;
=======
﻿using OnlineShop.Components.MenuBarComponent;
>>>>>>> 8101e26593e1c25fcacf35b07ec8373dd546f8f2
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
<<<<<<< HEAD
=======
       
     
>>>>>>> 8101e26593e1c25fcacf35b07ec8373dd546f8f2
        public ShopCarForm()
        {
            InitializeComponent();

<<<<<<< HEAD
            //MenuBar bar = MenuBar.GetMenuBar;
            //bar.button1.Enabled = false;
            //bar.Location = new Point(478, 11);
            //this.Controls.Add(bar);

            EventHandlers.Login(true);
            EventHandlers.randerCar += EventHandlers_randerCar;
            List<ProductModel> modles = CarService.GetProductList();
=======
            MenuBar bar = MenuBar.GetMenuBar;
            bar.button1.Enabled = false;
            bar.Location = new Point(478, 11);
            this.Controls.Add(bar);

            EventHandlers.Login(true);
            EventHandlers.randerCar += EventHandlers_randerCar;
            List<ProductModel> modles = CartService.getList();
>>>>>>> 8101e26593e1c25fcacf35b07ec8373dd546f8f2

            foreach (var model in modles)
            {
                ProductInCar car = new ProductInCar(model);
                flowLayoutPanel1.Controls.Add(car);
            }
        }


        private void EventHandlers_randerCar(object sender, EventArgs e)
        {
            flowLayoutPanel1.Controls.Clear();
<<<<<<< HEAD

            List<ProductModel> models = CarService.GetProductList();
=======
            List<ProductModel> models = CartService.getList();
>>>>>>> 8101e26593e1c25fcacf35b07ec8373dd546f8f2
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
