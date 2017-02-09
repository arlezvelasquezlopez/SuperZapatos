
using SuperZapatos.InventoryControl.Contracts.ServiceLibrary.DTOs;

namespace SuperZapatos.InventoryControl.Contracts.ServiceLibrary.DTOs
{
    public class ArticleDTO
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int TotalInShelf { get; set; }
        public int TotalInVault { get; set; }
        public int StoreId { get; set; }
        public virtual StoreDTO Store { get; set; }

    }
}
