using System.ComponentModel.DataAnnotations;

namespace web_api_personas.Entidades
{
    public class Dirreccion
    {
        public int Id { get; set; }
        public string ? tipo { get; set; } 
        [Required (ErrorMessage = "El campo {0} es requerido")]
        public required string ubicacion { get; set; } 
        [Required (ErrorMessage = "El campo {0} es requerido")]
        public required string ciudad { get; set; } 
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public required string provincia { get; set; } 
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public required string codigopostal { get; set; } 
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public required string pais { get; set; } = null!;
        //public Persona Persona { get; set; } = null!;   
        //public int personaId { get; set; }
    }
}
