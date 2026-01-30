using web_api_personas.Entidades;

namespace web_api_personas.DTOs
{
    public class CrearPersonadto
    {
        public required string nombre { get; set; } = null!;
        public required string apellido { get; set; } = null!;
        public DateTime? fechanacimiento { get; set; }
        public int? cedula { get; set; }
        public List<CrearCorreodto> Correos { get; set; } = null!;
        public List<CrearDirrecciondto>  Dirrecciones { get; set; } = null!;   
        public List<CrearTelefonodto> Telefonos { get; set; } = null!;
    }
}
