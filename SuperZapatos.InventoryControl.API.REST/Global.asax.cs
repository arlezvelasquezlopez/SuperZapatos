using SuperZapatos.InventoryControl.API.REST.App_Start;
using SuperZapatos.InventoryControl.API.REST.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
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
            GlobalConfiguration.Configuration.Filters.Add(new BasicAuthenticationFilter());
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




        protected void Application_Error(object sender, EventArgs e)
        {
            var exception = Server.GetLastError();

            var httpContext = ((HttpApplication)sender).Context;
            httpContext.Response.Clear();
            httpContext.ClearError();
            ExecuteErrorController(httpContext, exception);
        }

        protected void OnApplicationError(object sender, EventArgs e)
        {
            var ex = Server.GetLastError();            

            Server.ClearError();
        }

        private void ExecuteErrorController(HttpContext httpContext, Exception exception)
        {
            var routeData = new RouteData();
            routeData.Values["controller"] = "Error";
            routeData.Values["action"] = "Index";
            routeData.Values["errorType"] = 10; //this is your error code. Can this be retrieved from your error controller instead?
            routeData.Values["exception"] = exception;

            using (ApiController controller = new ErrorController())
            {
                ((IController)controller).Execute(new RequestContext(new HttpContextWrapper(httpContext), routeData));
            }
        }

    }
}
