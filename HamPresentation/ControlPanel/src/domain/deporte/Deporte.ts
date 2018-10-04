export class Deporte {
    DeporteId: number;
    DeporteDescripcion: string;
    id:number;
    text:string;
    constructor(values: Object = {}) {
        Object.assign(this, values);
    }
}