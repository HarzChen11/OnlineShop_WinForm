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
<<<<<<< HEAD
            EventHandlers.randerPoint += EventHandlers_randerPoint;
            this.ProductLabel.Text = CarService.GetTotal.ToString();
        }


=======
            this.label1.Text = CartService.getTotal.ToString();
        }

       
>>>>>>> 8101e26593e1c25fcacf35b07ec8373dd546f8f2

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

<<<<<<< HEAD


        private void EventHandlers_randerPoint(object sender, EventArgs e)
        {
            PointLabel.Text = PointService.GetPointTotal(LoginState.CustomerID).ToString();
        }

        private void EventHandlers_AddToCar(object sender, int total)
        {
            //this.productList = productList;
            ProductLabel.Text = total.ToString();
        }

        // 切換登入/登出的介面顯示
        private void EventHandlers_IsLogin(object sender, bool e)
        {
            button1.Visible = e;
            ProductLabel.Text = CarService.GetTotal.ToString();
            button3.Visible = !e;
            button2.Text = e ? "登出" : "登入";
            ProductLabel.Visible = e;
            var list = CarService.GetProductList();
            string total = list.Sum(x=>x.count).ToString();
            ProductLabel.Text = total;
            label2.Visible = e;
            label3.Visible = e;
            PointLabel.Visible = e;
            PointLabel.Text = PointService.GetPointTotal(LoginState.CustomerID).ToString();
            button4.Visible = e;
            HistoryBT.Visible = e;
        }

=======
       


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

    

>>>>>>> 8101e26593e1c25fcacf35b07ec8373dd546f8f2
        static Form regForm = null;
        private void Register_Click(object sender, EventArgs e)
        {
            if (regForm == null)
            {
                regForm = new RegisterForm();
<<<<<<< HEAD
=======
                regForm.Show();
>>>>>>> 8101e26593e1c25fcacf35b07ec8373dd546f8f2
            }
            else
            {
                regForm = null;
            }
<<<<<<< HEAD
            regForm.Show();
=======
>>>>>>> 8101e26593e1c25fcacf35b07ec8373dd546f8f2

        }

        static Form LoginForm = null;
        private void OpenLogin(object sender, EventArgs e)
        {
<<<<<<< HEAD
            //bool check = EventHandlers.getLoginState();
            //if (check == true)
            //{
            if (LoginForm == null)
            {
                LoginForm = new LoginForm();
                LoginForm.Show();
            }
            //}
            else
            {
                EventHandlers.Login(false);
                LoginForm = null;
            }
        }

        static Form PointForm = null;
        private void PointForm_Click(object sender, EventArgs e)
        {
            if (PointForm == null)
            {
                PointForm = new PointForm();
                PointForm.Show();
            }
            else
            {
                PointForm = null;
            }

        }

        static Form HistoryForm = null;
        private void HistoryBT_Click(object sender, EventArgs e)
        {
            if (HistoryForm == null)
            {
                HistoryForm = new HistoryForm();
                HistoryForm.Show();
            }
            else
            {
                HistoryForm = null;
            }
        }
=======
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

       
>>>>>>> 8101e26593e1c25fcacf35b07ec8373dd546f8f2
    }
}

