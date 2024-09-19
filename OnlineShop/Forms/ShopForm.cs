using OnlineShop.Components.MenuBarComponent;
using OnlineShop.Components.PagenationComponent;
using OnlineShop.Components.ProductComponent;
using OnlineShop.Components.ShopCarComponent;
using OnlineShop.Forms;
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

namespace OnlineShop
{
    public partial class ShopForm : Form
    {
        static DataBase data = new DataBase();
        List<Product> products = null;


        public ShopForm()
        {
            InitializeComponent();
            products = data.Product.ToList();
            pagenation1.TotalCount = products.Count;
            pagenation1.ChangedPage += ChangePageClick;
            //products = data.Product.ToList();
            var list = products.Take(6).ToList();
            creatProduct(list);

            // 執行自動化偵測庫存
            TaskService.StartCheckingAsync();
        }


        private void ChangePageClick(object sender, int e)
        {
            var list = products.Skip((e-1)*6).Take(6).ToList();
            //Console.WriteLine(e.ToString());
            creatProduct(list);
        }

        private void ProductViewClick(object sender, EventArgs e)
        {
            ProductView view = (ProductView)sender;

            ProductDetail productDetail = new ProductDetail((Product)view.Tag);
            productDetail.Show();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            flowLayoutPanel1.Controls.Clear();
            string text = textBox1.Text;
            var srarchList = products.Where(x => x.ProductName.Contains(text)).ToList();
            string comtext = comboBox1.Text;
             products = data.Product
                .Where(x => x.ProductType1.TypeName == comtext)
                .Where(x => !String.IsNullOrEmpty(text) ? x.ProductName.Contains(text) : true)
                .ToList();

            pagenation1.TotalCount = products.Count;
            creatProduct(products.Take(6).ToList());
        }

        static ProductView view = null;
        private void creatProduct(List<Product> products)
        {
            flowLayoutPanel1.Controls.Clear();
            for (int i = 0; i < products.Count() ; i++)
            {
                view = new ProductView(products[i]);
                view.Tag = products[i];
                view.Click += ProductViewClick;
                flowLayoutPanel1.Controls.Add(view);
                
            }
        }

        //private void CloseCar(object sender, FormClosingEventArgs e)
        //{
        //    this.Dispose(true);
        //}

       
    }
}
