export class suceso {
    DeportePeriodoId: number;
    Tiempo: number;
    CompetidorId: number;
    PlanillaId: number;
    ParametroSucesoId: number;
    Valor: number;

    constructor(values: Object = {}) {
        Object.assign(this, values);
    }

}