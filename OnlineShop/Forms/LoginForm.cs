using OnlineShop.Models;
using OnlineShop.Models.Entities;
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
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
          
        }

     
        private void Login_Click(object sender, EventArgs e)
        {
            DataBase data = new DataBase();
            if (textBox1.Text != "" && textBox2.Text != "")
            {
                string account = textBox1.Text;
                string password = textBox2.Text;

                var user = data.Customer.FirstOrDefault(x => x.Phone == account);
                if (user != null)
                {
                    if(user.Password == password)
                    {
                        LoginState.SetLoginState(user);
                        MessageBox.Show("登入成功");
                        this.Close();
                        EventHandlers.Login(true);
                    }
                    else
                    {
                        MessageBox.Show("帳號或密碼錯誤");
                    }
                }
                else
                {
                    MessageBox.Show("請先註冊會員");
                }
            }
            else
            {
                MessageBox.Show("請輸入帳號密碼");
            }
                
        }
    }
}
