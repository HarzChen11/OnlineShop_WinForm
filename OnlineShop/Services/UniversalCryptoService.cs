using OnlineShop.Models;
using OnlineShop.Models.Enums;
using OnlineShop.Utility;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Services
{
    internal class UniversalCryptoService
    {

        public static Dictionary<string, string> KeyOption(Keys keys)
        {
            Dictionary<string, string> result= new Dictionary<string, string>();
            switch (keys)
            {
                case Keys.Invoice:
                    result.Add("AesKey", ConfigurationManager.AppSettings["InvoiceAesKey"]);
                    result.Add("AesIv", ConfigurationManager.AppSettings["InvoiceAesIv"]);
                    break;
                case Keys.Logistics:
                    result.Add("AesKey", ConfigurationManager.AppSettings["LogisticsAesKey"]);
                    result.Add("AesIv", ConfigurationManager.AppSettings["LogisticsAesIv"]);
                    break;
            }
            return result;
        }
        public static string Encrypt<T>(T model, Keys keys)
        {
            var KeysResult = KeyOption(keys);
            string EncodedData = UrlHelper.UrlEncode(model).Replace("+", "%20");

            string AesKey = KeysResult["AesKey"];
            string AesIv = KeysResult["AesIv"];

            string afterEncrypt = "";

            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Encoding.UTF8.GetBytes(AesKey);
                aesAlg.IV = Encoding.UTF8.GetBytes(AesIv);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV), CryptoStreamMode.Write))
                    {
                        using (StreamWriter sw = new StreamWriter(cs))
                        {
                            sw.Write(EncodedData);
                        }

                        afterEncrypt = Convert.ToBase64String(ms.ToArray());
                    }
                }
            }
            return afterEncrypt;
        }


        public static string Decrypt(string DataValue, Keys keys)
        {
            var KeysResult = KeyOption(keys);
            string AesKey = KeysResult["AesKey"];
            string AesIv = KeysResult["AesIv"];

            string AfterDecrypt = "";

            var encrypted = Convert.FromBase64String(DataValue);


            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Encoding.UTF8.GetBytes(AesKey);
                aesAlg.IV = Encoding.UTF8.GetBytes(AesIv);
                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);
                using (MemoryStream ms = new MemoryStream(encrypted))
                {
                    using (CryptoStream cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader sr = new StreamReader(cs))
                        {
                            AfterDecrypt = sr.ReadToEnd();
                        }
                    }
                }
            }

            string DecodedData = UrlHelper.UrlDecode(AfterDecrypt);
            return DecodedData;
        }
    }
}
