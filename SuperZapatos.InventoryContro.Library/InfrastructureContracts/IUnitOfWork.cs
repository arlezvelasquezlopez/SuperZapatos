using System;

namespace SuperZapatos.InventoryContro.Library.InfrastructureContracts
{
    public interface IUnitOfWork: IDisposable
    {
        int SaveChanges();
    }
}
