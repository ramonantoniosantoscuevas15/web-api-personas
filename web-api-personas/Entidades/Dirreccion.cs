namespace web_api_personas.Entidades
{
    public class Dirreccion
    {
        public int Id { get; set; }
        public string tipo { get; set; } = null!;   
        public string ubicacion { get; set; } = null!;
        public string ciudad { get; set; } = null!;
        public string provincia { get; set; } = null!;
        public string codigopostal { get; set; } = null!;   
        public string pais { get; set; } = null!;
        public int personaId { get; set; }
    }
}
