using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace StockControl
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            List<StockModel> Models = StockService.getStockList();
            foreach(var model in Models)
            {
                ProductStock productStock = new ProductStock(model);
                flowLayoutPanel1.Controls.Add(productStock);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<FollowModel> follows = FollowUpService.GetFollowList();
            MailService.FollowMail(follows);
        }

     
    }
}
