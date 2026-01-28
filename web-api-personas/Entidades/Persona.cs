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
        public Correo Correo { get; set; } = null!;
        public Dirreccion Dirreccion { get; set; } = null!;
        public Telefono Telefono { get; set; } = null!;
        public List<Correo> Correos { get; set; } = new List<Correo>();
        public List<Dirreccion> Dirreciones { get; set; } = new List<Dirreccion>();
        public List<Telefono> Telefonos { get; set; } = new List<Telefono>();
        public List<CategoriaPersona> CategoriaPersonas { get; set; } = new List<CategoriaPersona>();
    }
}
