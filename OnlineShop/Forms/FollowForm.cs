﻿using OnlineShop.Models;
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
    public partial class FollowForm : Form
    {
        ProductModel model;
        public FollowForm(ProductModel model)
        {
            InitializeComponent();
            this.model = model;
        }

        private void Follow_Click(object sender, EventArgs e)
        {
            FollowService.CreatFollow(model.ProducId,Guid.Parse(LoginState.CustomerID),LoginState.Email);
            this.Close();
        }
    }
}
