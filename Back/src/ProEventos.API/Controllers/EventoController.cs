using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProEventos.API.models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;


namespace ProEventos.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventoController : ControllerBase
    {
         
        public EventoController()
        {
           
        }

        public IEnumerable<Evento> _evento = new Evento[] {
            new Evento() {
               EventoId = 1,
               Tema = "Angular 11",
               Local = "BH",
               Lote = "1º Lote",
               QtdPessoas = 250,
               DataEvento = DateTime.Now.AddDays(2).ToString("dd/MM/yyyy"),
            },
              new Evento() {
               EventoId = 2,
               Tema = ".Net",
               Local = "SP",
               Lote = "2º Lote",
               QtdPessoas = 350,
               DataEvento = DateTime.Now.AddDays(4).ToString("dd/MM/yyyy"),
            }  ,
              new Evento() {
               EventoId = 3,
               Tema = ".Net Core",
               Local = "RJ",
               Lote = "1º Lote",
               QtdPessoas = 250,
               DataEvento = DateTime.Now.AddDays(7).ToString("dd/MM/yyyy"),
            }           
        };



        [HttpGet]
        public IEnumerable<Evento> Get()
        {
           return _evento;
        }

        [HttpGet("{id}")]
        public IEnumerable<Evento> GetById(int id)
        {
           return _evento.Where(evento => evento.EventoId == id);
        }
    }
}
