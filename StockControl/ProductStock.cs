using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StockControl
{
    public partial class ProductStock : UserControl
    {
        public StockModel stockModel;

        EventHandlers handlers = new EventHandlers();
        public ProductStock(StockModel stockModel)
        {
            InitializeComponent();


            this.stockModel = stockModel;
            label1.Text = stockModel.ProductName;
            label2.Text = stockModel.ProductQuantity.ToString();
            label3.Text = stockModel.ProductSafeQuantity.ToString();
            label4.Text = stockModel.Status;
            label5.Text = (stockModel.ProductSafeQuantity - stockModel.ProductQuantity).ToString();
            button1.Tag = this;
            button2.Tag = this;
            //EventHandlers handlers = new EventHandlers();
            handlers.randerStatus += ProductStock_randerStatus;



        }

        private void ProductStock_randerStatus(object sender, StockModel e)
        {
            label2.Text = e.ProductQuantity.ToString();
            label4.Text = e.Status;
        }

        // 更新庫存表中的商品狀態
        private void Ordered_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            ProductStock productStock= (ProductStock)button.Tag;
            StockModel stock = StockService.Ordered(stockModel);
            button1.Enabled = false;
            button2.Enabled = true;

            handlers.RanderStatus(productStock, stock);
        }

        // 更新庫存表中的商品狀態及更新stock、product的數量
        private void ReStock_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            ProductStock productStock = (ProductStock)button.Tag;
            StockModel stock = StockService.ReStock(stockModel);
            button2.Enabled = false;
            button3.Enabled = true;

            handlers.RanderStatus(productStock, stock);
        }

        // 發送已補貨通知，並移除叫貨表
        private void Notify_Click(object sender, EventArgs e)
        {
            List<StockModel> NewStock = FollowUpService.SendNotify(stockModel);
            EventHandlers.RanderPanel(NewStock);

        }
    }
}
