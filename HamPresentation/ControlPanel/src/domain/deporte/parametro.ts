export class Parametro {

    ParametroSucesoId: number;
    Parametro: string;
    DeporteId: number;
    Color: string;
    RegistraPersona: number;
    CompetidorId: number;
    PlanillaId: number;
    Orden: number;
    Valor: number;
    ValorSuceso: number;
    GameBall: string;
    Tipo:number;
    constructor(values: Object = {}) {
        Object.assign(this, values);
    }

}
