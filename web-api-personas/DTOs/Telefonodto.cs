namespace web_api_personas.DTOs
{
    public class Telefonodto
    {
        public int Id { get; set; }
        public string? tiponumero { get; set; }
        public string? codigopais { get; set; }
        public required int numero { get; set; }
        public int PersonaId { get; set; }
    }
}
