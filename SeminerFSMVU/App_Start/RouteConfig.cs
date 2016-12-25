using System.Web.Mvc;
using System.Web.Routing;

namespace SeminerFSMVU
{
	public class RouteConfig
	{
		public static void RegisterRoutes(RouteCollection routes)
		{
			routes.IgnoreRoute("{resource}.axd/{*pathInfo}");


			routes.MapRoute(
				name: "FSMVUDetay",
				url: "FSMVUDetay/{ID}",
				defaults: new { controller = "Home", action = "Detail", ID = UrlParameter.Optional }
			);

			routes.MapRoute(
				name: "Default",
				url: "{controller}/{action}/{id}",
				defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
			);
		}
	}
}
