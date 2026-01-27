namespace web_api_personas.Entidades
{
    public class Correo
    {
        public int Id { get; set; }
        public string correos { get; set; } = null!;
        public int personaId { get; set; }
    }
}
