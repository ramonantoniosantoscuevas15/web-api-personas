namespace web_api_personas.Entidades
{
    public class CategoriaPersona
    {
        public int personaId { get; set; }
        public int categoriaId { get; set; }
        public Persona Persona { get; set; } = null!;
        public Categoria Categoria { get; set; } = null!;

    }
}
