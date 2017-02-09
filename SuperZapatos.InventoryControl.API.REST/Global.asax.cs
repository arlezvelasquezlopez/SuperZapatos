using Autofac.Integration.WebApi;
using SuperZapatos.InventoryControl.API.REST.App_Start;
using SuperZapatos.InventoryControl.API.REST.Controllers;
using SuperZapatos.InventoryControl.API.REST.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Mvc;
using System.Web.Routing;

namespace SuperZapatos.InventoryControl.API.REST
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            AppDomain currentDomain = AppDomain.CurrentDomain;
            var builder = new Autofac.ContainerBuilder();      
            var config = GlobalConfiguration.Configuration;
            DIGlobalRegister.RegisterWithBuilder(builder, currentDomain, DIGlobalRegister.EnumRegistrationType.justWithDecoratedClasses);
            builder.RegisterWebApiFilterProvider(config);
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            if (HttpContext.Current.Request.HttpMethod == "OPTIONS")
            {
                HttpContext.Current.Response.AddHeader("Cache-Control", "no-cache");
                HttpContext.Current.Response.AddHeader("Access-Control-Allow-Methods", "GET, POST");
                HttpContext.Current.Response.AddHeader("Access-Control-Allow-Headers", "Content-Type, Accept");
                HttpContext.Current.Response.AddHeader("Access-Control-Max-Age", "1728000");
                HttpContext.Current.Response.End();
            }
        }


    }
}
