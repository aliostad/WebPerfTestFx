using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebPerfTestFx.Common
{
    public class Order
    {
        public int Id { get; set; }

        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string AddressLine3 { get; set; }
        public string AddressLine4 { get; set; }

        public DateTime OrderDate { get; set; }
        public DateTime DispatchDate { get; set; }

        public IEnumerable<OrderItem> Items { get; set; } 
    }
}
