using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Http.Timeouts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using web_api_personas.DTOs;
using web_api_personas.Entidades;
using web_api_personas.Utilidades;

namespace web_api_personas.Controllers
{
    [Route("api/categorias")]
    [ApiController]
    public class CategoriasController : ControllerBase
    {
        private readonly IOutputCacheStore outputCacheStore;
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;
        private const string cacheTag = "categorias";
        public CategoriasController(IOutputCacheStore outputCacheStore, ApplicationDbContext context, IMapper mapper)
        {
            this.outputCacheStore = outputCacheStore;
            this.context = context;
            this.mapper = mapper;
        }
        [HttpGet]//api/categorias
        [OutputCache(Tags = [cacheTag])]
        public async Task<List<Categoriadto>> Get([FromQuery] Paginaciondto paginacion)
        {
            var queryable = context.Categorias;
            await HttpContext.InsertarParametrosPaginacionEncabecera(queryable);
            return await queryable
                .OrderBy(c => c.tipo)
                .Paginar(paginacion)
                .ProjectTo<Categoriadto>(mapper.ConfigurationProvider).ToListAsync();
            
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CrearCategoriadto categoriaCreaciondto)
        {
            var categoria = mapper.Map<Categoria>(categoriaCreaciondto);
            context.Add(categoria);
            await context.SaveChangesAsync();
            return CreatedAtRoute("agregarcategoria", new {id = categoria.Id},categoria);
        }
        [HttpGet ("{id:int}", Name = "agregarcategoria") ]
        [OutputCache(Tags = [cacheTag])]
        public async Task<ActionResult<Categoriadto>> Get(int id)
        {
            throw new NotImplementedException();
        }


        [HttpDelete]
        public void Delete()
        {
            // Lógica para manejar la solicitud DELETE a /api/categorias
        }
    }
}
