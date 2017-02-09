using System;
using System.Web.Http;

namespace SuperZapatos.InventoryControl.API.REST.Controllers
{
    public class ErrorController : ApiController
    {
        
        public ErrorController()
        {

        }

        public IHttpActionResult Index(Exception exception, int errorType)
        {
            return Json(new { error_msg = "No authorized", error_code = 500, success = false });
        }
    }
}