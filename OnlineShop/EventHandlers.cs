using OnlineShop.Models;
using OnlineShop.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OnlineShop
{
    internal class EventHandlers
    {
        public static event EventHandler<bool> IsLogin;
        public static event EventHandler<int> AddToCar;
        public static event EventHandler randerCar;
        public static event EventHandler randerPoint;

        // 判斷登入狀態
        private static bool LoginState;
        public static void Login(bool login)
        {
            LoginState = login;
            IsLogin.Invoke(null, login);
        }
        public static bool getLoginState()
        {
            return LoginState;
        }


        //點擊加入購物車後將商品存入ProductModel
        public static void AddItem(int total)
        {
            AddToCar?.Invoke(null, total);
        }

        // 更新購物車顯示的商品
        public static void RanderCar()
        {
            randerCar?.Invoke(null, null);
        }

        // 更新總點數的顯示
        public static void RanderPoint()
        {
            randerPoint?.Invoke(null, null);
        }
    }
}

