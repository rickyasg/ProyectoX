import { suceso } from "./suceso";
import { Parametro } from "./parametro";

export class Periodo {

    DeportePeriodoId: number;
    DeporteId: number;
    Periodo: string;
    Abreviatura: string;
    EventoId: number;
    Tiempo: string;
    Punto: number;
    TipoCronometro: number;
    TipoPeriodo: number;
    sucesos: suceso[];
    marcadorA: number;
    marcadorB: number;
    Orden: number;
    competidorA = '';
    competidorB = '';
    intervaloDescanso: number;
    tiempo_current='';
    MaximoPunto=0;
    BotoneraA:Parametro[];
    BotoneraB:Parametro[];

    constructor(values: Object = {}) {
        this.sucesos = [];
        Object.assign(this, values);
        this.marcadorA = 0;
        this.marcadorB = 0;
        this.BotoneraA=[];
        this.BotoneraB=[];
    }

}
