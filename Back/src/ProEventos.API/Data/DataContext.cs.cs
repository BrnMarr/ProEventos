
using Microsoft.EntityFrameworkCore;
using ProEventos.API.models;

namespace Back.src.ProEventos.API.Data
{    
   public class DataContext : DbContext
   {
        public DataContext(DbContextOptions<DataContext> optinons) : base(optinons) {}     
       public DbSet<Evento> Eventos { get; set; }

   }
}