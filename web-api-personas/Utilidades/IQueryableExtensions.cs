using web_api_personas.DTOs;

namespace web_api_personas.Utilidades
{
    public static class IQueryableExtensions
    {
        public static IQueryable<T> Paginar<T> (this IQueryable<T> queryable, Paginaciondto paginacion) 
        {
            return queryable
                .Skip((paginacion.Pagina - 1) * paginacion.RecordsPorPagina)
                .Take(paginacion.RecordsPorPagina);
        }
    }
}
