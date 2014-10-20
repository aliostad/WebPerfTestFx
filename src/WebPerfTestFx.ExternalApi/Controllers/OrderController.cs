using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using RandomGen;
using WebPerfTestFx.Common;

namespace WebPerfTestFx.ExternalApi.Controllers
{
    public class OrderController : ApiController
    {
        private static Func<string> _address = Gen.Random.Text.Long();
        private static Func<DateTime> _date = Gen.Random.Time.Dates(DateTime.Now.AddYears(-50), DateTime.Now);
        private static Func<int> _orderItemCount = Gen.Random.Numbers.Integers(1, 4);
        private static Func<int> _orderItemId = Gen.Random.Numbers.Integers(1, 1000 * 1000);

        public Order Get(int cid, int id)
        {
            return new Order()
            {
                AddressLine1 = _address(),
                AddressLine2 = _address(),
                AddressLine3 = _address(),
                AddressLine4 = _address(),
                DispatchDate = _date(),
                Id = id,
                OrderDate = _date(),
                Items = Enumerable.Range(0, _orderItemCount())
                    .Select(i => new OrderItem()
                    {
                        ProductId = _orderItemId(),
                        ProductName = _address(),
                        Quantity = _orderItemCount()
                    })
            };
        }
    }
}