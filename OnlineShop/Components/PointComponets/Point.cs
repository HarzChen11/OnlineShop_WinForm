
using OnlineShop.Models;
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

namespace OnlineShop.Components.PointComponets
{
    public partial class Point : UserControl
    {
        public Point(PointModel pointModel)
        {
            InitializeComponent();

            label8.Text = pointModel.Point.ToString();
            label4.Text = pointModel.TradeName;
            label5.Text = pointModel.CreatDate;
            label6.Text = pointModel.ExpireDate;
        }

    }
}
