using System.ComponentModel.DataAnnotations;

namespace web_api_personas.Entidades
{
    public class Categoria
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public required string tipo { get; set; } = null!;

        //public List<CategoriaPersona> CategoriaPersonas { get; set; } = new List<CategoriaPersona>();
    }
}
