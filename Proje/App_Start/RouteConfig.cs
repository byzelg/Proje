using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Proje
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");



            //"Hakkımızda" sekmesine basıldığında url kısmında https://localhost:44340/hakkimizda yazacaktır
            routes.MapRoute(
                name: "About",
                url: "hakkimizda",
                defaults: new { controller = "About", action = "Index" }
            );



            //Blog sekemsine tıklandığında url kısmında https://localhost:44340/blog yazacaktır
            routes.MapRoute(
               name: "Blog",
               url: "blog",
               defaults: new { controller = "Blog", action = "Index" }
           );



            //İletişim sekmesine tıkladığımızda url kısmında https://localhost:44340/iletisim yazacaktır
            routes.MapRoute(
               name: "Contact",
               url: "iletisim",
               defaults: new { controller = "Contact", action = "Index" }
           );



            //"Logo"ya tıkladığımızda url kısmında https://localhost:44340/Home/Index yazacaktır
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
