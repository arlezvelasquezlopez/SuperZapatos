using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SuperZapatos.InventoryContro.Library.Entities
{
    public class Store
    {
        [Key]
        [Column("id")]
        [Required]

        public int Id { get; set; }

        [Column("address")]
        [Required]
        [MaxLength(50)]
        public string Address { get; set; }

        [Column("name")]
        [MaxLength(50)]
        [Required]
        public string Name { get; set; }
    }
}