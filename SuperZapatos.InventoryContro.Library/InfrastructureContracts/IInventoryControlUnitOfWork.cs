namespace SuperZapatos.InventoryContro.Library.InfrastructureContracts
{
    public interface IInventoryControlUnitOfWork: IUnitOfWork
    {
        IStoreRepository StoreRepository { get; }

        IArticleRepository ArticleRepository { get; }
    }
}
