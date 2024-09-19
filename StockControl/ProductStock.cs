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
        public ProductStock(StockModel stockModel)
        {
            InitializeComponent();
            this.stockModel = stockModel;
            label1.Text = stockModel.ProductName;
            label2.Text = stockModel.ProductQuantity.ToString();
            label3.Text = stockModel.ProductSafeQuantity.ToString();
        }
    }
}
