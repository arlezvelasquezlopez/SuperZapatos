using SuperZapatos.InventoryContro.Library.Entities;
using SuperZapatos.InventoryContro.Library.InfrastructureContracts;
using SuperZapatos.InvetoryControl.Infrastructure.Context;

namespace SuperZapatos.InvetoryControl.Infrastructure.Repositories
{
    public class StoreRepository: Repository<Store>, IStoreRepository
    {
        public StoreRepository(InventoryControlContext context) : base(context) { }
    }
}
