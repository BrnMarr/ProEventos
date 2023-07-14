﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProEventos.API.models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Back.src.ProEventos.API.Data;

namespace ProEventos.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventoController : ControllerBase
    {
             private readonly DataContext _context;
        public EventoController(DataContext context)
        {
           _context = context;
        }
     
        
        [HttpGet]
        public IEnumerable<Evento> Get()
        {
           return _context.Eventos;
        }

        [HttpGet("{id}")]
        public IEnumerable<Evento> GetById(int id)
        {
           return _context.Eventos.Where(evento => evento.EventoId == id);
        }
    }
}
