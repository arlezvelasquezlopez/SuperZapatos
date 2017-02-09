using Autofac;
using Autofac.Integration.Mvc;
using SuperZapatos.InventoryControl.WebUI.Helpers;
using System;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace SuperZapatos.InventoryControl.WebUI
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            var builder = new ContainerBuilder();

            AppDomain currentDomain = AppDomain.CurrentDomain;
            DIGlobalRegister.RegisterWithBuilder(builder, currentDomain, DIGlobalRegister.EnumRegistrationType.justWithDecoratedClasses);
            var dependencyContainer = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(dependencyContainer));
        }
    }
}
