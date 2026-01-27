using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace web_api_personas.Controllers
{
    [Route("api/categorias")]
    [ApiController]
    public class CategoriasController : ControllerBase
    {
        [HttpPost]
        public void Post()
        {
            // Lógica para manejar la solicitud POST a /api/categorias
        }
        [HttpGet]
        public void Get()
        {
            // Lógica para manejar la solicitud GET a /api/categorias
        }
        [HttpDelete]
        public void Delete()
        {
            // Lógica para manejar la solicitud DELETE a /api/categorias
        }
    }
}
