namespace web_api_personas.Entidades
{
    public class Telefono
    {
        public int Id { get; set; }
        public string tipo { get; set; } = null!;
        public string codigopais { get; set; } = null!;
        public int numero { get; set; }
        public int personaId { get; set; }
    }
}
