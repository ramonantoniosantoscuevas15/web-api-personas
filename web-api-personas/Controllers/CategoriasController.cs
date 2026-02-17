using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Http.Timeouts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
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
        [HttpGet("todos")] //api/categorias
        [OutputCache(Tags = [cacheTag])]
        public async Task<List<Categoriadto>> Get()
        {
            
            return await context.Categorias
                .OrderBy(c => c.tipo)
                
                .ProjectTo<Categoriadto>(mapper.ConfigurationProvider).ToListAsync();

        }
        [HttpGet] //api/categorias
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
        [HttpGet("{id:int}", Name = "obtenerporid")] //api/categorias/500
        [OutputCache(Tags = [cacheTag])]
        public async Task<ActionResult<Categoriadto>> Get(int id)
        {
            var categoria = await context.Categorias.
                ProjectTo<Categoriadto>(mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(c => c.Id == id);
            if (categoria is null)
            {
                return NotFound();
            }
            return categoria;
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CrearCategoriadto categoriaCreaciondto)
        {
            var categoria = mapper.Map<Categoria>(categoriaCreaciondto);
            context.Add(categoria);
            await context.SaveChangesAsync();
            await outputCacheStore.EvictByTagAsync(cacheTag,default);
            return CreatedAtRoute("obtenerporid", new {id = categoria.Id},categoria);
        }
        
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Put( int id, [FromBody] CrearCategoriadto categoriaCreaciondto)
        {
            var categoriaexiste = await context.Categorias.AnyAsync(c => c.Id == id);

            if (!categoriaexiste)
            {
                return NotFound();
            }
            var categoria = mapper.Map<Categoria>(categoriaCreaciondto);
            categoria.Id = id;
            context.Update(categoria);
            await context.SaveChangesAsync();
            await outputCacheStore.EvictByTagAsync(cacheTag, default);
            return NoContent();
        }


        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var registrosBorrados = await context.Categorias
                .Where(c => c.Id == id)
                .ExecuteDeleteAsync();
            if (registrosBorrados == 0)
            {
                return NotFound();
            }
            await outputCacheStore.EvictByTagAsync(cacheTag, default);
            return NoContent();
        }
    }
}
