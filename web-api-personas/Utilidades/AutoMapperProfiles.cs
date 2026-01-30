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
            ConfigurarMappeoPersonas();

        }
        private void CofigurarMappeoCategorias()
        {
            CreateMap<CrearCategoriadto,Categoria>();
        }
        private void ConfigurarMappeoPersonas()
        {
            CreateMap<CrearPersonadto,Persona>().ForMember(
                entidad => entidad.Correos,
                dto => dto.MapFrom( dto => dto.Correos)
            ).ForMember(
                entidad => entidad.Dirreciones,
                dto => dto.MapFrom( dto => dto.Dirrecciones)
            ).ForMember(
                entidad => entidad.Telefonos,
                dto => dto.MapFrom( dto => dto.Telefonos)
            );
            CreateMap<CrearCorreodto, Correo>();
            CreateMap<CrearDirrecciondto, Dirreccion>();
            CreateMap<CrearTelefonodto, Telefono>();
        }
    }
}
