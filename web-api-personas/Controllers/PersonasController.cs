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
        [HttpGet("listadopersonas")]
        //public async Task <ActionResult<Listadopersonasdto>> Get()
        //{
        //    var categorias = await context.Personas
        //        .Where(p => p.CategoriaPersonas.Select(pc => pc.personaId).Contains(p.Id))
        //        .OrderBy(p => p.nombre).ToListAsync();


        //}

        [HttpGet("listado")] //api/personas/listado
        public async Task <List<Personadto>> Get([FromQuery] Paginaciondto paginacion)
        {
            var queryable = context.Personas;
            await HttpContext.InsertarParametrosPaginacionEncabecera(queryable);
            return await queryable
                .Where(p =>p.Correos.Select(c => c.PersonaId).Contains(p.Id) &&
                            p.Dirreciones.Select(d => d.PersonaId).Contains(p.Id) &&
                            p.Telefonos.Select(t => t.PersonaId).Contains(p.Id))
                .OrderBy(p=>p.nombre)
                .Paginar(paginacion)
                .ProjectTo<Personadto>(mapper.ConfigurationProvider).ToListAsync();

        }
        [HttpPost]
        public async Task <IActionResult> Post([FromBody] CrearPersonadto crearpersonadto)
        {
            var persona = mapper.Map<Persona>(crearpersonadto);
            context.Add(persona);
            await context.SaveChangesAsync();
            await outputCacheStore.EvictByTagAsync(cacheTag,default);
            var personaDto = mapper.Map<Personadto>(persona);
            return CreatedAtRoute("Obtenerpersonaporid", new {id = persona.Id}, personaDto);
        }
        [HttpGet("{id:int}", Name = "Obtenerpersonaporid")]
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
