using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SuperZapatos.InventoryContro.Library.Entities
{
    public class Article
    {
        [Key]
        [Column("id")]
        [Required]      
        public int Id { get; set; }

        [Column("name")]
        [Required]
        public string Name { get; set; }

        [Column("description")]
        [Required]
        [MaxLength(300)]
        public string Description { get; set; }

        [Column("price")]
        [Required]
        public decimal Price { get; set; }

        [Column("total_in_shelf")]
        [Required]
        public int TotalInShelf { get; set; }

        [Column("total_in_vault")]
        [Required]
        public int TotalInVault { get; set; }

        [Required]
        public int StoreId { get; set; }

        [ForeignKey("StoreId")]      
        public virtual Store Store { get; set;  }
    }
}
