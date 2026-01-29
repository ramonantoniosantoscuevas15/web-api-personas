using Microsoft.EntityFrameworkCore;
using web_api_personas.Entidades;

namespace web_api_personas
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CategoriaPersona>().HasKey(c => new { c.categoriaId,c.personaId });
            
        }
        public DbSet<Persona> Personas { get; set; }
        public DbSet<Correo> Correos { get; set; }
        public DbSet<Dirreccion> Dirrecciones { get; set; }
        public DbSet<Telefono> Telefonos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<CategoriaPersona> CategoriaPersonas { get; set; }

        protected ApplicationDbContext()
        {
        }
    }
}
