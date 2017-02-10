using SuperZapatos.InventoryControl.API.XML.Models;
using SuperZapatos.InventoryControl.Contracts.ServiceLibrary.DTOs;
using System.Collections.Generic;

namespace SuperZapatos.InventoryControl.API.XML.Helpers
{
    public static class MappingHelper
    {
        public static SuccessArticleResponse SuccessArticleResponse(List<ArticleDTO> articleDTOList)
        {
            return new SuccessArticleResponse
            {
                Success = true,
                Articles = articleDTOList,
                TotalArticle = articleDTOList.Count
            };
        }

        public static SuccessStoreResponse SucessStoreResponse(List<StoreDTO> storesList)
        {
            return new SuccessStoreResponse
            {
                Success = true,
                Stores = storesList,
                TotalStores = storesList.Count
            };
        }

        public static ErrorResponse ErrorResponse(string message, int statusCode)
        {
            return new Models.ErrorResponse
            {
                Success = false,
                CodeError = statusCode,
                MessageError = message
            };
        }
    }
}