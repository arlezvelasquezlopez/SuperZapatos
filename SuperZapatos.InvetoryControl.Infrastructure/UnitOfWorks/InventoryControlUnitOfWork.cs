using System;
using SuperZapatos.InventoryContro.Library.InfrastructureContracts;
using SuperZapatos.InvetoryControl.Infrastructure.Context;
using SuperZapatos.InvetoryControl.Infrastructure.Repositories;

namespace SuperZapatos.InvetoryControl.Infrastructure.UnitOfWorks
{
    public class InventoryControlUnitOfWork : IInventoryControlUnitOfWork
    {
        private InventoryControlContext dbContext;
        private IArticleRepository _articleRepository;
        private IStoreRepository _storeRepository;

        public InventoryControlUnitOfWork()
        {
            dbContext = new InventoryControlContext();
        }

        public IArticleRepository ArticleRepository
        {
            get
            {
                if (_articleRepository == null)
                    _articleRepository = new ArticleRepository(dbContext);
                return _articleRepository;
            }            
        }

        public IStoreRepository StoreRepository
        {
            get
            {
                if (_storeRepository == null)
                    _storeRepository = new StoreRepository(dbContext);
                return _storeRepository;
            }

        }

        public void Dispose()
        {
            if (_articleRepository != null)
                _articleRepository.Dispose();
            if (_storeRepository != null)
                _storeRepository.Dispose();
            if (dbContext != null)
                dbContext.Dispose();
            GC.SuppressFinalize(this);
        }

        public int SaveChanges()
        {
            return dbContext.SaveChanges();
        }
    }
}
