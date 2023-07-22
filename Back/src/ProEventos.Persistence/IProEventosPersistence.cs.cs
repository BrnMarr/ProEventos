using System.Threading.Tasks;
using ProEventos.Domain.models;

namespace Back.src.ProEventos.Persistence
{
   public interface IProEventosPersistence
   {  
      void Add<T>(T entity) where T: class;      
      void Update<T>(T entity) where T: class;
      void Delete<T>(T entity) where T: class;
      void DeleteRange<T>(T entity) where T: class;

      Task<bool> SaveChangesAsync();

      Task<Evento[]> GetAllEventosAsync(bool includePalestrantes);      
      Task<Evento[]> GetAllEventosByIdAsync(int EventoId,bool includePalestrantes);
      Task<Evento[]> GetAllEventosByTemaAsync(string tema,bool includePalestrantes);

      Task<Palestrante[]> GetAllPalestrantesAsync(bool includeEventos);      
      Task<Palestrante[]> GetAllPalestranteByIdAsync(int PalestranteId,bool includeEventos);
      Task<Palestrante[]> GetAllPalestrantesByNomeAsync(string nome,bool includeEventos);

   }
}


