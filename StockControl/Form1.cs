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
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<FollowModel> follows = FollowUpService.GetFollowList();
            MailService.FollowMail(follows);
        }
    }
}
