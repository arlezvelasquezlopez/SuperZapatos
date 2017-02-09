using System.Web.Mvc;

namespace SuperZapatos.InventoryControl.WebUI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }      
    }
}