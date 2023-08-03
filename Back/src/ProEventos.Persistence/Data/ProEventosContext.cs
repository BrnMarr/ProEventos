
using Microsoft.EntityFrameworkCore;
using ProEventos.Domain.models;

namespace ProEventos.Persistence.Data
{    
   public class ProEventosContext : DbContext
   {
        public ProEventosContext(DbContextOptions<ProEventosContext> optinons) : base(optinons) {}     
        public DbSet<Evento> Evento { get; set; }
        public DbSet<Palestrante> Palestrantes { get; set; }
        public DbSet<Lote> Lotes { get; set; }
        public DbSet<PalestranteEvento> PalestranteEventos { get; set; }
        public DbSet<RedeSocial> RedeSociais { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
         modelBuilder.Entity<PalestranteEvento>()
                  .HasKey(pe => new {pe.EventoId, pe.PalestranteId});
        }
 
   }
}