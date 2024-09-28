using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Utility
{
    internal class HttpRequests
    {
        // 開立發票
        public static (A,string) PostRequest<A>(string url, object model,bool json)  where A : new()
        {
            var client = new RestClient(url);
            var request = new RestRequest("", Method.Post);
            //T t = new T();
            //var Data = t.GetType().GetProperty("Data");
            //Data.SetValue(t, EncryptResult);
            string invoicejsonData = JsonConvert.SerializeObject(model, Formatting.Indented);
            request.AddParameter("application/json", invoicejsonData, ParameterType.RequestBody);
            RestResponse response = client.Execute(request);
            //t = JsonConvert.DeserializeObject<T>(response.Content);

            A a = new A();
            if (json == false)
            {
                return (default(A), response.Content);
            }
            a = jsonConvert<A>(response.Content);
            return (a, null);
            #region
            //HttpClient httpClient = new HttpClient();
            //string apiUrl = "https://einvoice-stage.ecpay.com.tw/B2CInvoice/Issue";
            //string jsonContent = JsonConvert.SerializeObject(invoiceModel);
            //Console.WriteLine(jsonContent);
            //HttpContent httpContent = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            //HttpResponseMessage response = await httpClient.PostAsync(apiUrl, httpContent);

            //if (response.IsSuccessStatusCode)
            //{

            //    Console.WriteLine(response.Content);
            //    // 回應內容
            //    string responseContent = await response.Content.ReadAsStringAsync();
            //    Console.WriteLine(responseContent);
            //}
            #endregion
        }

        private static A jsonConvert<A>(string postResult) where A : new()
        {
            A a = JsonConvert.DeserializeObject<A>(postResult);
            return a;
        }
    }
}
