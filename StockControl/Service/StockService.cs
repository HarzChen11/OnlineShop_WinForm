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

        public static StockModel Ordered(StockModel stockModel)
        {
            StockModel stock = StockRepository.Ordered(stockModel);
            return stock;
        }

        public static StockModel ReStock(StockModel stockModel)
        {
            StockModel stock = StockRepository.ReStock(stockModel);
            return stock;
        }

       
    }
}
