import { Component, Input, EventEmitter, Output, SimpleChanges, OnChanges } from '@angular/core';
import { Parametro } from '../../domain/deporte/parametro';
import { Storage } from '@ionic/storage';
import { Periodo } from '../../domain/deporte/Periodo';
import { AlertController } from 'ionic-angular';
import { suceso } from '../../domain/deporte/suceso';
/**
 * Generated class for the BotonComponent component.
 *
 * See https://angular.io/api/core/Component for more info on Angular
 * Components.
 */
@Component({
  selector: 'boton',
  templateUrl: 'boton.html'
})
export class BotonComponent implements OnChanges {
  @Input() DatosParametros: Parametro;
  @Input() cronograma: any;
  @Input() posicion: boolean;
  @Input() reload = false;
  @Input() solo_lectura: number;
  @Output() sumartotal = new EventEmitter();
  @Output() restartotal = new EventEmitter();
  @Output() finEvento = new EventEmitter();
  @Input() marcadorSet1: any;
  @Input() deporteId = 0;

  text: string;
  periodo_seleccionado: Periodo;
  puntosPeriodo: any;
  puntosSetTope: any = {};
  mensaje = '';
  constructor(private storage: Storage,
    public alertCtrl: AlertController) {
    this.DatosParametros = new Parametro();
    this.solo_lectura = 1;
  }
  registrarPunto() {
    this.getPeriodo();
  }
  quitarPunto() {
    this.periodo_seleccionado = new Periodo();
    this.storage.get('periodo-seleccionado').then(val => {
      this.periodo_seleccionado = val;
      if (this.periodo_seleccionado === null) {
        this.setMensaje('Seleccionar Periodo', 'No existe un periodo seleccionado!');
      } else {
        if (this.solo_lectura === 0) {
          let auxiliar = this.DatosParametros.Valor;
          auxiliar--;
          if (auxiliar < 0) {
            this.DatosParametros.Valor = 0;
          } else {
            this.DatosParametros.Valor = auxiliar;
          }

          this.storage.get('puntosSet').then(topeSet => {
            if (this.marcadorSet1.pA > topeSet - 3 || this.marcadorSet1.pB > topeSet - 3) {
              let diferencia = this.periodo_seleccionado.Punto - topeSet;
              if (this.marcadorSet1.tipo === 'A' && this.marcadorSet1.pA - 1 == topeSet + diferencia - 3) {
                this.periodo_seleccionado.Punto -= 1;
                this.storage.set('periodo-seleccionado', this.periodo_seleccionado);
              }
              if (this.marcadorSet1.tipo === 'B' && this.marcadorSet1.pB - 1 == topeSet + diferencia - 3) {
                this.periodo_seleccionado.Punto -= 1;
                this.storage.set('periodo-seleccionado', this.periodo_seleccionado);
              }
            }
            this.restartotal.emit(this.DatosParametros);
          });
        }
      }

    });
  }
  private getPeriodo() {
    this.periodo_seleccionado = new Periodo();
    this.storage.get('periodo-seleccionado').then(val => {
      this.periodo_seleccionado = val;


      this.puntosPeriodo = this.periodo_seleccionado
      if (this.periodo_seleccionado === null) {
        this.setMensaje('Seleccionar Periodo', 'No existe un periodo seleccionado!');
      } else {
        console.log(this.periodo_seleccionado);
        let var1 = this.periodo_seleccionado.Punto;
        const maximo = this.periodo_seleccionado.MaximoPunto;

        this.storage.get('puntosSet').then(topeSet => {
          if (var1 < topeSet) {
            var1 = topeSet;
            this.periodo_seleccionado.Punto = topeSet;
            this.storage.set('periodo-seleccionado', this.periodo_seleccionado);
          }
          if (this.periodo_seleccionado.Punto === this.marcadorSet1.pA + 1 && this.periodo_seleccionado.Punto === this.marcadorSet1.pB + 1) {
            this.periodo_seleccionado.Punto += 1;
            this.storage.set('periodo-seleccionado', this.periodo_seleccionado);
          }
          if (this.solo_lectura === 0 && (this.periodo_seleccionado.TipoPeriodo !== 4 && this.calculaTope(var1, maximo))) {
            this.DatosParametros.Valor++;
            switch (this.deporteId) {
              case 49: this.DatosParametros.GameBall = this.gameball();
                break;
              case 27: console.log('banminton');
                break;
            }


            this.sumartotal.emit(this.DatosParametros);
            this.set_suceso();
          }
          this.checkTope(this.periodo_seleccionado.Punto, maximo);

        });

      }
    });
  }
  set_suceso() {
    try {
      this.storage.get(this.periodo_seleccionado.Abreviatura).then(val => {
        let periodo: Periodo;
        periodo = val
        let item: suceso;
        item = new suceso();
        item.DeportePeriodoId = this.periodo_seleccionado.DeportePeriodoId;
        item.Tiempo = 0;
        item.CompetidorId = this.DatosParametros.CompetidorId;
        item.PlanillaId = this.cronograma.PlanillaId;
        item.ParametroSucesoId = this.DatosParametros.ParametroSucesoId;
        item.Valor = this.DatosParametros.ValorSuceso;
        if (periodo === null) {
          periodo = new Periodo();
        }
        if (periodo.sucesos === undefined) {

          periodo.sucesos = [];
        }
        periodo.sucesos.push(item);
        this.storage.set(this.periodo_seleccionado.Abreviatura, periodo);
      });
    } catch{ }
  }

