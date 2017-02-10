
using SuperZapatos.InventoryControl.API.REST.XML.Security;
using SuperZapatos.InventoryControl.API.XML.Helpers;
using SuperZapatos.InventoryControl.Contracts.ServiceLibrary.Contracts;
using System.Diagnostics;
using System.Linq;
using System.Web.Http;

namespace SuperZapatos.InventoryControl.API.REST.Controllers
{

    [BasicAuthenticationFilter]
    public class ArticleController : ApiController
    {
        private IArticleApplicationService _articleApplicationService;
        public ArticleController(IArticleApplicationService articleApplicationService)
        {
            _articleApplicationService = articleApplicationService;
        }


        [Route("services/articles")]
        [HttpGet]
        public IHttpActionResult GetAll()
        {
            try
            {
                var articlesList = _articleApplicationService.GetAll().ToList();
                return Content(System.Net.HttpStatusCode.OK, MappingHelper.SuccessArticleResponse(articlesList), Configuration.Formatters.XmlFormatter);
            }
            catch (System.Exception ex)
            {
                Trace.TraceError(string.Concat("Error getting all articles ", ex.Message));
                return Content(System.Net.HttpStatusCode.InternalServerError, MappingHelper.ErrorResponse("Server error", 500), Configuration.Formatters.XmlFormatter);
            }

        }


        [Route("services/articles/stores/{id}")]
        [HttpGet]
        public IHttpActionResult GetArticlesByIdStore(string id)
        {
            var actualId = 0;
            if (!int.TryParse(id, out actualId))
            {
                return Content(System.Net.HttpStatusCode.BadRequest, MappingHelper.ErrorResponse("Bad request", 400), Configuration.Formatters.XmlFormatter);
            }

            try
            {
                var articlesList = _articleApplicationService.GetAll();
                articlesList = articlesList.Where(x => x.StoreId == actualId).ToList();

                if (!articlesList.Any())
                {
                    return Content(System.Net.HttpStatusCode.NotFound, MappingHelper.ErrorResponse("Record not found", 404), Configuration.Formatters.XmlFormatter);
                }
                return Content(System.Net.HttpStatusCode.OK, MappingHelper.SuccessArticleResponse(articlesList.ToList()), Configuration.Formatters.XmlFormatter);
            }
            catch (System.Exception ex)
            {
                Trace.TraceError(string.Concat("Error getting article by Id store ", ex.Message));
                return Content(System.Net.HttpStatusCode.InternalServerError, MappingHelper.ErrorResponse("Server error", 500), Configuration.Formatters.XmlFormatter);
            }

        }
    }
}