using Microsoft.EntityFrameworkCore;
using ProEventos.Domain.models;
using ProEventos.Persistence.Interface;
using ProEventos.Persistentece.Data;

namespace Back.src.ProEventos.Persistence.Repository
{
    public class Repository : IRepositoryPersistence
    {
        private readonly ProEventosContext _context;
        public Repository(ProEventosContext context)
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
     
    }
}