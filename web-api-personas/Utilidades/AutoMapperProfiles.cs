using AutoMapper;
using web_api_personas.DTOs;
using web_api_personas.Entidades;

namespace web_api_personas.Utilidades
{
    public class AutoMapperProfiles: Profile
    {
        public AutoMapperProfiles()
        {
            CofigurarMappeoCategorias();    

        }
        private void CofigurarMappeoCategorias()
        {
            CreateMap<CrearCategoriadto,Categoria>();
        }
    }
}
