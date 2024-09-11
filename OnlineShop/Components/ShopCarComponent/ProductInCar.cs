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
<<<<<<< HEAD
=======
        CartService service = new CartService();
>>>>>>> 8101e26593e1c25fcacf35b07ec8373dd546f8f2
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
<<<<<<< HEAD
            CarService.RemoveCar(models);
=======
            service.RemoveCar(models);
>>>>>>> 8101e26593e1c25fcacf35b07ec8373dd546f8f2
        }

        private void numericUpDown1_ValueChanged_1(object sender, EventArgs e)
        {
            if(firstInit == false)
            {
                models.count = (int)numericUpDown1.Value;
<<<<<<< HEAD
                CarService.AddToCar(CartAction.NumberUpDown, models);
=======
                CartService.AddToCar(CartAction.NumberUpDown, models);
>>>>>>> 8101e26593e1c25fcacf35b07ec8373dd546f8f2

                if ((int)numericUpDown1.Value == 0)
                {
                    EventHandlers.RanderCar();
<<<<<<< HEAD
                    CarService.RemoveCar(models);
=======
                    service.RemoveCar(models);
>>>>>>> 8101e26593e1c25fcacf35b07ec8373dd546f8f2
                }
            }
        }

        private void ProductInCar_Load(object sender, EventArgs e)
        {
            firstInit = false;
        }
    }
}
