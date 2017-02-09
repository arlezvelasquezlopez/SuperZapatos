using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SuperZapatos.InventoryControl.WebUI.Models
{
    public class ArticleDataModel
    {
        public int Id { get; set; }

        [DisplayName("Nombre")]
        [Required (ErrorMessage ="El nombre del artículo es requerido")]
        public string Name { get; set; }

        [DisplayName("Descripción")]
        [Required(ErrorMessage = "El descripción del artículo es requerido")]
        public string Description { get; set; }

        [DisplayName("Precio")]
        [Required(ErrorMessage = "El precio del artículo es requerido")]
        [RegularExpression(@"^\$?\d+(\.(\d{2}))?$")]
        public decimal Price { get; set; }

        [DisplayName("Total en estantes")]
        [Required(ErrorMessage = "El total en estantes del artículo es requerido")]
        public int TotalInShelf { get; set; }

        [DisplayName("Total en bodega")]
        [Required(ErrorMessage = "El total en bodega del artículo es requerido")]
        public int TotalInVault { get; set; }

        [DisplayName("Tienda asociada")]
        public int StoreId { get; set; }

        [DisplayName("Tienda asociada")]       
        public StoreDataModel Store { get; set; }
       
    }
}