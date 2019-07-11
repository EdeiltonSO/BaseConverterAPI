using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;

namespace BaseConverterAPI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            EnableCorsAttribute cors = new EnableCorsAttribute("http://localhost:3000, https://baseconverterapp.herokuapp.com, http://baseconverterapp.herokuapp.com", "*", "GET");
            config.EnableCors(cors);

            config.MapHttpAttributeRoutes();
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}"
                // defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
