﻿using System.Web.Mvc;
using System.Web.Routing;

namespace HortonHiveBrowser
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute("Default", "{controller}/{action}/{id}",
                new {controller = "SampleData", action = "Index", id = UrlParameter.Optional}
                );
            routes.MapRoute("Default1", "{controller}/{action}/{id}",
                new {controller = "Home", action = "Index", id = UrlParameter.Optional}
                );
        }
    }
}