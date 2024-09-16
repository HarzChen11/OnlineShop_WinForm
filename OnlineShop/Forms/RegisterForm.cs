using OnlineShop.Models;
using OnlineShop.Models.Entities;
using OnlineShop.Services;
using OnlineShop.Utility;
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
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();

        }


        private void Register_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(NameText.Text) ||
                string.IsNullOrWhiteSpace(PasswordText.Text) ||
                string.IsNullOrWhiteSpace(PhoneTtext.Text) ||
                string.IsNullOrWhiteSpace(AddressText.Text) ||
                string.IsNullOrWhiteSpace(CityText.Text) ||
                string.IsNullOrWhiteSpace(MailText.Text))
            {
                MessageBox.Show("請填上所有資料");
                return;
            }

            RegisterModel registerModel = new RegisterModel(NameText.Text, PasswordText.Text, PhoneTtext.Text, AddressText.Text, CityText.Text, MailText.Text);
            var result = RegisterService.CreatCustomer(registerModel);
            if (result == (null, null))
            {
                MessageBox.Show("此郵箱已註冊過，請更換郵箱進行註冊或使用原有帳號進行登入");
                return;
            }
            CheckNumberForm numberForm = new CheckNumberForm(result.Item1.CustomerID, result.Item2);
            numberForm.ShowDialog();
            this.Close();

        }

        private void checkInfo(Customer customer)
        {

            DataBase data = new DataBase();
            var CheckPhone = data.Customer.FirstOrDefault(x => x.Phone == PhoneTtext.Text);
            if (CheckPhone != null)
            {
                MessageBox.Show("此門號已註冊過");
            }
            else
            {
                data.Customer.Add(customer);

                int res = data.SaveChanges();
                if (res != 0)
                {
                    MessageBox.Show("新增成功");
                    LoginState.SetLoginState(customer);
                    Console.WriteLine(LoginState.CustomerID.ToString());
                    this.Close();
                    Form form = new Form();
                    EventHandlers.Login(true);
                }
                else
                {
                    MessageBox.Show("新增失敗");
                }
            }
        }
    }
}
