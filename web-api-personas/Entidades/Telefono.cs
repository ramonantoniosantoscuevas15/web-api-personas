using System.ComponentModel.DataAnnotations;

namespace web_api_personas.Entidades
{
    public class Telefono
    {
        public int Id { get; set; }
        public string ? tipo { get; set; } 
        
        public string ? codigopais { get; set; } 
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Range (7,20,ErrorMessage = "El campo {0} debe estar entre {1} y {2} digitos")]

        public required int  numero { get; set; }
        //public Persona Persona { get; set; } = null!;   
        //public int personaId { get; set; }
    }
}
