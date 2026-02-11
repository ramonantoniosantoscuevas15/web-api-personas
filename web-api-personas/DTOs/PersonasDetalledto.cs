namespace web_api_personas.DTOs
{
    public class PersonasDetalledto : Personadto
    {
        public List<Categoriadto> Categorias { get; set; } = new List<Categoriadto>();
    }
}
