using System;
using Swashbuckle.Application;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;

namespace WebApiContato
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.Formatters.Remove(config.Formatters.XmlFormatter); //Remove exibição do xml no navegador, exibindo assim o JSON

            config.EnableSwagger(c => c.SingleApiVersion("v1", "ContatoApi")).EnableSwaggerUi();

            //CORS
            //var cors = new EnableCorsAttribute("*", "*", "*"); //lIBERANDO ACESSO PARA SITES EXTERNOS, SEM ISSO, SÓ PODERIA ACESSAR NO MESMO SERVIDOR
            //config.EnableCors(cors);
        }
    }
}
