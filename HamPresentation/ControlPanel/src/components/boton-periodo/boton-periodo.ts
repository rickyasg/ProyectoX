import { Component, Input, OnChanges, SimpleChanges, Output, EventEmitter } from '@angular/core';
import { Periodo } from '../../domain/deporte/Periodo';
import { AlertController } from 'ionic-angular';
import { Storage } from '@ionic/storage';
import { suceso } from '../../domain/deporte/suceso';

/**
 * Generated class for the BotonPeriodoComponent component.
 *
 * See https://angular.io/api/core/Component for more info on Angular
 * Components.
 */
@Component({
  selector: 'boton-periodo',
  templateUrl: 'boton-periodo.html'
})
export class BotonPeriodoComponent implements OnChanges {
  @Input() DatosPeriodo: Periodo;
  @Input() reset: false;
  @Output() iniciarCronometro = new EventEmitter();

  color: any;
  seleccionado = false;
  constructor(public alertCtrl: AlertController,
    private storage: Storage) {
    this.DatosPeriodo = new Periodo();
  }

  selectPeriodo() {
    if (!this.seleccionado) {
      let confirm = this.alertCtrl.create({
        title: 'Cambio de Periodo',
        message: 'Desea cambiar al periodo ' + this.DatosPeriodo.Abreviatura + '?',
        buttons: [
          {
            text: 'NO',
            handler: () => {
              if (!this.seleccionado) {
                this.color = '';
              }
            }
          },
          {
            text: 'SI',
            handler: () => {
              this.color = { 'background-color': '#ff5722' };
              this.seleccionado = true;

              this.storage.set('periodo-seleccionado', this.DatosPeriodo);
              this.storage.set('puntosSet', this.DatosPeriodo.Punto);
              this.iniciarCronometro.emit(this.DatosPeriodo);

              console.log(this.DatosPeriodo)
            }
          }
        ]
      });
      confirm.present();
    }
  }
  initRepositorioPeriodo() {
    this.storage.get(this.DatosPeriodo.Abreviatura).then(val => {
      if (val === undefined || val===null) {
        this.storage.set(this.DatosPeriodo.Abreviatura, this.DatosPeriodo);
      }
    });
  }
  ngOnChanges(changes: SimpleChanges) {
    try {

      this.color = '';
      this.seleccionado = false;
      this.storage.remove('periodo-seleccionado');

    } catch (error) {

    }
  }


}
