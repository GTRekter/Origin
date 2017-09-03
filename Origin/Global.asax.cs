using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Origin
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            // Initialize log4net.
            log4net.Config.XmlConfigurator.Configure();
        }
    }
}
