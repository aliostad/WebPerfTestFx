using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace WebPerfTestFx.ExternalApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services


            config.Routes.MapHttpRoute(
               name: "order",
               routeTemplate: "api/customer/{cid}/order/{id}",
               defaults: new { controller = "order" }
           );

            config.Routes.MapHttpRoute(
                name: "customer",
                routeTemplate: "api/customer/{id}",
                defaults: new { controller ="customer" }
            );

           
        }
    }
}
