using Microsoft.Web.WebView2.WinForms;
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
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OnlineShop.Components.ProductComponent
{
    public partial class ProductView : UserControl
    {

        Product product; 

        public ProductView(Product product)
        {
            InitializeComponent();
            this.product = product;

            var imgUrl = product.ProductImg;
            WebView2 view2 = new WebView2();
            view2.Location = new Point(3, 3);
            view2.Size = new Size(264, 198);
            view2.Source = new Uri(imgUrl);
            flowLayoutPanel1.Controls.Add(view2);


            Font font = new Font("微軟正黑體", 10);

            Label Namelb = new Label();
            Namelb.Font=font;
            Namelb.Width = flowLayoutPanel2.Width; 
            Label pricelb = new Label();
            pricelb.Font = font;
            Namelb.Text = product.ProductName.Replace("Knirps 德國紅點傘 |", "").Replace("KnirpsR 德國紅點", "").Replace("Knirps德國紅點傘｜", "").Replace("KnirpsR德國紅點傘 |", "").Replace("KnirpsR德國紅點傘｜", "").Trim();
            pricelb.Text = "價格:"+product.ProductPrice.ToString();
            flowLayoutPanel2.Controls.Add(Namelb);
            flowLayoutPanel2.Controls.Add(pricelb);

        }

        
        
        private void AddCar(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            // 檢查登入狀態
            bool check = EventHandlers.getLoginState();
            if (check == false)
            {
                MessageBox.Show("請先註冊或登入");
            }
            else
            {
                ProductModel model = new ProductModel();
<<<<<<< HEAD
                model.ProducId = product.ProductID;
=======
                model.Id = product.ProductID;
>>>>>>> 8101e26593e1c25fcacf35b07ec8373dd546f8f2
                model.name = product.ProductName;
                model.price = product.ProductPrice;
                model.count = 1;
                model.img = product.ProductImg;
<<<<<<< HEAD
                CarService.AddToCar(CartAction.Button ,model);
=======
                CartService.AddToCar(CartAction.Button ,model);
>>>>>>> 8101e26593e1c25fcacf35b07ec8373dd546f8f2
            }
        }
    }
}
