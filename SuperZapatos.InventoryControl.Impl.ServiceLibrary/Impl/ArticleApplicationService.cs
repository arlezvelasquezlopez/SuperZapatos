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
    public class ArticleApplicationService : IArticleApplicationService, IDisposable
    {

        protected readonly IInventoryControlUnitOfWork _inventoryControlUnitOfWork;

        public ArticleApplicationService(IInventoryControlUnitOfWork inventoryControlUnitOfWork)
        {
            _inventoryControlUnitOfWork = inventoryControlUnitOfWork;
        }
        public int Create(ArticleDTO articleDto)
        {
            var ArticleEntity = MappingHelper.MappingToArticleEntity(articleDto);
            _inventoryControlUnitOfWork.ArticleRepository.Create(ArticleEntity);
            return _inventoryControlUnitOfWork.SaveChanges();

        }

        public int Delete(int id)
        {
            _inventoryControlUnitOfWork.ArticleRepository.Delete((_inventoryControlUnitOfWork.ArticleRepository.Find(id)));
            return _inventoryControlUnitOfWork.SaveChanges();
        }

        public ArticleDTO FindById(int id)
        {
            return MappingHelper.MappingToArticleDto(_inventoryControlUnitOfWork.ArticleRepository.Find(id));
        }

        public IEnumerable<ArticleDTO> GetAll()
        {
            return MappingHelper.MappingToArticleDtoCollection(_inventoryControlUnitOfWork.ArticleRepository.GetAll().ToList());
        }

        public int Update(ArticleDTO articleDto)
        {
            var ArticleEntity = MappingHelper.MappingToArticleEntity(articleDto);
            _inventoryControlUnitOfWork.ArticleRepository.Update(ArticleEntity);
            return _inventoryControlUnitOfWork.SaveChanges();
        }

        public void Dispose()
        {
            if (_inventoryControlUnitOfWork != null)
                _inventoryControlUnitOfWork.Dispose();
        }


    }
}
