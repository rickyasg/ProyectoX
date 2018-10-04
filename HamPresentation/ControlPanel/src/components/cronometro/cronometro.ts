import {
  Component,
  Input,
  OnChanges,
  SimpleChanges,
  Output,
  EventEmitter
} from '@angular/core';
import { Texto } from '../../domain/deporte/texto';
import { Storage } from '@ionic/storage';

/**
 * Generated class for the CronometroComponent component.
 *
 * See https://angular.io/api/core/Component for more info on Angular
 * Components.
 */
@Component({
  selector: 'cronometro',
  templateUrl: 'cronometro.html'
})
export class CronometroComponent implements OnChanges {
  hora: number;
  minuto: number;
  segundo: number;
  sminuto = '00';
  shora = '00';
  ssegundo = '00';
  HoraInicio: string;
  HoraTope: string;
  timerIniciado = false;
  timer: any;

  @Input() accion: number;
  @Input() reversa: boolean;
  @Input() capturar = false;
  @Input() tieneTope: boolean;
  @Input() setTiempo: string;
  @Input() forza: string;

  @Output() HoraCapturada = new EventEmitter();
  @Output() getHora = new EventEmitter();
  @Output() finReversa = new EventEmitter();
  texto: Texto;

  constructor(private storage: Storage) {
    this.hora = 0;
    this.minuto = 0;
    this.segundo = 0;
    this.shora = '00';
    this.sminuto = '00';
    this.ssegundo = '00';
    this.HoraTope = '';
    this.texto = new Texto();
  }

  ngOnIniciar() {
    if (!this.reversa) {
      if (this.timerIniciado === false) {
        this.timerIniciado = true;
        this.timer = setInterval(() => {
          this.segundo += 1;
          if (this.segundo === 60) {
            this.segundo = 0;
            this.minuto += 1;
            /*if(this.minuto==60)
              {
                this.minuto=0;
                this.hora+=1;
              }*/
          }
          this.initTexto();
          this.controlTope();
          this.storage.set('tiempo', this.sminuto + ':' + this.ssegundo);
        }, 1000);
      }
    } else {
      this.ngOnReversa();
    }
  }
  private getSegundos() {
    // var segHora=this.hora*3600;
    const segMin = this.minuto * 60;
    return segMin + this.segundo;
  }
  private initTime() {
    const timelist = this.HoraInicio.replace('"', '').split(':');

    if (timelist.length === 2) {
      // var ihora=timelist[0];
      const iminuto = timelist[0];
      const isegundo = timelist[1];
      // this.hora=parseInt(ihora);
      this.minuto = parseInt(iminuto, 10);
      this.segundo = parseInt(isegundo, 10);
    } else {
      this.hora = 0;
      this.minuto = 0;
      this.segundo = 0;
    }
    this.initTexto();
  }
  ngOnReversa() {
    this.initTime();
    if (this.minuto === 0 && this.segundo === 0) {
      this.ngOnDetener();
    }

    if (this.timerIniciado === false) {
      this.timerIniciado = true;

      this.timer = setInterval(() => {
        if (this.getSegundos() > 0) {
          if (
            (this.segundo === 0 && this.minuto > 0) ||
            (this.segundo === 0 && this.minuto === 0)
          ) {
            this.segundo = 0;
          } else {
            this.segundo -= 1;
          }
        }
        if (this.segundo === 0) {
          if (this.minuto > 0) {
            this.segundo = 0;
            this.segundo = 59;
            this.minuto -= 1;
          }
        }

        this.initTexto();
        this.controlTope();
        if (this.segundo === 0 && this.minuto === 0) {
          this.finReversa.emit();
          this.ngOnDetener();
        }
      }, 1000);
    }
  }
  ngOnPausar() {
    if (this.timer) {
      this.HoraInicio = this.sminuto + ':' + this.ssegundo;
      this.timerIniciado = false;
      clearInterval(this.timer);
    }
  }
  ngOnDetener() {
    if (this.timer) {
      this.timerIniciado = false;
      clearInterval(this.timer);

      this.hora = 0;
      this.minuto = 0;
      this.segundo = 0;

      this.initTexto();
    }
  }

  private initTexto() {
    this.sminuto = this.texto.lpad('0', 2, String(this.minuto));
    this.ssegundo = this.texto.lpad('0', 2, String(this.segundo));
    this.getHora.emit(this.sminuto + ':' + this.ssegundo);
  }

  private controlTope() {
    if (this.tieneTope) {
      const horaAux = this.sminuto + ':' + this.ssegundo;
      if (horaAux === this.HoraTope) {
        if (this.timer) {
          this.timerIniciado = false;
          clearInterval(this.timer);
        }
      }
    }
  }
  ngOnChanges(changes: SimpleChanges) {
    this.HoraCapturada.emit(this.sminuto + ':' + this.ssegundo);
    const action = Number(
      changes['accion'] !== undefined ? changes['accion'].currentValue : 0
    );
    const tiempo = String(
      changes['setTiempo'] !== undefined
        ? changes['setTiempo'].currentValue
        : '00:00'
    );
    const forza = String(
      changes['forza'] !== undefined
        ? changes['forza'].currentValue
        : '00:00'
    );
    console.log(action)
    if (forza != '00:00') {
      this.eventCambiarTiempo(forza);
    }
    switch (action) {
      case 4:
        this.HoraCapturada.emit(this.sminuto + ':' + this.ssegundo);
        break;
      case 1:
        clearInterval(this.timer);
        this.ngOnIniciar();

        break;
      case 3:
        this.ngOnPausar();
        break;
      case 2:
        this.ngOnDetener();
        break;
      case 5:
        this.eventCambiarTiempo(tiempo);
        break;
      case 6:
        this.HoraInicio = '00:00';
        this.initTime();
        break;
    }
  }
  eventCambiarTiempo(tiempo) {
    this.ngOnDetener();

    // tslint:disable-next-line:no-shadowed-variable
    this.HoraInicio = tiempo;

    this.initTime();
    this.ngOnIniciar();
    this.accion = 0;
  }
}
