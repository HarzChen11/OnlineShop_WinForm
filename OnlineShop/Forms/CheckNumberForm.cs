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

namespace OnlineShop.Forms
{
    public partial class CheckNumberForm : Form
    {
        string PassWord;
        Guid CustomerID;
        public CheckNumberForm(Guid CustomerID, string PassWord)
        {
            InitializeComponent();
            this.PassWord = PassWord;
            this.CustomerID = CustomerID;
        }

        private void CheckPassword(object sender, EventArgs e)
        {
            DataBase data = new DataBase();
            if (this.textBox1.Text == PassWord)
            {
                var user = data.Customer.FirstOrDefault(x => x.CustomerID == CustomerID && x.IsActive == false);
                MessageBox.Show("驗證碼正確，註冊成功");
                bool CheckPassword = RegisterService.ServiceAccountActivation(user.CustomerID);
                EventHandlers.Login(true);
                this.Close();
            }
            else
            {
                MessageBox.Show("驗證碼錯誤");
            }
            
        }
    }
}
