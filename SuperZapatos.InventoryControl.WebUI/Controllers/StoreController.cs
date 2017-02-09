using SuperZapatos.InventoryControl.Contracts.ServiceLibrary.Contracts;
using SuperZapatos.InventoryControl.WebUI.Helpers;
using SuperZapatos.InventoryControl.WebUI.Models;
using System;
using System.Diagnostics;
using System.Linq;
using System.Web.Mvc;

namespace SuperZapatos.InventoryControl.WebUI.Controllers
{
    public class StoreController : Controller
    {

        private IStoreAppplicationService _storeApplicationService;

        public StoreController(IStoreAppplicationService storeApplicationService)
        {

            _storeApplicationService = storeApplicationService;
        }

        public ActionResult Index()
        {
            try
            {
                var storeDataModelList = MappingHelper.MappingToStoreModelCollection(_storeApplicationService.GetAll().ToList());
                return View(storeDataModelList);
            }
            catch (Exception ex)
            {
                Trace.TraceError(string.Concat("Error getting stores list ", ex.Message));
                return View("Error");
            }
        }


        public ActionResult Details(int id)
        {
            try
            {
                var storeDetail = MappingHelper.MappingToStoreDataModel(_storeApplicationService.FindById(id));
                return View(storeDetail);
            }
            catch (Exception ex)
            {
                Trace.TraceError(string.Concat("Error getting item detail by Id ", ex.Message));
                return View("Error");
            }
        }


        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Create(StoreDataModel storeDataModel)
        {
            try
            {
                _storeApplicationService.Create(MappingHelper.MappingToStoreDTO(storeDataModel));
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                Trace.TraceError(string.Concat("Error creating store ", ex.Message));
                return View("Error");
            }
        }

        public ActionResult Edit(int id)
        {
            try
            {
                var storeDataModel = MappingHelper.MappingToStoreDataModel(_storeApplicationService.FindById(id));
                return View(storeDataModel);
            }
            catch (Exception ex)
            {
                Trace.TraceError(string.Concat("Error loading editables stores ", ex.Message));
                return View("Error");
            }
        }


        [HttpPost]
        public ActionResult Edit(StoreDataModel storeDataModel, FormCollection collection)
        {
            try
            {
                _storeApplicationService.Update(MappingHelper.MappingToStoreDTO(storeDataModel));
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                Trace.TraceError(string.Concat("Error updating store ", ex.Message));
                return View("Error");
            }
        }

        public ActionResult Delete(int id)
        {
            try
            {
                var store = MappingHelper.MappingToStoreDataModel(_storeApplicationService.FindById(id));
                return View(store);
            }
            catch (Exception ex)
            {
                Trace.TraceError(string.Concat("Error loading store to delete ", ex.Message));
                return View("Error");
            }
        }


        [HttpPost]
        public ActionResult Delete(StoreDataModel storeDataModel)
        {
            try
            {

                var storeDto = MappingHelper.MappingToStoreDataModel(_storeApplicationService.FindById(storeDataModel.Id));
                _storeApplicationService.Delete(MappingHelper.MappingToStoreDTO(storeDto));
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                Trace.TraceError(string.Concat("Error deleting store ", ex.Message));
                return View("Error");
            }
        }


    }
}
