using SuperZapatos.InventoryControl.Contracts.ServiceLibrary.DTOs;
using System.Collections.Generic;

namespace SuperZapatos.InventoryControl.Contracts.ServiceLibrary.Contracts
{
    public interface IArticleApplicationService
    {
        IEnumerable<ArticleDTO> GetAll();
        ArticleDTO FindById(int id);
        int Create(ArticleDTO article);
        int Delete(ArticleDTO articleDto);
        int Update(ArticleDTO articleDto);
    }
}
