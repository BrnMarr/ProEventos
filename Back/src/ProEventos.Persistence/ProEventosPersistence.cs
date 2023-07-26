using Microsoft.EntityFrameworkCore;
using ProEventos.Domain.models;
using ProEventos.Persistentece.Data;

namespace Back.src.ProEventos.Persistence
{
    public class ProEventosPersistence : IProEventosPersistence
    {
        private readonly ProEventosContext _context;
        public ProEventosPersistence(ProEventosContext context)
        {
            _context = context;
        }

        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }
    
        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public void DeleteRange<T>(T entityArray) where T : class
        {
           _context.RemoveRange(entityArray);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
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

        public async Task<Evento> GetEventoByIdAsync(int EventoId, bool includePalestrantes = false)
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

             query = query.OrderBy(e => e.Id).Where(e => e.Id == EventoId);
           
             return await query.FirstOrDefaultAsync();
        }
    

        public async Task<Palestrante> GetPalestranteByIdAsync(int PalestranteId, bool includeEventos = false)
        {
            IQueryable<Palestrante> query = _context.Palestrantes           
             .Include(e => e.RedeSociais);
             
             if(includeEventos)
             {               
                 query = query
                .Include(e => e.PalestranteEventos)
                .ThenInclude(pa => pa.Eventos);   
             }

             query = query.OrderBy(e => e.Id).Where(e => e.Id == PalestranteId);
           
             return await query.FirstOrDefaultAsync();
        }

        public async Task<Palestrante[]> GetAllPalestrantesAsync(bool includeEventos = false)
        {
            IQueryable<Palestrante> query = _context.Palestrantes           
             .Include(e => e.RedeSociais);
             
             if(includeEventos)
             {               
                 query = query
                .Include(e => e.PalestranteEventos)
                .ThenInclude(pa => pa.Eventos);   
             }

             query = query.OrderBy(e => e.Id);
           
             return await query.ToArrayAsync();
        }

        public Task<Palestrante[]> GetAllPalestrantesByNomeAsync(string nome, bool includeEventos)
        {
            throw new NotImplementedException();
        }
    
    }
}