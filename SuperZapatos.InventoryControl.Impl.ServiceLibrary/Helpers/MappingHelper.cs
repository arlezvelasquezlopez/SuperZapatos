using SuperZapatos.InventoryContro.Library.Entities;
using SuperZapatos.InventoryControl.Contracts.ServiceLibrary.DTOs;
using System.Collections.Generic;

namespace SuperZapatos.InventoryControl.Impl.ServiceLibrary.Helpers
{
    public static class MappingHelper
    {
        public static Store MappingToStoreEntity(StoreDTO storeDto)
        {
            return new Store
            {
                Id = storeDto.Id,
                Address = storeDto.Address,
                Name = storeDto.Name
            };
        }

        public static StoreDTO MappingToStoreDto(Store store)
        {
            return new StoreDTO
            {
                Id = store.Id,
                Address = store.Address,
                Name = store.Name
            };
        }

        public static IEnumerable<StoreDTO> MappingToStoreDtoCollection(List<Store> queryable)
        {
            List<StoreDTO> storeDtoList = new List<StoreDTO>();
            queryable.ForEach(x => { storeDtoList.Add(MappingToStoreDto(x)); });
            return storeDtoList;
        }

        public static Article MappingToArticleEntity(ArticleDTO articleDto)
        {
            return new Article
            {
                Id = articleDto.Id,
                Description = articleDto.Description,
                Name = articleDto.Name,
                Price = articleDto.Price,
                StoreId = articleDto.StoreId,
                TotalInShelf = articleDto.TotalInShelf,
                TotalInVault = articleDto.TotalInVault, 
              
               
            };
        }

        public static ArticleDTO MappingToArticleDto(Article article)
        {
            return new ArticleDTO
            {
                Id = article.Id,
                Description = article.Description,
                Name = article.Name,
                Price = article.Price,
                StoreId = article.StoreId,
                TotalInShelf = article.TotalInShelf,
                TotalInVault = article.TotalInVault, 
                Store = MappingToStoreDto(article.Store)
               
            };
        }

        public static IEnumerable<ArticleDTO> MappingToArticleDtoCollection(List<Article> queryable)
        {
            List<ArticleDTO> ArticleDtoList = new List<ArticleDTO>();
            queryable.ForEach(x => { ArticleDtoList.Add(MappingToArticleDto(x)); });
            return ArticleDtoList;
        }
    }
}
