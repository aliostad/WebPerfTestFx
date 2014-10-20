using System;
using System.Linq;
using System.Web.Http;
using RandomGen;
using WebPerfTestFx.Common;

namespace WebPerfTestFx.ExternalApi.Controllers
{

    public class CustomerController : ApiController
    {

        private static Func<string> _address = Gen.Random.Text.Long();
        private static Func<DateTime> _date = Gen.Random.Time.Dates(DateTime.Now.AddYears(-50), DateTime.Now);
        private static Func<string> _name = Gen.Random.Names.Full();
        private static Func<int> _orderCount = Gen.Random.Numbers.Integers(1, 4);
        private static Func<int> _orderId = Gen.Random.Numbers.Integers(1, 1000 * 1000);

        public Customer Get(int id)
        {
            return new Customer()
            {
                AddressLine1 = _address(),
                AddressLine2 = _address(),
                AddressLine3 = _address(),
                AddressLine4 = _address(),
                Id = id,
                Name = _name(),
                RegisteratonDate = _date(),
                OrderIds = Enumerable.Range(0,_orderCount())
                    .Select(i => _orderId()).ToArray()
            };

        }
    }


}