using System.ComponentModel.DataAnnotations;

namespace web_api_personas.Entidades
{
    public class Correo
    {
        public int Id { get; set; }
        [Required (ErrorMessage = "El campo {0} es requerido")]
        public required string correos { get; set; } 
        //public Persona Persona { get; set; } = null!;
        //public int personaId { get; set; }
    }
}
