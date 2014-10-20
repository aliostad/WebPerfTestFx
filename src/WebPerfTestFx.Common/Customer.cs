using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebPerfTestFx.Common
{
    public class Customer
    {

        public int Id { get; set; }

        public string Name { get; set; }

        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string AddressLine3 { get; set; }
        public string AddressLine4 { get; set; }
        public DateTime RegisteratonDate { get; set; }
        public DateTime? CancellationDate { get; set; }
        public IEnumerable<int> OrderIds { get; set; } 
    }
}
