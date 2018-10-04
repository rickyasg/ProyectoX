export class EquipoPersona {
    EquipoId: number;
    PersonaId: number;
    Posicion: any;
    NroCamiseta: any;
    Nombre: any;
    Delegacion: any;
    Representacion: any;
    NombreAbreviado:any;
    
    constructor(values: Object = {}) {
      Object.assign(this, values);
    }
  }