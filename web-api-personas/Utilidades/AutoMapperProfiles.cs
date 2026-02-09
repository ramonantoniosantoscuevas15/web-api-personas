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
            CreateMap<Categoria,Categoriadto>();
        }
        private void ConfigurarMappeoPersonas()
        {
            CreateMap<CrearPersonadto, Persona>().ForMember(
                entidad => entidad.Correos,
                dto => dto.MapFrom(dto => dto.Correos)
            ).ForMember(
                entidad => entidad.Dirreciones,
                dto => dto.MapFrom(dto => dto.Dirrecciones)
            ).ForMember(
                entidad => entidad.Telefonos,
                dto => dto.MapFrom(dto => dto.Telefonos)
            )
            .ForMember
            (
                entidad => entidad.CategoriaPersonas, dto =>
               dto.MapFrom(cp => cp.CategoriasId!.Select(id => new CategoriaPersona { categoriaId = id }))

            );
            CreateMap<CrearCorreodto, Correo>();
            CreateMap<CrearDirrecciondto, Dirreccion>();
            CreateMap<CrearTelefonodto, Telefono>();
            CreateMap<CrearPersonadto, Personadto>();


            CreateMap<Persona, Personadto>()
            .ForMember(
                entidad => entidad.Correos,
                dto => dto.MapFrom(dto => dto.Correos)
            ).ForMember(
                entidad => entidad.Dirrecciones,
                dto => dto.MapFrom(dto => dto.Dirreciones)
            ).ForMember(
                entidad => entidad.Telefonos,
                dto => dto.MapFrom(dto => dto.Telefonos)
            );
            //.ForMember(
            //    entidad => entidad.Categorias,
            //    dto => dto.MapFrom(dto => dto.CategoriaPersonas)
            //);
            

            CreateMap<Correo, Correodto>();
            CreateMap<Dirreccion, Dirrecciondto>();
            CreateMap<Telefono, Telefonodto>();
        }
    }
}
