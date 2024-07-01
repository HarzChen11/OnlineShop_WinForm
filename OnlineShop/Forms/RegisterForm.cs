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
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();

        }

        Customer customer = new Customer();
        private void Register_Click(object sender, EventArgs e)
        {
            DataBase data = new DataBase();
            if (string.IsNullOrWhiteSpace(NameText.Text) ||
                string.IsNullOrWhiteSpace(PasswordText.Text) ||
                string.IsNullOrWhiteSpace(PhoneTtext.Text) ||
                string.IsNullOrWhiteSpace(AddressText.Text) ||
                string.IsNullOrWhiteSpace(CityText.Text) ||
                string.IsNullOrWhiteSpace(MailText.Text))
            {
                MessageBox.Show("請填上所有資料");
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


        }
    }
}
