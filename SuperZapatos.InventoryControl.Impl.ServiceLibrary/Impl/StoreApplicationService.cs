using System;
using System.Collections.Generic;
using SuperZapatos.InventoryControl.Contracts.ServiceLibrary.Contracts;
using SuperZapatos.InventoryControl.Contracts.ServiceLibrary.DTOs;
using SuperZapatos.InventoryContro.Library.InfrastructureContracts;
using System.Linq;
using SuperZapatos.InvetoryControl.Infrastructure.UnitOfWorks;
using SuperZapatos.InventoryControl.Impl.ServiceLibrary.Helpers;

namespace SuperZapatos.InventoryControl.Impl.ServiceLibrary.Impl
{
    public class StoreApplicationService : IStoreAppplicationService, IDisposable
    {
        protected IInventoryControlUnitOfWork _inventoryControlUnitOfWork;

        public StoreApplicationService()
        {
            _inventoryControlUnitOfWork = new InventoryControlUnitOfWork();
        }

        public int Create(StoreDTO storeDto)
        {
            var storeEntity = MappingHelper.MappingToStoreEntity(storeDto);
            MappingHelper.MappingToStoreDto(_inventoryControlUnitOfWork.StoreRepository.Create(storeEntity));
            return _inventoryControlUnitOfWork.SaveChanges();
            
        }      

        public int Delete(StoreDTO storeDto)
        {
            var storeEntity = MappingHelper.MappingToStoreEntity(storeDto);
            _inventoryControlUnitOfWork.StoreRepository.Delete(storeEntity);
            return _inventoryControlUnitOfWork.SaveChanges();
        }       

        public StoreDTO FindById(int id)
        {
            return MappingHelper.MappingToStoreDto(_inventoryControlUnitOfWork.StoreRepository.Find(id));
        }

        public IEnumerable<StoreDTO> GetAll()
        {
            return MappingHelper.MappingToStoreDtoCollection(_inventoryControlUnitOfWork.StoreRepository.GetAll().ToList());
        }      

        public int Update(StoreDTO storeDto)
        {
            var storeEntity = MappingHelper.MappingToStoreEntity(storeDto);
            _inventoryControlUnitOfWork.StoreRepository.Update(storeEntity);
            return _inventoryControlUnitOfWork.SaveChanges();
          
        }

        public void Dispose()
        {
            if (_inventoryControlUnitOfWork != null)
                _inventoryControlUnitOfWork.Dispose();
        }

  

    }
}
