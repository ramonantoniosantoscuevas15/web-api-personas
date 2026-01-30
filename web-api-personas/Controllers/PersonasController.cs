using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;
using web_api_personas.DTOs;
using web_api_personas.Entidades;

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
        [HttpPost]
        public async Task <IActionResult> Post( CrearPersonadto crearpersonadto)
        {
            var persona = mapper.Map<Persona>(crearpersonadto);
            context.Add(persona);
            await context.SaveChangesAsync();
            return CreatedAtRoute("AgregarPersona", new {id= persona.Id},persona);
        }
        [HttpGet("{id:int}", Name = "AgregarPersona")]
        [OutputCache(Tags = [cacheTag])]
        [HttpDelete]
        public void Delete()
        {
            // Lógica para manejar la solicitud DELETE a /api/personas
        }
    }
}
