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
<<<<<<< HEAD
        public static event EventHandler randerPoint;
=======
       
>>>>>>> 8101e26593e1c25fcacf35b07ec8373dd546f8f2

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

<<<<<<< HEAD
        // 更新購物車顯示的商品
=======
>>>>>>> 8101e26593e1c25fcacf35b07ec8373dd546f8f2
        public static void RanderCar()
        {
            randerCar?.Invoke(null, null);
        }
<<<<<<< HEAD

        // 更新總點數的顯示
        public static void RanderPoint()
        {
            randerPoint?.Invoke(null, null);
        }
=======
>>>>>>> 8101e26593e1c25fcacf35b07ec8373dd546f8f2
    }
}

