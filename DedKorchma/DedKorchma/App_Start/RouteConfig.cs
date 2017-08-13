using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace DedKorchma
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");


            routes.LowercaseUrls = true;
            routes.AppendTrailingSlash = true;

            routes.MapRoute(
                name: "News/{Page}",
                url: "News/page/{pageNumber}",
                defaults: new { controller = "News", action = "Index", pageNumber = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "News/Details/{url}",
                url: "news/details/{url}",
                defaults: new { controller = "News", action = "DetailsNews" }
                );
            routes.MapRoute(
                name: "Admin",
                url: "admin",
                defaults: new { controller = "Admin", action = "Index" }
                );
            routes.MapRoute(
                name: "News",
                url: "news",
                defaults: new { controller = "News", action = "Index", pageNumber = UrlParameter.Optional }
                );
            routes.MapRoute(
                name: "Gallery",
                url: "gallery",
                defaults: new { controller = "Gallery", action = "Index", pageNumber = UrlParameter.Optional }
                );
           routes.MapRoute(
                name: "album/Create",
                url: "album/create",
                defaults: new { controller = "Gallery", action = "Createalbum", pageNumber = UrlParameter.Optional }
                );
            routes.MapRoute(
                   name: "News/Create",
                   url: "news/create",
                   defaults: new { controller = "News", action = "CreateNews" }
               );
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
