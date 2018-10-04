import { Component, Input, OnChanges, SimpleChanges, Output, EventEmitter } from '@angular/core';
import { AlertController } from 'ionic-angular';

/**
 * Generated class for the BotonIzqDerComponent component.
 *
 * See https://angular.io/api/core/Component for more info on Angular
 * Components.
 */
@Component({
  selector: 'boton-izq-der',
  templateUrl: 'boton-izq-der.html'
})
export class BotonIzqDerComponent implements OnChanges {
  text: string;
  @Input() lado: number;
  @Output() getLado = new EventEmitter();

  constructor(public alertCtrl: AlertController) {
    this.text = 'Debe elegir un lado';
  }
  selectLado() {
    this.getLado.emit(this.lado===2?1:2);
  }
  ngOnChanges(changes: SimpleChanges) {
    const action = Number(
      changes['lado'] !== undefined ? changes['lado'].currentValue : 0
    );
    switch (action) {
      case 1:
        this.text = 'IZQUIERDA';
        this.lado = 1;
        break;
      case 2:
        this.text = 'DERECHA';
        this.lado = 2;
        break;
      default:
        this.text = 'Debe elegir un lado';
        this.lado = 0;
        break;
    }
  }
}
