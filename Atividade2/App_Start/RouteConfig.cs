using System.Web.Mvc;
using System.Web.Routing;

namespace Atividade2
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Atividade2", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
