using OnlineShop.Models;
using OnlineShop.Models.Entities;
<<<<<<< HEAD
using OnlineShop.Services;
using OnlineShop.Utility;
=======
>>>>>>> 8101e26593e1c25fcacf35b07ec8373dd546f8f2
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

<<<<<<< HEAD

        private void Register_Click(object sender, EventArgs e)
        {
=======
        Customer customer = new Customer();
        private void Register_Click(object sender, EventArgs e)
        {
            DataBase data = new DataBase();
>>>>>>> 8101e26593e1c25fcacf35b07ec8373dd546f8f2
            if (string.IsNullOrWhiteSpace(NameText.Text) ||
                string.IsNullOrWhiteSpace(PasswordText.Text) ||
                string.IsNullOrWhiteSpace(PhoneTtext.Text) ||
                string.IsNullOrWhiteSpace(AddressText.Text) ||
                string.IsNullOrWhiteSpace(CityText.Text) ||
                string.IsNullOrWhiteSpace(MailText.Text))
            {
                MessageBox.Show("請填上所有資料");
<<<<<<< HEAD
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
=======
            }
            else
            {
                customer.CustomerID = Guid.NewGuid();
                customer.Name = NameText.Text;
                customer.Password = PasswordText.Text;
                customer.Phone = PhoneTtext.Text;
                customer.Address = AddressText.Text;
                customer.City = CityText.Text;
                customer.Email = MailText.Text;
                checkInfo(customer);
                
            }
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


>>>>>>> 8101e26593e1c25fcacf35b07ec8373dd546f8f2
        }
    }
}
