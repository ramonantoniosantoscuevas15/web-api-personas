using System.ComponentModel.DataAnnotations;

namespace web_api_personas.Entidades
{
    public class Persona
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Range(2,60, ErrorMessage = "El campo {0} debe estar entre {1} y {2} caracteres")]
        public required string nombre { get; set; } = null!;
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Range(2, 60, ErrorMessage = "El campo {0} debe estar entre {1} y {2} caracteres")]
        public required string apellido { get; set; } = null!;  
        public DateTime ? fechanacimiento { get; set; }
        public int ? cedula { get; set; }

        [StringLength(maximumLength:500, ErrorMessage = "El campo {0} no puede tener menos de {1} caracteres")]
        public string ? notas { get; set; }
    }
}
