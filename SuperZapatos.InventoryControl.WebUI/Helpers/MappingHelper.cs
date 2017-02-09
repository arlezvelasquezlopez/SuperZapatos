using SuperZapatos.InventoryControl.Contracts.ServiceLibrary.DTOs;
using SuperZapatos.InventoryControl.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SuperZapatos.InventoryControl.WebUI.Helpers
{
    public static class MappingHelper
    {
        public static List<ArticleDataModel> MappingToArticleModelCollection(List<ArticleDTO> enumerable)
        {
            var articleDataModelList = new List<ArticleDataModel>();
            enumerable.ForEach(x => { articleDataModelList.Add(MappingToArticleDataModel(x)); });
            return articleDataModelList;
        }

        public static ArticleDataModel MappingToArticleDataModel(ArticleDTO article)
        {
            return new ArticleDataModel
            {
                Id = article.Id,
                Description = article.Description,
                Name = article.Name,
                Price = article.Price,
                StoreId = article.StoreId,
                TotalInShelf = article.TotalInShelf,
                TotalInVault = article.TotalInVault, 
                Store = MappingToStoreDataModel(article.Store)
               
            };
        }

        public static ArticleDTO MappingToArticleDTO(ArticleDataModel articleDataModel)
        {
            return new ArticleDTO
            {
                Id = articleDataModel.Id,
                Description = articleDataModel.Description,
                Name = articleDataModel.Name,
                Price = articleDataModel.Price,
                StoreId = articleDataModel.StoreId,
                TotalInShelf = articleDataModel.TotalInShelf,
                TotalInVault = articleDataModel.TotalInVault
            };
        }

        public static List<StoreDataModel> MappingToStoreModelCollection(List<StoreDTO> enumerable)
        {
            var StoreDataModelList = new List<StoreDataModel>();
            enumerable.ForEach(x => { StoreDataModelList.Add(MappingToStoreDataModel(x)); });
            return StoreDataModelList;
        }

        public static StoreDataModel MappingToStoreDataModel(StoreDTO Store)
        {
            return new StoreDataModel
            {
                Id = Store.Id,
                Name = Store.Name,
                Address = Store.Address

            };
        }

        public static StoreDTO MappingToStoreDTO(StoreDataModel storeDataModel)
        {
            return new StoreDTO
            {
                Id = storeDataModel.Id,
                Name = storeDataModel.Name,
                Address = storeDataModel.Address

            };
        }

    }
}