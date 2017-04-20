using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Units.App_Start;

namespace Units
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            ContainerConfig.SetupIOC();
            MappingConfig.SetupMaps();
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
