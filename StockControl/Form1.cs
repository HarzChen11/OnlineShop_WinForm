using StockControl.Service;
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
            flowLayoutPanel1.Controls.Clear();
            EventHandlers.randerPanel += ProductStock_RanderPanel;

            List<StockModel> Models = StockService.getStockList();
            RabbitMQService.CreatConnection(flowLayoutPanel1, Models);

            CreatProductStock(Models);
        }

        private void ProductStock_RanderPanel(object sender, List<StockModel> e)
        {
            flowLayoutPanel1.Controls.Clear();
            CreatProductStock(e);
        }

        private void CreatProductStock(List<StockModel> Models)
        {
            foreach (var model in Models)
            {
                ProductStock productStock = new ProductStock(model);

                flowLayoutPanel1.Controls.Add(productStock);
            }

        }
    }
}
