

using SuperZapatos.InventoryControl.API.REST.App_Start;
using SuperZapatos.InventoryControl.Contracts.ServiceLibrary.Contracts;
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
            catch (System.Exception)
            {

                return Json(new { error_msg = "Server error", error_code = 500, success = false });
            }
            
        }
      
    }
}