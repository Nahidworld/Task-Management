using System.Web.Http;
using Unity;
using Unity.WebApi;

namespace TaskManagement.WebAPI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            //var container = new UnityContainer();
            // Enable attribute routing (optional but recommended)
            config.MapHttpAttributeRoutes();

            //config.DependencyResolver = new UnityDependencyResolver(container);

            // Define default Web API route (convention-based routing)
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            // (Optional) Configure JSON formatting preferences if needed
            // config.Formatters.JsonFormatter.SerializerSettings.Formatting = Newtonsoft.Json.Formatting.Indented;
            // Remove XML formatter so JSON is default
            config.Formatters.Remove(config.Formatters.XmlFormatter);
        }
    }
}



//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web.Http;

//namespace PostComment
//{
//    public static class WebApiConfig
//    {
//        public static void Register(HttpConfiguration config)
//        {
//            // Web API configuration and services

//            // Web API routes
//            config.MapHttpAttributeRoutes();

//            config.Routes.MapHttpRoute(
//                name: "DefaultApi",
//                routeTemplate: "api/{controller}/{id}",
//                defaults: new { id = RouteParameter.Optional }
//            );
//            config.EnableCors();
//        }
//    }
//}