namespace web_api_personas.DTOs
{
    public class PersonasFiltrodto
    {
        public int Pagina { get; set; }
        public int RecordsPorPagina { get; set; }
        internal Paginaciondto Paginacion {get{
                return new Paginaciondto() { Pagina = Pagina, RecordsPorPagina = RecordsPorPagina };
            } }
        public string? nombre { get; set; }
        public int CategoriasId { get; set; }
    }
}
