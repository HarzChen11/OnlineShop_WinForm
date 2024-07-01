using OnlineShop.Models;
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

namespace OnlineShop.Components.ShopCarComponent
{
    public partial class ProductInCar : UserControl
    {
        ProductModel models;
        CartService service = new CartService();
        bool firstInit = true;
        public ProductInCar(ProductModel models)
        {
            InitializeComponent();
            this.models = models;

            var imgUrl = models.img;
            webView21.Source = new Uri(imgUrl);
            label3.Text = models.name;
            label4.Text = models.price.ToString();
            numericUpDown1.Value = models.count;
        }

        private void delet_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            service.RemoveCar(models);
        }

        private void numericUpDown1_ValueChanged_1(object sender, EventArgs e)
        {
            if(firstInit == false)
            {
                models.count = (int)numericUpDown1.Value;
                CartService.AddToCar(CartAction.NumberUpDown, models);

                if ((int)numericUpDown1.Value == 0)
                {
                    EventHandlers.RanderCar();
                    service.RemoveCar(models);
                }
            }
        }

        private void ProductInCar_Load(object sender, EventArgs e)
        {
            firstInit = false;
        }
    }
}
