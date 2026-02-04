namespace web_api_personas.DTOs
{
    public class Dirrecciondto
    {
       public int Id { get; set; }
       public string? tipodirrecion { get; set; }
       public required string ubicacion { get; set; }
       public required string ciudad { get; set; }
       public required string provincia { get; set; }
       public required string codigopostal { get; set; }
       public required string pais { get; set; }
       public int PersonaId { get; set; }
    }
}
