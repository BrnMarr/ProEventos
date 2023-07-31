using ProEventos.Application.Interfaces;
using ProEventos.Domain.models;
using ProEventos.Persistence.Interface;

namespace ProEventos.Application;

public class EventoService : IEventoService
{
    private readonly IEventosPersistence _eventoPersistence;
     private readonly IRepositoryPersistence _repository;

   public EventoService(IRepositoryPersistence repository, IEventosPersistence eventoPersistence)
   {
    _eventoPersistence = eventoPersistence;
    _repository = repository;
   }  

    public async Task<Evento> AddEventos(Evento model)
    {
        try
        {
           _repository.Add<Evento>(model);
           if (await _repository.SaveChangesAsync())
            {
              return await _eventoPersistence.GetEventoByIdAsync(model.Id, false);
            }  
           return null;
        }
          catch (Exception e)
        {          
          throw new Exception(e.Message);
        }
    }

    public async Task<bool> DeleteEvento(int eventoId)
    {
          try
         {
            var evento = await _eventoPersistence.GetEventoByIdAsync(eventoId, false);

            if (evento == null) throw new Exception("Evento nao encontrado para delete.");

            _repository.Delete<Evento>(evento);
            return await _repository.SaveChangesAsync();        

        }
         catch (Exception e)
         {
            throw new Exception(e.Message);
         }
    }

   public async Task<Evento> UpdateEvento(int eventoId, Evento model)
   {
      
         try
         {
            var evento = await _eventoPersistence.GetEventoByIdAsync(eventoId, false);

            if (evento == null) return null;

            _repository.Update(model);
            if (await _repository.SaveChangesAsync())
            {
                return await GetEventoByIdInterno(model);
            }

            return null;

        }
         catch (Exception e)
         {
            throw new Exception(e.Message);
         }
      
   }

    private async Task<Evento> GetEventoByIdInterno(Evento model)
    {
        return await _eventoPersistence.GetEventoByIdAsync(model.Id, false);
    }

    public Task<Evento[]> GetAllEventosAsync(bool includePalestrantes = false)
    {
        throw new NotImplementedException();
    }

    public Task<Evento[]> GetAllEventosByTemaAsync(string tema, bool includePalestrantes = false)
    {
        throw new NotImplementedException();
    }

    public Task<Evento> GetEventoByIdAsync(int EventoId, bool includePalestrantes = false)
    {
        throw new NotImplementedException();
    }

}