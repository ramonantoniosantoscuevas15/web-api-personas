using web_api_personas.Entidades;

namespace web_api_personas.DTOs
{
    public class Personadto
    {
        public int Id { get; set; }
        public required string nombre { get; set; } = null!;
        public required string apellido { get; set; } = null!;
        public DateTime? fechanacimiento { get; set; }
        public int? cedula { get; set; }
        public List<Correodto> Correos { get; set; } = new List<Correodto>();
        public List<Dirrecciondto>  Dirrecciones { get; set; } = new List<Dirrecciondto>();
        public List<Telefonodto> Telefonos { get; set; } = new List<Telefonodto>();
        //public List<Categoria> Categorias { get; set; } = new List<Categoria>();

    }
}
