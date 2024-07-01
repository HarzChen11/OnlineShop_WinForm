using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Models.ReponseModel
{
    internal class FinalLogisticsReponse
    {
        public string MerchantID { get; set; }
        public Rpheader RpHeader { get; set; }
        public int TransCode { get; set; }
        public string TransMsg { get; set; }
        public string Data { get; set; }

        public class Rpheader
        {
            public string Timestamp { get; set; }
        }

     
    }
}
