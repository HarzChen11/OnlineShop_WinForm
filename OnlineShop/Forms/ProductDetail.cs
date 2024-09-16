using Microsoft.Web.WebView2.WinForms;
using OnlineShop.Components.MenuBarComponent;
using OnlineShop.Models;
using OnlineShop.Models.Entities;
using OnlineShop.Models.Enums;
using OnlineShop.Repository;
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
    public partial class ProductDetail : Form
    {
        Product product;
        
        public ProductDetail(Product product)
        {
            InitializeComponent();
           this.product = product;
            var imgUrl = product.ProductImg;
            webView21.Source = new Uri(imgUrl);
            Font font = new Font("微軟正黑體", 10);

            Label pdName = new Label();
            pdName.Text = "商品名稱: " + product.ProductName;
            pdName.Width = 80;
            pdName.Font = font;
            pdName.Width = flowLayoutPanel1.Width;
            Label pdDescription = new Label();
            pdDescription.AutoSize = false;
            pdDescription.Width = 380;
            pdDescription.Height = 160;
            pdDescription.Text = "商品描述: "+product.ProductDescription;
            pdDescription.Font = font;
            Label pdPrice = new Label();
            pdPrice.Text = "價格: " + product.ProductPrice.ToString();
            pdPrice.Font = font;
            pdPrice.Width = flowLayoutPanel1.Width;
            Label pdStock = new Label();
            pdStock.Text = "庫存: " + product.ProductQuantity.ToString();
            pdStock.Font = font;
            pdStock.Width = flowLayoutPanel1.Width;
            flowLayoutPanel1.Controls.Add(pdName);
            flowLayoutPanel3.Controls.Add(pdDescription);
            flowLayoutPanel4.Controls.Add(pdPrice);
            flowLayoutPanel5.Controls.Add(pdStock);

            DataBase data = new DataBase();
            var imgs = data.ProductImg.Where(x => x.ProductImgID == product.ProductID).ToList();

            foreach (var img in imgs)
            {
                WebView2 webView = new WebView2();
                webView.Width = 100;
                webView.Height = 100;
                var url = img.ProductImg1;
                webView.Source = new Uri(url);
                flowLayoutPanel2.Controls.Add(webView);
            }
        }

        private void AddCar(object sender, EventArgs e)
        {

            bool check = EventHandlers.getLoginState();
            if (check == false)
            {
                MessageBox.Show("請先註冊或登入");
            }
            else
            {
                ProductModel model = new ProductModel();
                model.ProducId = product.ProductID;
                model.name = product.ProductName;
                model.price = product.ProductPrice;
                model.count = 1;
                model.img = product.ProductImg;
                CarService.AddToCar(CartAction.Button,model);

            }
        }

        private void menuBar1_Load(object sender, EventArgs e)
        {

        }
    }
}
