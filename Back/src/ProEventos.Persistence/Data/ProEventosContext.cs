
using Microsoft.EntityFrameworkCore;
using ProEventos.Domain.models;

namespace ProEventos.Persistence.Data
{    
   public class ProEventosContext : DbContext
   {
        public ProEventosContext(DbContextOptions<ProEventosContext> optinons) : base(optinons) {}     
        public DbSet<Evento> Eventos { get; set; }
        public DbSet<Palestrante> Palestrantes { get; set; }
        public DbSet<Lote> Lotes { get; set; }
        public DbSet<PalestranteEvento> PalestranteEventos { get; set; }
        public DbSet<RedeSocial> RedeSociais { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
         modelBuilder.Entity<PalestranteEvento>()
                  .HasKey(pe => new {pe.EventoId, pe.PalestranteId});

          modelBuilder.Entity<Evento>()
                  .HasMany(e => e.RedeSociais)
                  .WithOne(rs => rs.Evento)
                  .OnDelete(DeleteBehavior.Cascade);
        
         modelBuilder.Entity<Palestrante>()
                  .HasMany(e => e.RedeSociais)
                  .WithOne(rs => rs.Palestrante)
                  .OnDelete(DeleteBehavior.Cascade);
        
        }
 
   }
}