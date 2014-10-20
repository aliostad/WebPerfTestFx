using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using WebPerfTestFx.Common;
using WebPerfTestFx.ExternalApi.Controllers;

namespace Benchmarker
{
    internal class Program
    {
private static void Main(string[] args)
{
    const int TotalRun = 10*1000;

    var customerController = new CustomerController();
    var orderController = new OrderController();
    var customer = customerController.Get(1);

    var orders = new List<Order>();
    foreach (var orderId in customer.OrderIds)
    {
        orders.Add(orderController.Get(1, orderId));
    }

    var fullCustomer = new FullCustomer(customer)
    {
        Orders = orders
    };

    var s = JsonConvert.SerializeObject(fullCustomer);
    var bytes = Encoding.UTF8.GetBytes(s);
    var stream = new MemoryStream(bytes);
    var content = new StreamContent(stream);

    content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            
    var stopwatch = Stopwatch.StartNew();
    for (int i = 1; i < TotalRun+1; i++)
    {
        var a = content.ReadAsAsync<FullCustomer>().Result;
        if(i % 100 == 0)
            Console.Write("\r" + i);
    }
    Console.WriteLine();
    Console.WriteLine(stopwatch.Elapsed);

    stopwatch.Restart();
    for (int i = 1; i < TotalRun+1; i++)
    {
        var sa = content.ReadAsStringAsync().Result;
        var a = JsonConvert.DeserializeObject<FullCustomer>(sa);
        if (i % 100 == 0)
            Console.Write("\r" + i);
    }
    Console.WriteLine();
    Console.WriteLine(stopwatch.Elapsed);

    Console.Read();

}
    }
}
