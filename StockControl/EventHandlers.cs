using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockControl
{
    internal class EventHandlers
    {
        public event EventHandler<StockModel> randerStatus;

        public static event EventHandler<List<StockModel>> randerPanel;

        public void RanderStatus(Object sender,StockModel model)
        {
            randerStatus?.Invoke(sender, model);
        }

        public static void RanderPanel(List<StockModel> models)
        {
            randerPanel?.Invoke(null, models);
        }
    }
}
