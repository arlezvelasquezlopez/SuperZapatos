

using SuperZapatos.InventoryControl.API.REST.XML.Security;
using SuperZapatos.InventoryControl.API.XML.Helpers;
using SuperZapatos.InventoryControl.Contracts.ServiceLibrary.Contracts;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web.Http;

namespace SuperZapatos.InventoryControl.API.XML.Controllers
{
    [BasicAuthenticationFilter]
    public class StoreController : System.Web.Http.ApiController
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
                return Content(System.Net.HttpStatusCode.OK, MappingHelper.SucessStoreResponse(storesList), Configuration.Formatters.XmlFormatter);

            }
            catch (System.Exception ex)
            {
                Trace.TraceError(string.Concat("Error getting stores list ", ex.Message));
                return Content(System.Net.HttpStatusCode.InternalServerError, MappingHelper.ErrorResponse("Server error", 500), Configuration.Formatters.XmlFormatter);
            }

        }
    }
}