using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using TaskManagement.WebAPI;
//using System.Web.Routing;


namespace TaskManagement.WebAPI
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);

            // Register Unity DI container here
            UnityConfig.RegisterComponents();
        }
    }
}



//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using System.Web.Http;
//using TaskManagement.WebAPI;
////using System.Web.Routing;


//namespace TaskManagement.WebAPI
//{
//    public class WebApiApplication : HttpApplication
//    {
//        protected void Application_Start()
//        {
//            GlobalConfiguration.Configure(WebApiConfig.Register);

//            // Register Unity DI container here
//            UnityConfig.RegisterComponents();
//        }

//        //protected void Application_Start()
//        //{
//        //    // Web API routes
//        //    GlobalConfiguration.Configure(WebApiConfig.Register);

//        //    // MVC areas, routes, filters, bundles
//        //    AreaRegistration.RegisterAllAreas();
//        //    RouteConfig.RegisterRoutes(RouteTable.Routes);
//        //    FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
//        //    BundleConfig.RegisterBundles(BundleTable.Bundles);
//        //}
//        //protected void Application_Start()
//        //{
//        //    GlobalConfiguration.Configure(WebApiConfig.Register);
//        //    // Register bundles for optimization
//        //    BundleConfig.RegisterBundles(BundleTable.Bundles);
//        //}
//    }
//}
