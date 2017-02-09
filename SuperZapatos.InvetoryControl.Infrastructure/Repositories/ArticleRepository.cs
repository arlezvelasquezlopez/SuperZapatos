using SuperZapatos.InventoryContro.Library.Entities;
using SuperZapatos.InventoryContro.Library.InfrastructureContracts;
using SuperZapatos.InvetoryControl.Infrastructure.Context;

namespace SuperZapatos.InvetoryControl.Infrastructure.Repositories
{
    public class ArticleRepository: Repository<Article>, IArticleRepository
    {
        public ArticleRepository(InventoryControlContext context) : base(context) { }

    }
}
