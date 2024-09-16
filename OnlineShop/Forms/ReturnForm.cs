using OnlineShop.Components;
using OnlineShop.Components.ReturnComponent;
using OnlineShop.Models;
using OnlineShop.Models.Enums;
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
using static OnlineShop.Components.ReturnComponent.ReturnItem;

namespace OnlineShop.Forms
{
    public partial class ReturnForm : Form
    {
        List<BoughtOrderModel> list;
        string orderId;

        public ReturnForm(string OrderId, string OrderNumber)
        {
            InitializeComponent();
            this.orderId = OrderId;
            label3.Text = OrderNumber;
            list = OrderService.GetBoughtListByUser(Guid.Parse(LoginState.CustomerID), Guid.Parse(orderId));

            foreach (var order in list)
            {
                creatItem(order.Details);
            }

        }


        private void creatItem(List<ProductModel> list)
        {
            flowLayoutPanel1.Controls.Clear();
            foreach (var order in list)
            {
                ReturnItem returnItem = new ReturnItem(order);
                returnItem.Checked += ReturnItem_Checked;
                returnItem.QtyChange += ReturnItem_Checked;
                flowLayoutPanel1.Controls.Add(returnItem);
            }
        }


        List<ProductModel> ReturnProduc = new List<ProductModel>();
        List<itemModel> Product = new List<itemModel>();
        private void ReturnItem_Checked(object sender, itemModel model)
        {
            ReturnItem item = sender as ReturnItem;
            if (item.SelectedItem)
            {
                ReturnProduc.Add(model.product);
                Product.Add(model);
            }
            else
            {
                ReturnProduc.Remove(model.product);
                Product.Remove(model);
            }
            UpdateLabels(Product);
        }

        private void UpdateLabels(List<itemModel> Product)
        {

            label8.Text = OrderService.FindLockPoint(Guid.Parse(orderId)).ToString();
            label6.Text = CalculateTotalPrice(Product).ToString();
            label2.Text = Math.Floor(decimal.Parse(label6.Text) / 30).ToString();

        }


        private int CalculateTotalPrice(List<itemModel> Product)
        {
            int total = 0;
            foreach (var item in Product)
            {
                total += item.product.price * item.Qty;

            }
            return total;
        }

        public void LoadData(string orderNumber)
        {
            list = OrderService.GetBoughtListByUser(Guid.Parse(LoginState.CustomerID), orderNumber);
            foreach (var order in list)
            {
                creatItem(order.Details);
            }
            label3.Text = orderNumber;
        }

        private void Return_Click(object sender, EventArgs e)
        {
            ReturnModel returnModel = LogisticsService.GetLogisticsID(Guid.Parse(orderId));
            returnModel.Price = int.Parse(label6.Text);
            // 選擇逆物流Api
            string url = ReturnService.FindUrl(returnModel.LogisticsSubType);
            ReturnService.CreateReturn(returnModel, url);

            // 發票折讓
            InvoiceService.CreatAllowance(Guid.Parse(orderId), int.Parse(label6.Text), ReturnProduc);

            PointService.DeductionPoint(Guid.Parse(orderId), int.Parse(label2.Text));
            EventHandlers.RanderPoint();
        }
    }
}