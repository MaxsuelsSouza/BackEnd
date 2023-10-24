using AgendaTelefonica.Api.Damain.Models;
using AgendaTelefonica.Api.Data.Mappings;
using Microsoft.EntityFrameworkCore;

namespace AgendaTelefonica.Api.Data
{
    public class AplicationContext : DbContext
    {
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Contatos> Contatos { get; set; }

        public AplicationContext(DbContextOptions<AplicationContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsuarioMap());
            modelBuilder.ApplyConfiguration(new ContatosMap());
        }
    }
}