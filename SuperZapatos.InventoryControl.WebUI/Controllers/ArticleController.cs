using SuperZapatos.InventoryControl.Contracts.ServiceLibrary.Contracts;
using SuperZapatos.InventoryControl.WebUI.Models;
using System.Web.Mvc;
using System;
using System.Linq;
using SuperZapatos.InventoryControl.WebUI.Helpers;
using System.Diagnostics;

namespace SuperZapatos.InventoryControl.WebUI.Controllers
{
    public class ArticleController : Controller
    {
        private IArticleApplicationService _articleApplicationService;
        private IStoreAppplicationService _storeApplicationService;
       

        public ArticleController(IArticleApplicationService articleApplicationService, IStoreAppplicationService storeApplicationService)
        {
            _articleApplicationService = articleApplicationService;
            _storeApplicationService = storeApplicationService;
            ViewBag.VBStoreList = new SelectList(MappingHelper.MappingToStoreModelCollection(_storeApplicationService.GetAll().ToList()), "Id", "Name");
        }

        public ActionResult Index()
        {
            try
            {
                var articleDataModel = MappingHelper.MappingToArticleModelCollection(_articleApplicationService.GetAll().ToList());
                return View(articleDataModel);

            }
            catch (Exception ex)
            {
                Trace.TraceError(string.Concat("Error getting articles list ", ex.Message));
                return View("Error");
            }
         
        }       

        public ActionResult Details(int id)
        {
            try
            {
                var articleDetail = MappingHelper.MappingToArticleDataModel(_articleApplicationService.FindById(id));
                return View(articleDetail);
            }
            catch (Exception ex)
            {
                Trace.TraceError(string.Concat("Error getting item detail by Id ", ex.Message));
                return View("Error");
            }
         
        }

      
        public ActionResult Create()
        {
            try
            {               
                return View();
            }
            catch (Exception ex)
            {
                Trace.TraceError(string.Concat("Error getting stores list ", ex.Message));
                return View("Error");
            }
           
        }

     
        [HttpPost]
        public ActionResult Create(ArticleDataModel articleDataModel, FormCollection formCollection)
        {
            try
            {
                articleDataModel.StoreId = Convert.ToInt32(formCollection["StoreDropDown"]);             
                _articleApplicationService.Create(MappingHelper.MappingToArticleDTO(articleDataModel));
                return RedirectToAction("Index");
               
            }
            catch(Exception ex)
            {
                Trace.TraceError(string.Concat("Error creating article ", ex.Message));
                return View("Error");
            }
        }

       
        public ActionResult Edit(int id)
        {
            try
            {
                var articleDataModel = MappingHelper.MappingToArticleDataModel(_articleApplicationService.FindById(id));
                return View(articleDataModel);
            }
            catch (Exception ex)
            {
                Trace.TraceError(string.Concat("Error loading editables articles ", ex.Message));
                return View("Error");
            }
           
        }

    
        [HttpPost]
        public ActionResult Edit(ArticleDataModel articleDataModel, FormCollection collection)
        {
            try
            {
                articleDataModel.StoreId = Convert.ToInt32(collection["StoreDropDown"]);
                _articleApplicationService.Update(MappingHelper.MappingToArticleDTO(articleDataModel));        
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                Trace.TraceError(string.Concat("Error updating article ", ex.Message));
                return View("Error");
            }
        }

      
        public ActionResult Delete(int id)
        {
            try
            {
                var article = MappingHelper.MappingToArticleDataModel(_articleApplicationService.FindById(id));
                return View(article);
            }
            catch(Exception ex)
            {
                Trace.TraceError(string.Concat("Error loading article to delete ", ex.Message));
                return View("Error");
            }
        }
    
        [HttpPost]
        public ActionResult Delete(ArticleDataModel article)
        {
            try
            {
                var articleDto = MappingHelper.MappingToArticleDataModel(_articleApplicationService.FindById(article.Id));
                _articleApplicationService.Delete(MappingHelper.MappingToArticleDTO(article));
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                Trace.TraceError(string.Concat("Error deleting article ", ex.Message));
                return View("Error");
            }
        }

     
    }
}
