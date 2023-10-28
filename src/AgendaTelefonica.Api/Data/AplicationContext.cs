using AgendaTelefonica.Api.Damain.Models;
using AgendaTelefonica.Api.Data.Mappings;
using Microsoft.EntityFrameworkCore;

namespace AgendaTelefonica.Api.Data
{
    /// <summary>
    /// da ao entity funçao de controlar a class usuario e contatos
    /// </summary>
    public class AplicationContext : DbContext
    {
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Contatos> Contatos { get; set; }

        public AplicationContext(DbContextOptions<AplicationContext> options) : base(options) { }

        /// <summary>
        /// o entity quando for criar qualquer coisa, vai se basear no usuarioMap 
        /// </summary>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsuarioMap());
            modelBuilder.ApplyConfiguration(new ContatosMap());
        }
    }
}