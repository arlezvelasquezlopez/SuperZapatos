

using SuperZapatos.InventoryControl.Contracts.ServiceLibrary.Contracts;
using SuperZapatos.InventoryControl.Contracts.ServiceLibrary.DTOs;
using SuperZapatos.InventoryControl.Impl.ServiceLibrary.Impl;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Results;

namespace SuperZapatos.InventoryControl.API.REST.Controllers
{
    public class StoreController : ApiController
    {

        private IStoreAppplicationService _storeApplicationService;

        public StoreController()
        {
            _storeApplicationService = new StoreApplicationService();
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