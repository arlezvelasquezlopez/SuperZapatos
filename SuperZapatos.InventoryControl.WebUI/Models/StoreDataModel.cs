using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SuperZapatos.InventoryControl.WebUI.Models
{
    public class StoreDataModel
    {
        public int Id { get; set; }

        [DisplayName("Dirección")]
        [Required(ErrorMessage = "La dirección de la tienda es requerida")]
        public string Address { get; set; }


        [DisplayName("Nombre")]
        [Required(ErrorMessage = "El nombre de la tienda es requerido")]
        public string Name { get; set; }
    }
}