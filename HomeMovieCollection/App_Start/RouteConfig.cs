using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace HomeMovieCollection
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Genre",
                "Genre/{genre}",
                new { Controller = "Movie", action = "Genre" }

                );

            routes.MapRoute(
               "Actor",
               "Actor/{actor}",
               new { Controller = "Movie", action = "Actor" }

               );

            //routes.MapRoute(
            //    "Movie",
            //    "Movie/{title}",
            //    new { controller = "Movie", action = "Movie" }
            //    );

            routes.MapRoute(
                "Manage",
                "Manage",
                new { controller = "Admin", action = "Manage" }
            );

            routes.MapRoute(
                "AdminAction",
                "Admin/{action}",
                new { controller = "Admin", action = "Login" }
            );


            routes.MapRoute(
                "Login",
                "Login",
                new { controller = "Admin", action = "Login" }
                );

            routes.MapRoute(
                "Logout",
                "Logout",
                new { controller = "Admin", action = "Logout" }
                );

            routes.MapRoute("Default", "{controller}/{action}/{id}",
               new { controller = "Movie", action = "Movies", id = UrlParameter.Optional }
               );
        }
    }
}
