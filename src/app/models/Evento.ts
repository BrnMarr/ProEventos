import { Lote } from "./Lote";
import { Palestrante } from "./Palestrante";
import { PalestranteEvento } from "./PalestranteEvento";
import { RedeSocial } from "./RedeSocial";

export interface Evento {

    id: number;       
    local:  string;     
    dataEvento? : Date;    
    tema: string;     
    qtdPessoas : number;
    imageUrl: string;
    telefone:  string;
    email: string;  
    lotes: Lote[];
    redeSocials: RedeSocial[];  
    palestrantesEventos:  Palestrante[];
}
