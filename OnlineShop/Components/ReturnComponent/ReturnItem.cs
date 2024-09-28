using OnlineShop.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OnlineShop.Components.ReturnComponent
{
    public partial class ReturnItem : UserControl
    {
        ProductModel product;
        public event EventHandler<itemModel> Checked;
        public event EventHandler<itemModel> QtyChange;

        public bool SelectedItem
        {
            get
            {
                return checkBox1.Checked;
            }
        }

        public int Quantity
        {
            get { return (int)numericUpDown1.Value; }
        }


        public ReturnItem(ProductModel product)
        {
            InitializeComponent();
            this.product = product;
            label1.Text = product.Status;
            checkBox1.Text = product.name;
            numericUpDown1.Minimum = 1;
            numericUpDown1.Maximum = product.count;
            numericUpDown1.ValueChanged += NumericUpDown1_ValueChanged;
            if (label1.Text == "已退貨")
            {
                checkBox1.Enabled = false;
                checkBox1.ForeColor = Color.Red;
                numericUpDown1.Enabled = false;
            }
        }

        itemModel Model = new itemModel();
        private void NumericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            if (SelectedItem == true)
            {
                Model.product = product;
                Model.Qty = Quantity;
                QtyChange?.Invoke(this, Model);
            }    
        }

        
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox checkBox = (CheckBox)sender;

            Model.product = product;
            Model.Qty = Quantity;

            Checked.Invoke(this, Model);

        }



        public class itemModel
        {
            public ProductModel product;
            public int Qty;
        }
    }
}
