using OnlineShop.Models;
using OnlineShop.Models.Entities;
using OnlineShop.Models.Enums;
using OnlineShop.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Repository
{
    internal class CarRepository
    {
        //連接資料庫並加入商品
<<<<<<< HEAD
        public static void AddItem(Guid customerID, List<ProductModel> productList)
=======
        public static void AddItem(Guid customerID ,List<ProductModel> productList)
>>>>>>> 8101e26593e1c25fcacf35b07ec8373dd546f8f2
        {
            DataBase data = new DataBase();
            var Carinfo = data.Trolley.FirstOrDefault(x => x.Customer == customerID && x.OrderStatus == false);
            if (Carinfo == null)
            {
                Trolley trolley = new Trolley();
                trolley.TrolleyID = Guid.NewGuid();
                trolley.Customer = customerID;
                trolley.CreatDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                trolley.OrderStatus = false;
                data.Trolley.Add(trolley);

                foreach (var product in productList)
                {
<<<<<<< HEAD
                    TrollydetailCreat(data, trolley.TrolleyID, product.ProducId, product.count);
=======
                    TrollydetailCreat(data, trolley.TrolleyID, product.Id, product.count);
>>>>>>> 8101e26593e1c25fcacf35b07ec8373dd546f8f2
                }
                #region
                //for (int i = 0; i < productList.Count(); i++)
                //{
                //    TrolleyDetails details = new TrolleyDetails();
                //    details.TrolleyDetailsID = Guid.NewGuid();
                //    details.TrolleyID = trolley.TrolleyID;
                //    details.ProductID = productList[i].Id;
                //    details.ProductQuantity = productList[i].count; ;
                //    details.ProductSpec = "正常";
                //    details.ProductColor = "隨機";
                //    data.TrolleyDetails.Add(details);
                //}
                //data.SaveChanges();
                #endregion
            }
<<<<<<< HEAD
            else if (Carinfo.OrderStatus == true)
            {
                // 當 Carinfo 的 OrderStatus 為 true 時，創建新的購物車並添加產品
                Trolley trolley = new Trolley
                {
                    TrolleyID = Guid.NewGuid(),
                    Customer = customerID,
                    CreatDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                    OrderStatus = false
                };
                data.Trolley.Add(trolley);

                foreach (var product in productList)
                {
                    TrollydetailCreat(data, trolley.TrolleyID, product.ProducId, product.count);
                }
            }

=======
>>>>>>> 8101e26593e1c25fcacf35b07ec8373dd546f8f2
            else
            {
                foreach (var product in productList)
                {
<<<<<<< HEAD
                    var ProductInfo = data.TrolleyDetails.FirstOrDefault(x => x.Trolley.TrolleyID == Carinfo.TrolleyID && x.ProductID.Equals(product.ProducId));
                    if (ProductInfo == null)
                    {
                        TrollydetailCreat(data, Carinfo.TrolleyID, product.ProducId, product.count);
=======
                    var ProductInfo = data.TrolleyDetails.FirstOrDefault(x => x.Trolley.TrolleyID == Carinfo.TrolleyID && x.ProductID.Equals(product.Id));
                    if (ProductInfo == null)
                    {
                        TrollydetailCreat(data, Carinfo.TrolleyID, product.Id, product.count);
>>>>>>> 8101e26593e1c25fcacf35b07ec8373dd546f8f2
                    }
                    else
                    {
                        ProductInfo.ProductQuantity = product.count;
                    }
                }
                #region
                //for (int i = 0; i < productList.Count(); i++)
                //{
                //    Guid productID = productList[i].Id;
                //    var ProductInfo = data.TrolleyDetails.FirstOrDefault(x => x.ProductID.Equals(productID));

                //    if (ProductInfo == null)
                //    {
                //        TrolleyDetails details = new TrolleyDetails();
                //        details.TrolleyDetailsID = Guid.NewGuid();
                //        details.TrolleyID = Carinfo.TrolleyID;
                //        details.ProductID = productList[i].Id;
                //        details.ProductQuantity = productList[i].count; ;
                //        details.ProductSpec = "正常";
                //        details.ProductColor = "隨機";
                //        data.TrolleyDetails.Add(details);
                //    }
                //    else
                //    {
                //        ProductInfo.ProductQuantity = productList[i].count;
                //    }
                //data.SaveChanges();
                #endregion
            }
<<<<<<< HEAD

=======
>>>>>>> 8101e26593e1c25fcacf35b07ec8373dd546f8f2
            data.SaveChanges();
        }

        private static void TrollydetailCreat(DataBase data, Guid TrolleyID, Guid productID, int count)
        {

            TrolleyDetails details = new TrolleyDetails();
            details.TrolleyDetailsID = Guid.NewGuid();
            details.TrolleyID = TrolleyID;
            details.ProductID = productID;
            details.ProductQuantity = count; ;
            details.ProductSpec = "正常";
            details.ProductColor = "隨機";
            data.TrolleyDetails.Add(details);

        }

<<<<<<< HEAD
        //OrderStatus == false，連接資料庫並移除商品
        public static void RemoveItem(Guid userID, ProductModel product)
        {

            DataBase data = new DataBase();
            Trolley car = data.Trolley.First(x => x.Customer == userID && x.OrderStatus == false);
            var item = data.TrolleyDetails.FirstOrDefault(x => x.TrolleyID == car.TrolleyID && x.ProductID == product.ProducId);
            data.TrolleyDetails.Remove(item);
            data.SaveChanges();
        }

        // OrderStatus == true，結帳完成後連接資料庫移除購物車明細的所有商品
        public static void RemoveItem(Guid userID, List<ProductModel> products)
        {

            DataBase data = new DataBase();
            Trolley car = data.Trolley.First(x => x.Customer == userID && x.OrderStatus == true);

            foreach (var product in products)
            {
                var item = data.TrolleyDetails.FirstOrDefault(x => x.TrolleyID == car.TrolleyID && x.ProductID == product.ProducId);
                if (item != null)
                {
                    data.TrolleyDetails.Remove(item);
                    data.SaveChanges();
                }
            }
        }

        // 取得已完成結帳的購物車資料
        // 增加判斷條件x.OrderStatus == true，讓顯示商品只會顯示未結帳的商品
        public static List<ProductModel> GetBoughtProductList(Guid CustomerId)
        {
            DataBase data = new DataBase();
            List<ProductModel> productList = data.Trolley.Where(x => x.Customer == CustomerId && x.OrderStatus == true).SelectMany(x => x.TrolleyDetails).Select(x => new ProductModel()
            {
                price = x.Product.ProductPrice,
                count = x.ProductQuantity,
                ProducId = x.ProductID,
                img = x.Product.ProductImg,
                name = x.Product.ProductName
            }).ToList();

            return productList;
        }

        public static List<ProductModel> GetProductListByUser(Guid CustomerId)
        {
            DataBase data = new DataBase();
            List<ProductModel> productList = data.Trolley.Where(x => x.Customer == CustomerId && x.OrderStatus == false).SelectMany(x => x.TrolleyDetails).Select(x => new ProductModel()
            {
                price = x.Product.ProductPrice,
                count = x.ProductQuantity,
                ProducId = x.ProductID,
=======
        //連接資料庫並移除商品
        public static void RemoveItem(Guid userID,ProductModel product)
        {

            DataBase data = new DataBase();
            Trolley cart = data.Trolley.First(x => x.Customer == userID && x.OrderStatus == false);
            var item = data.TrolleyDetails.FirstOrDefault(x => x.TrolleyID == cart.TrolleyID && x.ProductID == product.Id);
            data.TrolleyDetails.Remove(item);
            data.SaveChanges();

        }

        //取得使用者的購物車資料
        public static List<ProductModel> GetProductListByUser(Guid CustomerId)
        {
            DataBase data = new DataBase();
            List<ProductModel>  productList = data.Trolley.Where(x => x.Customer == CustomerId).SelectMany(x => x.TrolleyDetails).Select(x => new ProductModel()
            {
                price = x.Product.ProductPrice,
                count = x.ProductQuantity,
                Id = x.ProductID,
>>>>>>> 8101e26593e1c25fcacf35b07ec8373dd546f8f2
                img = x.Product.ProductImg,
                name = x.Product.ProductName
            }).ToList();

            return productList;
        }
<<<<<<< HEAD


=======
>>>>>>> 8101e26593e1c25fcacf35b07ec8373dd546f8f2
    }
}


<<<<<<< HEAD
//  else
//{
//    if (Carinfo.OrderStatus == true)
//    {
//        Trolley trolley = new Trolley();
//        trolley.TrolleyID = Guid.NewGuid();
//        trolley.Customer = customerID;
//        trolley.CreatDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
//        trolley.OrderStatus = false;
//        data.Trolley.Add(trolley);

//        foreach (var product in productList)
//        {
//            TrollydetailCreat(data, trolley.TrolleyID, product.Id, product.count);
//        }
//    }
=======
>>>>>>> 8101e26593e1c25fcacf35b07ec8373dd546f8f2
