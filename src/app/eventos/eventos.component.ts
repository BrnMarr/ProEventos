
import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { EventoService } from '../services/evento.service';
import { Evento } from '../models/Evento';

@Component({
  selector: 'app-eventos',
  templateUrl: './eventos.component.html',
  styleUrls: ['./eventos.component.scss']
  // possibilidade { providers: EventoService}
})
export class EventosComponent {
   
   

   public evento: Evento[] = [];
   public eventosFiltrados:Evento[] = [];
   widthImg: number = 150;
   marginImg: number = 2;
   exibirImg: Boolean = true;
   _filtroLista: string ='';

   public get filtroLista(){
      return this._filtroLista;
   }

   public set filtroLista(value: string){
      this._filtroLista = value;
       this.eventosFiltrados = this.filtroLista ? this.filtrarEventos(this.filtroLista) : this.evento;
      
   }

   constructor(private eventoService: EventoService) { }

   ngOnInit(): void{     
    this.getEventos();
   }
   
   public filtrarEventos(filtrarPor: String): Evento[] {
       filtrarPor = filtrarPor.toLocaleLowerCase();

       return this.evento.filter(
          (e: any) => e.tema.toLocaleLowerCase().indexOf(filtrarPor) !== -1 || 
           e.local.toLocaleLowerCase().indexOf(filtrarPor) !== -1
       )
   }
   

   public alterarImagem() : void {
      this.exibirImg = !this.exibirImg;
   }

   public getEventos() : void {
     
         this.eventoService.getEventos().subscribe(
          (response: Evento[]) =>  {
            this.evento = response;
            this.eventosFiltrados = this.evento;          
         },
         error => console.log(error)          
      );  
   }
}
