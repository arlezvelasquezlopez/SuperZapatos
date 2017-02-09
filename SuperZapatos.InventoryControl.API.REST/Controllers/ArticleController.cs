using SuperZapatos.InventoryControl.API.REST.App_Start;
using SuperZapatos.InventoryControl.Contracts.ServiceLibrary.Contracts;
using SuperZapatos.InventoryControl.Impl.ServiceLibrary.Impl;
using System.Linq;
using System.Web.Http;

namespace SuperZapatos.InventoryControl.API.REST.Controllers
{

    [BasicAuthenticationFilter]
    public class ArticleController : ApiController
    {
        private IArticleApplicationService _articleApplicationService;


       
        public ArticleController()
        {
            _articleApplicationService = new ArticleApplicationService();
        }

       
        [Route("services/articles")]
        [HttpGet]
        public IHttpActionResult GetAll()
        {
            try
            {

                var articlesList = _articleApplicationService.GetAll().ToList();
                return Json(new { articles = articlesList, success = true, total_elements = articlesList.Count() });
            }
            catch(System.Security.Authentication.InvalidCredentialException ex)
            {
                return Json(new { error_msg = "Server error", error_code = 500, success = false });
            }
            catch (System.Exception ex)
            {

                return Json(new { error_msg = "Server error", error_code = 500, success = false });
            }
          
        }

      
        [Route("services/articles/stores/{id}")]
        [HttpGet]
        public IHttpActionResult GetArticlesByIdStore(string id)
        {
            var actualId = 0;
            if (!int.TryParse(id, out actualId))
            {
                return Json(new { error_msg = "Bad Request", error_code = 400, success = false });
            }

            try
            {
                var articlesList = _articleApplicationService.GetAll();
                articlesList = articlesList.Where(x => x.StoreId == actualId).ToList();

                if (!articlesList.Any())
                {
                    return Json(new { error_msg = "Record not Found", error_code = 404, success = false });
                }
                return Json(new { articles = articlesList.ToList(), success = true, total_elements = articlesList.Count() });
            }
            catch (System.Exception)
            {

                return Json(new { error_msg = "Server error", error_code = 500, success = false });
            }
          
        }
    }
}