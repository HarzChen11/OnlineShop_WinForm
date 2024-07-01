using OnlineShop.Models.Entities;
using OnlineShop.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OnlineShop.Models;
using OnlineShop.Components.PointComponets;

namespace OnlineShop.Forms
{
    public partial class PointForm : Form
    {
        List<PointModel> PointModel;
        public PointForm()
        {
            InitializeComponent();
            
            DataBase data = new DataBase();
            PointModel = PointService.GetPointByUser();
            AddBT.Enabled = false;
            AddBT_Click(AddBT, null);
            label3.Text = PointService.GetPointTotal(LoginState.CustomerID).ToString();
            label4.Text = PointService.GetExpirePoint(Guid.Parse(LoginState.CustomerID));
            
        }

        private void PointInfoCreat(List<PointModel> models)
        {
            flowLayoutPanel1.Controls.Clear();
            foreach (var PointInfo in models)
            {
                Point point = new Point(PointInfo);
                flowLayoutPanel1.Controls.Add(point);
            }
        }

        private void ReduceBT_Click(object sender, EventArgs e)
        {
            Button ReduceBT = (Button)sender;
            ReduceBT.Enabled = false;
            AddBT.Enabled = true;
            var ReduceList = PointModel.Where(x => x.Used == false).ToList() as List<PointModel>;
            PointInfoCreat(ReduceList);
        }

        private void AddBT_Click(object sender, EventArgs e)
        {
            Button AddBT = (Button)sender;
            AddBT.Enabled = false;
            ReduceBT.Enabled = true;
            var AddList = PointModel.Where(x => x.Used == true).ToList() as List<PointModel>;
            PointInfoCreat(AddList);
        }
    }
}
