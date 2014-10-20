using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Newtonsoft.Json;
using WebPerfTestFx.Common;

namespace WebTestBed.Api.Controllers
{
public class CustomerController : ApiController
{
    public FullCustomer GetSync(int id)
    {
        var webClient = new WebClient();
        var customerString = webClient.DownloadString(BuildUrl(id));
        var customer = JsonConvert.DeserializeObject<Customer>(customerString);
        var fullCustomer = new FullCustomer(customer);
        var orders = new List<Order>();
        foreach (var orderId in customer.OrderIds)
        {
            var orderString = webClient.DownloadString(BuildUrl(id, orderId));
            var order = JsonConvert.DeserializeObject<Order>(orderString);
            orders.Add(order);
        }
        fullCustomer.Orders = orders;
        return fullCustomer;
    }

    public async Task<FullCustomer> GetASync(int id)
    {
        var webClient = new WebClient();
        var customerString = await webClient.DownloadStringTaskAsync(BuildUrl(id));
        var customer = JsonConvert.DeserializeObject<Customer>(customerString);
        var fullCustomer = new FullCustomer(customer);
        var orders = new List<Order>();
        foreach (var orderId in customer.OrderIds)
        {
            var orderString = await webClient.DownloadStringTaskAsync(BuildUrl(id, orderId));
            var order = JsonConvert.DeserializeObject<Order>(orderString);
            orders.Add(order);
        }
        fullCustomer.Orders = orders;
        return fullCustomer;
    }

    public async Task<FullCustomer> GetASyncWebApi(int id)
    {
        var httpClient = new HttpClient();
        httpClient.DefaultRequestHeaders.Add("Accept", "application/json"); 
        var responseMessage = await httpClient.GetAsync(BuildUrl(id));
        var customer = await responseMessage.Content.ReadAsAsync<Customer>();
        var fullCustomer = new FullCustomer(customer);
        var orders = new List<Order>();
        foreach (var orderId in customer.OrderIds)
        {
            responseMessage = await httpClient.GetAsync(BuildUrl(id, orderId));
            var order = await responseMessage.Content.ReadAsAsync<Order>();
            orders.Add(order);
        }
        fullCustomer.Orders = orders;
        return fullCustomer;
    }

    public async Task<FullCustomer> GetASyncWebApiString(int id)
    {
        var httpClient = new HttpClient();
        httpClient.DefaultRequestHeaders.Add("Accept", "application/json"); 
        var responseMessage = await httpClient.GetAsync(BuildUrl(id));
        var customerString = await responseMessage.Content.ReadAsStringAsync();
        var customer = JsonConvert.DeserializeObject<Customer>(customerString);
        var fullCustomer = new FullCustomer(customer);
        var orders = new List<Order>();
        foreach (var orderId in customer.OrderIds)
        {
            responseMessage = await httpClient.GetAsync(BuildUrl(id, orderId));
            var orderString = await responseMessage.Content.ReadAsStringAsync();
            var order = JsonConvert.DeserializeObject<Order>(orderString);
            orders.Add(order);
        }
        fullCustomer.Orders = orders;
        return fullCustomer;
    }

    private string BuildUrl(int customerId, int? orderId = null)
    {
        string baseUrl = string.Format("http://{0}:8080/api/customer/{1}", Request.RequestUri.Host, customerId);
        return orderId.HasValue
            ? string.Format("{0}/order/{1}", baseUrl, orderId.Value)
            : baseUrl;
    }

}

}