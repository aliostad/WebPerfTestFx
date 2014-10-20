using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebPerfTestFx.Common
{
    public class FullCustomer : Customer
    {
        public FullCustomer()
        {

        }

        public FullCustomer(Customer c)
        {
            this.AddressLine1 = c.AddressLine1;
            this.AddressLine2 = c.AddressLine2;
            this.AddressLine3 = c.AddressLine3;
            this.AddressLine4 = c.AddressLine4;
            this.CancellationDate = c.CancellationDate;
            this.Id = c.Id;
            this.Name = c.Name;
            this.RegisteratonDate = c.RegisteratonDate;
        }

        public IEnumerable<Order> Orders { get; set; }
    }
}
