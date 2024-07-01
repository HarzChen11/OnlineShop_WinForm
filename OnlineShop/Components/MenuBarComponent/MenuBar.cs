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

namespace OnlineShop.Components.MenuBarComponent
{
    public partial class MenuBar : UserControl
    {
        private static MenuBar instance;
        public static MenuBar GetMenuBar
        {
            get
            {
                if (instance == null)
                {
                    instance = new MenuBar();
                }
                return instance;
            }
        }


        public MenuBar()
        {
            InitializeComponent();
            EventHandlers.IsLogin += EventHandlers_IsLogin;
            EventHandlers.AddToCar += EventHandlers_AddToCar;
            this.label1.Text = CartService.getTotal.ToString();
        }

       

        public static ShopCarForm shopCarForm;
        private void OpenCar(object sender, EventArgs e)
        {
            //bool temp = shopCarForm.Disposing;
            if (shopCarForm == null || shopCarForm.IsDisposed)
            {
                shopCarForm = new ShopCarForm();
            }
            shopCarForm.Show();
        }

       


        private void EventHandlers_AddToCar(object sender, int total)
        {
            //this.productList = productList;
            label1.Text = total.ToString();
        }



        private void EventHandlers_IsLogin(object sender, bool e)
        {
            if (e == true)
            {
                button1.Visible = true;
                button3.Visible = false;
                button2.Text = "登出";
                label1.Visible = true;
                CartService service = new CartService();
                label1.Text = CartService.getTotal.ToString();

            }
        }

    

        static Form regForm = null;
        private void Register_Click(object sender, EventArgs e)
        {
            if (regForm == null)
            {
                regForm = new RegisterForm();
                regForm.Show();
            }
            else
            {
                regForm = null;
            }

        }

        static Form LoginForm = null;
        private void OpenLogin(object sender, EventArgs e)
        {
            if (LoginForm == null)
            {
                LoginForm = new LoginForm();
            }
            else
            {
                LoginForm = null;
            }
            LoginForm.Show();
        }

       
    }
}

