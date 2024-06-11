using System.ComponentModel.DataAnnotations;

namespace MiPrimerAppMVC2.Models
{
    public class Producto
    {

        public int Id { get; set; }

        [Required(ErrorMessage ="El nombre es requerido")]
        [Display(Name ="Nombre")]
        public string? Nombre { get; set; }

        [Required]
        [Display(Name ="Descripcion")]
        public string? Descripcion { get; set; }

        [Required]
        [Display(Name ="Precio")]
        public decimal Precio { get; set; }

        [Display(Name ="Activo")]
        public bool Activo { get; set; }

        [Display(Name ="Fecha de alta")]
        public DateTime FechaDeAlta { get; set; }



    }
}
