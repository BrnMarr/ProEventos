using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProEventos.Domain.models;
using ProEventos.Application.Interfaces;
using Microsoft.AspNetCore.Http;

namespace ProEventos.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventoController : ControllerBase
    {
        private readonly IEventoService _eventoService;

        public EventoController(IEventoService eventoService)
        {          
            _eventoService = eventoService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
               var eventos = await _eventoService.GetAllEventosAsync(true);
               
               if (eventos == null) return NotFound("eventos não encontrado.");

               return Ok(eventos);
            
            }
            catch (Exception e)
            {               
               return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar recuperar eventos. Erro: {e.Message}");
            }
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetId(int id)
        {
            try
            {
               var evento = await _eventoService.GetEventoByIdAsync(id,true);
               
               if (evento == null) return NotFound("Evento por id não encontrado.");

               return Ok(evento);
            
            }
            catch (Exception e)
            {               
               return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar recuperar eventos. Erro: {e.Message}");
            }
        }
                
        [HttpGet("{tema}/tema")]
        public async Task<IActionResult> GetTema(string tema)
        {
            try
            {
               var evento = await _eventoService.GetAllEventosByTemaAsync(tema,true);
               
               if (evento == null) return NotFound("Evento por tema não encontrado.");

               return Ok(evento);
            
            }
            catch (Exception e)
            {               
               return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar recuperar eventos. Erro: {e.Message}");
            }
        }
        
        [HttpPost]   
        public async Task<IActionResult> Post(Evento model)
        {
            try
            {
               var evento = await _eventoService.AddEventos(model);
               
               if (evento == null) return BadRequest("Erro ao adicionar evento.");

               return Ok(evento);
            
            }
            catch (Exception e)
            {               
               return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar adicionar evento. Erro: {e.Message}");
            }
        }
        
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id,Evento model)
        {
            try
            {
               var evento = await _eventoService.UpdateEvento(id,model);
               
               if (evento == null) return NotFound("Evento para ser atualizado não encontrado.");

               return Ok(evento);
            
            }
            catch (Exception e)
            {               
               return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar atualizar evento. Erro: {e.Message}");
            }
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                if (await _eventoService.DeleteEvento(id))
                     return Ok("Evento deletado.");
                else 
                     return BadRequest("Evento não deletado.");                          
            
            }
            catch (Exception e)
            {               
               return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar deletar evento. Erro: {e.Message}");
            }
        }
    }
}
