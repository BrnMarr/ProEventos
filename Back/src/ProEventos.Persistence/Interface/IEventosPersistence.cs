using System.Threading.Tasks;
using ProEventos.Domain.models;

namespace ProEventos.Persistence.Interface
{
   public interface IEventosPersistence
   {      
      Task<Evento[]> GetAllEventosAsync(bool includePalestrantes);  
      Task<Evento[]> GetAllEventosByTemaAsync(string tema,bool includePalestrantes);
      Task<Evento> GetEventoByIdAsync(int EventoId,bool includePalestrantes);

   }
}


