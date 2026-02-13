namespace web_api_personas.DTOs
{
    public class PersonasPutgetdto
    {
        public Personadto Persona { get; set; } = null!;
        public List<Categoriadto> categoriasSeleccionadas { get; set; } = new List<Categoriadto>();
        public List<Categoriadto> categoriasNoSeleccionadas { get; set; } = new List<Categoriadto>();
    }
}
