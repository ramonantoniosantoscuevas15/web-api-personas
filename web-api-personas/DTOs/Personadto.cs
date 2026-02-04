namespace web_api_personas.DTOs
{
    public class Personadto
    {
        public int Id { get; set; }
        public required string nombre { get; set; } = null!;
        public required string apellido { get; set; } = null!;
        public DateTime? fechanacimiento { get; set; }
        public int? cedula { get; set; }
        public List<Correodto> Correos { get; set; } = null!;
        public List<Dirrecciondto>  Dirrecciones { get; set; } = null!;
        public List<Telefonodto> Telefonos { get; set; } = null!;
    }
}
