import { Parametro } from "./parametro";
import { Periodo } from "./Periodo";
import { EquipoPersona } from "./equipoPersona";

export class Cronograma {
  NombreReducidoEquipoA: any;
  NombreReducidoEquipoB: any;
  i: number;
  fecha: any;
  botoneraB: Parametro[];
  botoneraA: Parametro[];
  periodos: Periodo[];
  PlanillaId: any;
  Instalacion: any;
  Prueba: any;
  Genero: any;
  PlanillaEstado: number;
  HoraFin: any;
  HoraInicio: any;
  CronogramaId: any;
  Planilla: number;
  CompetidorBId: any;
  CompetidorAId: any;
  EventoId: any;
  Puntuacion: string;
  Escenario: any;
  Estado: any;
  EquipoB: any;
  EquipoA: any;
  Hora: string;
  EquipoIdA = 0;
  EquipoIdB = 0;
  DelegacionIdA = 0;
  DelegacionIdB = 0;
  PersonasEquipoA: EquipoPersona[];
  PersonasEquipoB: EquipoPersona[];
  listaA: any;
  listaB: any;
  personaIdA = 0;
  personaIdB = 0;

  constructor(values: Object = {}) {
    Object.assign(this, values);
  }
}
