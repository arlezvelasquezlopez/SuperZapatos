using Autofac.Integration.WebApi;
using SuperZapatos.InventoryControl.API.XML.Helpers;
using SuperZapatos.InventoryControl.API.XML.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Routing;
using System.Runtime.Serialization;

namespace SuperZapatos.InventoryControl.API.XML
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            var promotionsXmlFormatter = GlobalConfiguration.Configuration.Formatters.XmlFormatter;
            promotionsXmlFormatter.SetSerializer<ErrorResponse>(new System.Xml.Serialization.XmlSerializer(typeof(ErrorResponse)));
            promotionsXmlFormatter.SetSerializer<SuccessStoreResponse>(new System.Xml.Serialization.XmlSerializer(typeof(SuccessStoreResponse)));
            promotionsXmlFormatter.SetSerializer<SuccessArticleResponse>(new System.Xml.Serialization.XmlSerializer(typeof(SuccessArticleResponse)));
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
