using System.Web;
using System.Web.Mvc;

namespace SuperZapatos.InventoryControl.API.XML
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
