

using Newtonsoft.Json.Linq;
using System;
using System.Net;
using System.Net.Http;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using System.Web.Mvc;
using System.Web.Routing;

namespace SuperZapatos.InventoryControl.API.REST.XML.Security
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false)]
    public class BasicAuthenticationFilter : AuthorizationFilterAttribute
    {
        bool Active = true;  
        public BasicAuthenticationFilter()
        { }

       
        public BasicAuthenticationFilter(bool active)
        {
            Active = active;
        }


       
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            if (Active)
            {
                var identity = ParseAuthorizationHeader(actionContext);
                if (identity == null)
                {
                    Challenge(actionContext);
                    return;
                }


                if (!OnAuthorizeUser(identity.Name, identity.Password, actionContext))
                {                    
                    Challenge(actionContext);                   
                    return;
                }

                var principal = new GenericPrincipal(identity, null);

                Thread.CurrentPrincipal = principal;     
                base.OnAuthorization(actionContext);
            }
        }
   
        protected virtual bool OnAuthorizeUser(string username, string password, HttpActionContext actionContext)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password) || username != System.Configuration.ConfigurationManager.AppSettings["PFUserName"] || password != System.Configuration.ConfigurationManager.AppSettings["PFPassWord"])
                return false;

            return true;
        }

       
        protected virtual BasicAuthenticationIdentity ParseAuthorizationHeader(HttpActionContext actionContext)
        {
            string authHeader = null;
            var auth = actionContext.Request.Headers.Authorization;
            if (auth != null && auth.Scheme == "Basic")
                authHeader = auth.Parameter;

            if (string.IsNullOrEmpty(authHeader))
                return null;

            authHeader = Encoding.Default.GetString(Convert.FromBase64String(authHeader));

            var tokens = authHeader.Split(':');
            if (tokens.Length < 2)
                return null;

            return new BasicAuthenticationIdentity(tokens[0], tokens[1]);
        }
   
        private void Challenge(HttpActionContext actionContext)
        {
            actionContext.Response =  actionContext.Request.CreateResponse(
            HttpStatusCode.Unauthorized,
            new { error_msg = "Not authorized", error_code = 401, success = false },
            actionContext.ControllerContext.Configuration.Formatters.XmlFormatter
        );


        }

    }
}