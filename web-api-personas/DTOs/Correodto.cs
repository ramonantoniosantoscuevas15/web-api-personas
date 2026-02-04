namespace web_api_personas.DTOs
{
    public class Correodto
    {
        public int Id { get; set; }
        public string Correos { get; set; } = null!;

        public int PersonaId { get; set; }  
    }
}
