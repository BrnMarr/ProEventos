
import { Evento } from "./Evento";
import { RedeSocial } from "./RedeSocial";

export interface Palestrante {
    
    id: number; 
    nome: string; 
    miniCurriculo: string; 
    fotoUrl: string; 
    telefone: string; 
    email: string; 
    redeSociais: RedeSocial[]; 
    palestranteEventos: Evento[];
}
