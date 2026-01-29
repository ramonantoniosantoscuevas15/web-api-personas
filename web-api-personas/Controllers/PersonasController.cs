using Microsoft.AspNetCore.Mvc;
using web_api_personas.DTOs;
using web_api_personas.Entidades;

namespace web_api_personas.Controllers
{
    [Route("api/personas")]
    [ApiController]
    public class PersonasController : ControllerBase
    {
        
        
        public PersonasController() { }
        [HttpPost]
        public IActionResult Post(CrearPersonadto personadto)
        {
            // Lógica para manejar la solicitud POST a /api/personas
            return Ok();
        }
        [HttpDelete]
        public void Delete()
        {
            // Lógica para manejar la solicitud DELETE a /api/personas
        }
    }
}
