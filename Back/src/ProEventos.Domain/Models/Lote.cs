
namespace ProEventos.Domain.models
{
    public class Lote
    {
       public int Id { get; set; }

       public string Nome { get; set; }
       public decimal Preco { get; set; }
       public string? DataInicio {get;set;}       
       public string? DataFim {get;set;}
       public int Quantidade { get; set; }
       public int EventoId { get; set; }
       public Evento Eventos {get;set;}

    }
}