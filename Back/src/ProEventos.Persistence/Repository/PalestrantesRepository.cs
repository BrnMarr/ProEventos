using Microsoft.EntityFrameworkCore;
using ProEventos.Domain.models;
using ProEventos.Persistence.Interface;
using ProEventos.Persistentece.Data;

namespace Back.src.ProEventos.Persistence.Repository
{
    public class PalestrantesRepository : IPalestrantesPersistence
    {
        private readonly ProEventosContext _context;
        public PalestrantesRepository(ProEventosContext context)
        {
            _context = context;
        }

        public async Task<Palestrante> GetPalestranteByIdAsync(int palestranteId, bool includeEventos = false)
        {
            IQueryable<Palestrante> query = _context.Palestrantes           
             .Include(e => e.RedeSociais);
             
             if(includeEventos)
             {               
                 query = query
                .Include(e => e.PalestranteEventos)
                .ThenInclude(pa => pa.Eventos);   
             }

             query = query.OrderBy(e => e.Id).Where(e => e.Id == palestranteId);
           
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

        public async Task<Palestrante[]> GetAllPalestrantesByNomeAsync(string nome, bool includeEventos)
        {
            IQueryable<Palestrante> query = _context.Palestrantes           
             .Include(e => e.RedeSociais);
             
             if(includeEventos)
             {               
                 query = query
                .Include(e => e.PalestranteEventos)
                .ThenInclude(pa => pa.Eventos);   
             }

             query = query.OrderBy(e => e.Id).Where(e => e.Nome.ToLower().Contains(nome.ToLower()));;
           
             return await query.ToArrayAsync();
        }
    
    }
}