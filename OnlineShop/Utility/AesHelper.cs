using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Utility
{
    internal class AesHelper
    {
        public static string AesEncrypt(string urlEncodedJson)
        {
            string AesKey = ConfigurationManager.AppSettings["AesKey"];
            string AesIv = ConfigurationManager.AppSettings["AesIv"];

            string afteAesEncrypt = "";

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
                            sw.Write(urlEncodedJson);
                        }

                        afteAesEncrypt = Convert.ToBase64String(ms.ToArray());
                    }
                }
            }
            return afteAesEncrypt;
        }

        public static string AesDecrypt(string DataValue)
        {
            string AesKey = ConfigurationManager.AppSettings["AesKey"];
            string AesIv = ConfigurationManager.AppSettings["AesIv"];

            string AfterAesDecrypt = "";

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
                            AfterAesDecrypt = sr.ReadToEnd();
                        }
                    }
                }
            };
            return AfterAesDecrypt;
        }
    }
}
