import { Component } from '@angular/core';
import { NavController, ToastController } from 'ionic-angular';
// import { SquashListPage } from '../squash-list/squash-list';
import { hubConnection } from 'signalr-no-jquery';

import * as urls from '../../providers/global';

@Component({
  selector: 'page-home',
  templateUrl: 'home.html'
})
export class HomePage {

  hubProxy: any;

  constructor(public navCtrl: NavController,
    private toastCtrl: ToastController) {

  }

  ionViewDidLoad() {

    const connection = hubConnection(`${urls.urlSockets}`, {qs:'name=arielito&group=squash'});
    this.hubProxy = connection.createHubProxy('MarcadorSquashHub');


    // this.hubProxy.on('mensaje', function (mensaje) {
    //   console.log(mensaje);
    // });

    connection.start({ transport: 'longPolling', xdomain: true})
      .done(function () {
        console.log('Ahora conectado, ID de conexión =' + connection.id);
      })
      .fail(function () { console.log('No se pudo conectar'); });
  }

  onCLickOpen() {

    const dataMarcador = {
      Periodo: '1 SET', // this.abreviaturaTiempo,
      ScoreA: 2,
      ScoreB: 3,
      Mensaje: 'Hola',
      ShowMensaje: true,
      Tope: 11,
      TeamA: null,
      TeamB: null
    };

    this.hubProxy.invoke('ActualizarMarcador', dataMarcador);

    // let toast = this.toastCtrl.create({
    //   message: 'yendo a otra pagina',
    //   duration: 3000,
    //   position: 'bottom'
    // });

    // toast.onDidDismiss(() => {
    //   this.navCtrl.push(SquashListPage);
    // });

    // toast.present();
  }

}
