

using SuperZapatos.InventoryControl.API.REST.App_Start;
using SuperZapatos.InventoryControl.Contracts.ServiceLibrary.Contracts;
using System.Diagnostics;
using System.Linq;
using System.Web.Http;

namespace SuperZapatos.InventoryControl.API.REST.Controllers
{
    [BasicAuthenticationFilter]
    public class StoreController : ApiController
    {

        private IStoreAppplicationService _storeApplicationService;

        public StoreController(IStoreAppplicationService storeAppplicationService)
        {
            _storeApplicationService = storeAppplicationService;
        }

        [Route("services/stores")]
        [HttpGet]
        public IHttpActionResult GetAll()
        {

            try
            {
                var storesList = _storeApplicationService.GetAll().ToList();
                return Json(new { stores = storesList, success = true, total_elements = storesList.Count() });
            }
            catch (System.Exception ex)
            {
                Trace.TraceError(string.Concat("Error getting stores list ", ex.Message));
                return Json(new { error_msg = "Server error", error_code = 500, success = false });
            }
            
        }
      
    }
}