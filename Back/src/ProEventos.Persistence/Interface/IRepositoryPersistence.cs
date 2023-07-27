using System.Threading.Tasks;
using ProEventos.Domain.models;

namespace ProEventos.Persistence.Interface
{
   public interface IRepositoryPersistence
   {  
      void Add<T>(T entity) where T: class;      
      void Update<T>(T entity) where T: class;
      void Delete<T>(T entity) where T: class;
      void DeleteRange<T>(T entity) where T: class;

      Task<bool> SaveChangesAsync();
   }
}


