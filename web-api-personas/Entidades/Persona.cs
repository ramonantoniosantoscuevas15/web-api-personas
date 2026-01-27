namespace web_api_personas.Entidades
{
    public class Persona
    {
        public int Id { get; set; }
        public string nombre { get; set; } = null!;
        public string apellido { get; set; } = null!;   
        public string cedula { get; set; } = null!;
    }
}
