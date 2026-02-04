using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;
using Microsoft.EntityFrameworkCore;
using web_api_personas.DTOs;
using web_api_personas.Entidades;
using web_api_personas.Utilidades;

namespace web_api_personas.Controllers
{
    [Route("api/personas")]
    [ApiController]
    public class PersonasController : ControllerBase
    {
        private readonly IOutputCacheStore outputCacheStore;
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;
        private const string cacheTag = "personas";

        public PersonasController(IOutputCacheStore outputCacheStore, ApplicationDbContext context, IMapper mapper)
        {
            this.outputCacheStore = outputCacheStore;
            this.context = context;
            this.mapper = mapper;
            
        }
        [HttpGet] //api/personas
        [OutputCache(Tags = [cacheTag])]
        public async Task <List<Personadto>> Get([FromQuery] Paginaciondto paginacion)
        {
            var queryable = context.Personas;
            await HttpContext.InsertarParametrosPaginacionEncabecera(queryable);
            return await queryable
                .OrderBy(p=>p.nombre)
                .Paginar(paginacion)
                .ProjectTo<Personadto>(mapper.ConfigurationProvider).ToListAsync();

        }
        [HttpPost]
        public async Task <IActionResult> Post(CrearPersonadto crearpersonadto)
        {
            var persona = mapper.Map<Persona>(crearpersonadto);
            context.Add(persona);
            await context.SaveChangesAsync();
            await outputCacheStore.EvictByTagAsync(cacheTag,default);
            var personaDto = mapper.Map<Personadto>(persona);
            return CreatedAtRoute("AgregarPersona", new {id = persona.Id}, personaDto);
        }
        [HttpGet("{id:int}", Name = "AgregarPersona")]
        [OutputCache(Tags = [cacheTag])]
        public async Task <ActionResult<Personadto>> Get(int id)
        {
            var persona = await context.Personas
                .ProjectTo<Personadto>(mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(p => p.Id == id);
            if (persona is null)
            {
                return NotFound();
            }
            return persona;
        }
        [HttpGet("PostCategoria")]
        public async Task <ActionResult<CategoriaPersonadto>> PostCategoria()
        {
            var categorias = await context.Categorias
                .ProjectTo<Categoriadto>(mapper.ConfigurationProvider)
                .ToListAsync(); 
            return new CategoriaPersonadto { Categorias = categorias };
        }
        [HttpDelete]
        public void Delete()
        {
            // Lógica para manejar la solicitud DELETE a /api/personas
        }
    }
}
