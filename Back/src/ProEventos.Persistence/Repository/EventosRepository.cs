using Microsoft.EntityFrameworkCore;
using ProEventos.Domain.models;
using ProEventos.Persistence.Interface;
using ProEventos.Persistence.Data;

namespace ProEventos.Persistence.Repository
{
    public class EventosRepository : IEventosPersistence
    {
        private readonly ProEventosContext _context;
        public EventosRepository(ProEventosContext context)
        {
            _context = context;
        }

        public async Task<Evento[]> GetAllEventosAsync(bool includePalestrantes = false)
        {
             IQueryable<Evento> query = _context.Evento
             .Include(e => e.Lotes)
             .Include(e => e.RedeSocials);
             
             if(includePalestrantes)
             {               
                 query = query
                .Include(e => e.PalestrantesEventos)
                .ThenInclude(pa => pa.Palestrantes);   
             }

             query = query.OrderBy(e => e.Id);
           
             return await query.ToArrayAsync();
              
        }   

        public async Task<Evento[]> GetAllEventosByTemaAsync(string tema, bool includePalestrantes = false)
        {
             IQueryable<Evento> query = _context.Evento
             .Include(e => e.Lotes)
             .Include(e => e.RedeSocials);
             
             if(includePalestrantes)
             {               
                 query = query
                .Include(e => e.PalestrantesEventos)
                .ThenInclude(pa => pa.Palestrantes);   
             }

             query = query.OrderBy(e => e.Id).Where(e => e.Tema.ToLower().Contains(tema.ToLower()));
           
             return await query.ToArrayAsync();
        }

        public async Task<Evento> GetEventoByIdAsync(int eventoId, bool includePalestrantes = false)
        {
            IQueryable<Evento> query = _context.Evento
             .Include(e => e.Lotes)
             .Include(e => e.RedeSocials);
             
             if(includePalestrantes)
             {               
                 query = query
                .Include(e => e.PalestrantesEventos)
                .ThenInclude(pa => pa.Palestrantes);   
             }

             query = query.OrderBy(e => e.Id).Where(e => e.Id == eventoId);
           
             return await query.FirstOrDefaultAsync();
        }
       
    }
}