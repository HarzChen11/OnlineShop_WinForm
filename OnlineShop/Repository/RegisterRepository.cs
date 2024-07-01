
using AutoMapper;
using OnlineShop.Models;
using OnlineShop.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace OnlineShop.Repository
{
    internal class RegisterRepository
    {
        public static Customer CreatCustomer(RegisterModel registerModel)
        {
            if (CheckAccountExist(registerModel))
                return null;

            #region // 透過AutoMapper轉移資料
            //Customer customer = new Customer();
            //customer.CustomerID = Guid.NewGuid();
            //customer.Name = registerModel.Name;
            //customer.Password = registerModel.Password;
            //customer.Phone = registerModel.Phone;
            //customer.Address = registerModel.Address;
            //customer.City = registerModel.City;
            //customer.Email = registerModel.Email;
            #endregion 
            Customer customer =SwapModel(registerModel);
            customer.IsActive = false;
            LoginState.SetLoginState(customer);
            DataBase data = new DataBase();
            data.Customer.Add(customer);
            data.SaveChanges();
            data.Dispose();

            return customer;
        }

        private static Customer SwapModel(RegisterModel registerModel)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<RegisterModel, Customer>()
                #region
                // reg 是一個 IMemberConfigurationExpression<TSource, TDestination, TMember> 型別的實例用來設定如何從來源類型映射到目標類型。
                // 在這裡，reg 表示對 CustomerID 屬性進行配置，reg.MapFrom(src => Guid.NewGuid()) 表示使用自定義的映射邏輯，即為 CustomerID 生成一個新的 Guid。
                // 這個參數代表映射來源類型（RegisterModel 類型）的實例。在這個例子中，src 表示 RegisterModel 類型的實例。
                // 在這裡，src 是來源類型 RegisterModel 的實例，儘管在這個特定例子中，我們並沒有實際使用 src 來取得來源屬性，而是直接生成一個新的 Guid。
                #endregion
                    .ForMember(cus => cus.CustomerID, reg => reg.MapFrom(src => Guid.NewGuid()));
            });
            var mapper = config.CreateMapper();
            var customer = mapper.Map<Customer>(registerModel);
            return customer;
        }


        private static bool CheckAccountExist(RegisterModel registerModel)
        {
            DataBase data = new DataBase();
            var CheckPhone = data.Customer.FirstOrDefault(x => x.Phone == registerModel.Phone);
            if (CheckPhone != null)
            {
                MessageBox.Show("此門號已註冊過");
                return true;
            }
            return false;
        }

        public static void AccountActivation(Guid CustomerID)
        {
            DataBase data = new DataBase();
            var customer = data.Customer.FirstOrDefault(x => x.CustomerID == CustomerID);
            customer.IsActive = true;
            data.SaveChanges();
        }


    }
}
