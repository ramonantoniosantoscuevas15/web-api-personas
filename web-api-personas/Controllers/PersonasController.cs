using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;
using Microsoft.EntityFrameworkCore;
using System.Linq;
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
        [HttpGet("Filtro")]//api/personas/filtro
        [OutputCache(Tags = [cacheTag])]
        public async Task<List<Personadto>> Filtrar([FromQuery] PersonasFiltrodto personasFiltrodto)
        {
            var personasQueryable = context.Personas.AsQueryable();
            if(!string.IsNullOrWhiteSpace(personasFiltrodto.nombre))
            {
                personasQueryable = personasQueryable.Where(p => p.nombre.Contains(personasFiltrodto.nombre));
            }
            if (personasFiltrodto.CategoriasId!=0)
            {
                personasQueryable = personasQueryable.Where(p => p.CategoriaPersonas.Select(cp => cp.categoriaId).Contains(personasFiltrodto.CategoriasId));

            }
            await HttpContext.InsertarParametrosPaginacionEncabecera(personasQueryable);
            var perosnas = await personasQueryable.Paginar(personasFiltrodto.Paginacion)
                .ProjectTo<Personadto>(mapper.ConfigurationProvider).ToListAsync();
            return perosnas;


            //return await context.Personas
            //    .Where(p => p.Correos.Select(c => c.PersonaId).Contains(p.Id) &&
            //                p.Dirreciones.Select(d => d.PersonaId).Contains(p.Id) &&
            //                p.Telefonos.Select(t => t.PersonaId).Contains(p.Id) &&
            //                p.CategoriaPersonas.Select(cp => cp.personaId).Contains(p.Id)
            //                )


            //    .OrderBy(p => p.nombre)

            //    .ProjectTo<Personadto>(mapper.ConfigurationProvider).ToListAsync();

        }
        [HttpGet] //api/personas
       


        [HttpGet("listado")] //api/personas/listado
        [OutputCache(Tags = [cacheTag])]

        public async Task <List<Personadto>> Get([FromQuery] Paginaciondto paginacion)
        {
            var queryable = context.Personas;
            await HttpContext.InsertarParametrosPaginacionEncabecera(queryable);
            return await queryable
                .Where(p =>p.Correos.Select(c => c.PersonaId).Contains(p.Id) &&
                            p.Dirreciones.Select(d => d.PersonaId).Contains(p.Id) &&
                            p.Telefonos.Select(t => t.PersonaId).Contains(p.Id) &&
                            p.CategoriaPersonas.Select(cp => cp.personaId).Contains(p.Id)
                            )
                            

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
        [HttpGet("Putget/{id:int}")]
        public async Task <ActionResult<PersonasPutgetdto>> Putget(int id)
        {
            var persona = await context.Personas
                .ProjectTo<Personadto>(mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(p => p.Id == id);
            if (persona is null)
            {
                NotFound();
            }
           
            var categoriasSeleccionadasId = persona!.Categorias.Select(c => c.Id).ToList();
            var categoriasNoSeleccionadas = await context.Categorias.Where(g =>
            !categoriasSeleccionadasId.Contains(g.Id))
                .ProjectTo<Categoriadto>(mapper.ConfigurationProvider)
                .ToListAsync();
            var respuesta = new PersonasPutgetdto();
            respuesta.Persona = persona;
            respuesta.categoriasSeleccionadas = persona.Categorias;
            respuesta.categoriasNoSeleccionadas = categoriasNoSeleccionadas;
            return respuesta;


        }
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Put(int id, [FromBody] CrearPersonadto crearPersonadto)
        {
            var persona = await context.Personas
                .Include(p => p.CategoriaPersonas)
                .FirstOrDefaultAsync(p => p.Id == id);
            if(persona == null)
            {
                return NotFound();
            }
            persona = mapper.Map(crearPersonadto, persona);
            await context.SaveChangesAsync();
            await outputCacheStore.EvictByTagAsync(cacheTag, default);
            return NoContent();

        }
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var registrosBorrados = await context.Personas
                .Where(p => p.Id == id)
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
