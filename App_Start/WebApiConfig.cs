using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;

namespace WEB_API
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            // New code
            config.EnableCors();

            // Web API routes
            config.MapHttpAttributeRoutes();

            // Map this rule first


            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );



            var cors = new EnableCorsAttribute("http://localhost:51721", "*", "*");
            config.EnableCors(cors);
        }
    }
}
