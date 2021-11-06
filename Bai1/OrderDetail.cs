using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai1
{
    public class OrderDetail
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string Weight { get; set; }
        public string UnitPrice { get; set; }
        public double Total { get; set; }
    }
}
