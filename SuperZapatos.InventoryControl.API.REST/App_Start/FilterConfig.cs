using System.Web;
using System.Web.Mvc;

namespace SuperZapatos.InventoryControl.API.REST
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
