using System.Threading.Tasks;
using ProEventos.Domain.models;

namespace ProEventos.Persistence.Interface
{
   public interface IPalestrantesPersistence
   {  
      Task<Palestrante[]> GetAllPalestrantesAsync(bool includeEventos);      
      Task<Palestrante> GetPalestranteByIdAsync(int PalestranteId,bool includeEventos);
      Task<Palestrante[]> GetAllPalestrantesByNomeAsync(string nome,bool includeEventos);
   }
}


