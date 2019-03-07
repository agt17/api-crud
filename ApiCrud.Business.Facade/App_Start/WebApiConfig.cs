using ApiCrud.Business.Facade.Controllers;
using ApiCrud.Business.Facade.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace ApiCrud.Business.Facade
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Configuración y servicios de API web

            // Rutas de API web
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.MessageHandlers.Add(new LanguageMessageHandler());
            config.MessageHandlers.Add(new TokenValidationHandler());
        }
    }
}
