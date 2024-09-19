using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockControl
{
    internal class StockService
    {
        public static List<StockModel> getStockList()
        {
            List<StockModel> Models = StockRepository.getStockList();
            return Models;
        }
    }
}