  setMensaje(titulo: string, mensaje: string) {
    let alert = this.alertCtrl.create({
      title: titulo,
      subTitle: mensaje,
      buttons: ['OK']
    });
    alert.present();
  }
  ngOnChanges(changes: SimpleChanges) {
    // this.solo_lectura = Number(
    //   changes['solo_lectura'] !== undefined ? changes['solo_lectura'].currentValue : 1
    // );
    if (changes.reload !== undefined) {
      this.DatosParametros.Valor = 0;
    }
  }

  calculaTope(tope, maximo) {

    if (maximo > 0 && (this.marcadorSet1.pA === maximo || this.marcadorSet1.pB === maximo)) {
      return false;
    }
    if (this.marcadorSet1.pA >= tope) {
      return false;
    } else if (this.marcadorSet1.pB >= tope) {
      return false;
    } else {
      return true;
    }
  }
  checkTope(tope, maximo) {
    console.clear();
    console.log(tope + '-' + maximo + '-' + this.marcadorSet1.pA + '-' + this.marcadorSet1.pB);

    
    if (this.marcadorSet1.pA === tope - 1 && this.marcadorSet1.tipo==='A') {
      this.finEvento.emit(tope);
    }else{
      if (this.marcadorSet1.pB === tope - 1 && this.marcadorSet1.tipo==='B') {
        this.finEvento.emit(tope);
      }
    }
    

  }
  gameball() {
    let sets1 = this.marcadorSet1.periodos.filter(sets => sets.TipoPeriodo !== 4);
    let tam = 0;
    sets1.forEach(set => {
      tam += 1;
    })
    const nroSetWin = Math.trunc(tam / 2);
    let nroSetsA = 0;
    let nroSetsB = 0;
    let i = 0;
    sets1.forEach(set => {
      if (set.marcadorA != undefined && set.marcadorB != undefined) {
        if (set.marcadorA > set.marcadorB) {
          nroSetsA += 1;
        } else if (set.marcadorA < set.marcadorB) {
          nroSetsB += 1;
        } else {
          if (nroSetsA > nroSetsB) {
            nroSetsA += 1;
          } else if (nroSetsB > nroSetsA) {
            nroSetsB += 1;
          }
        }
      }
    });
    if (nroSetsA == nroSetWin + 1) {
      if (this.marcadorSet1.tipo === 'A' && this.marcadorSet1.pA + 1 > this.marcadorSet1.pB && this.marcadorSet1.pA + 1 === this.periodo_seleccionado.Punto - 1) {
        return 'Match Ball';
      }
    } else if (nroSetsB == nroSetWin + 1) {
      if (this.marcadorSet1.tipo === 'B' && this.marcadorSet1.pB + 1 > this.marcadorSet1.pA && this.marcadorSet1.pB + 1 === this.periodo_seleccionado.Punto - 1) {
        return 'Match Ball';
      }
    }
    if (this.marcadorSet1.tipo === 'A' && this.marcadorSet1.pA + 1 > this.marcadorSet1.pB && this.marcadorSet1.pA + 1 === this.periodo_seleccionado.Punto - 1) {
      return 'Game Ball';
    } else {
      if (this.marcadorSet1.tipo === 'B' && this.marcadorSet1.pB + 1 > this.marcadorSet1.pA && this.marcadorSet1.pB + 1 === this.periodo_seleccionado.Punto - 1) {
        return 'Game Ball';
      } else {
        return this.DatosParametros.Parametro;
      }
    }
  }
}
