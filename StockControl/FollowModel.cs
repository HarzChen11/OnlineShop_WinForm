using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockControl
{
    public class FollowModel
    {
        public string Email { get; set; }
        public List<FollowData> Data { get; set; }

        public FollowModel()
        {
            Data = new List<FollowData>();
        }
    }

    public class FollowData
    {
        public Guid ProductID { get; set; }
        public string ProductName { get; set; }
    }

}


