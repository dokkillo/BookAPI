﻿using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using System.Web.Http;
using Newtonsoft.Json.Serialization;
using System.Net.Http.Formatting;
using System.Linq;


[assembly: OwinStartup(typeof(BookAPI.Startup))]

namespace BookAPI
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            HttpConfiguration config = new HttpConfiguration();
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
             );

            app.UseWebApi(config);

            var jsonFormater = config.Formatters.OfType<JsonMediaTypeFormatter>().FirstOrDefault();
            jsonFormater.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
        }

    }
}
