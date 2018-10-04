import { Component } from '@angular/core';
import { IonicPage, NavController, NavParams, ToastController } from 'ionic-angular';
import { Storage } from '@ionic/storage';
import { hubConnection } from 'signalr-no-jquery';
import * as urls from '../../providers/global';
/**
 * Generated class for the SettingsPage page.
 *
 * See https://ionicframework.com/docs/components/#navigation for more info on
 * Ionic pages and navigation.
 */

@IonicPage()
@Component({
  selector: 'page-settings',
  templateUrl: 'settings.html',
})
export class SettingsPage {

  options: string = "deporte";
  deportes: any;
  color: string = 'dark';
  textDeporte: any = '';
  textPantalla: any = '';
  hubProxy: any;
  pantallas: any;
  commonServer: '';
  genericServer: '';
  socketServer: '';
  conjuntoServer: '';
  eventoId: number;
  nroPeriodos=0;

  constructor(public navCtrl: NavController,
    public navParams: NavParams,
    private storage: Storage,
    private toastCtrl: ToastController) {
  }


  ionViewDidLoad() {
    this.storage.get('nroPeriodos').then((res) => {
      this.nroPeriodos = res;
    });

    this.storage.get('eventoId').then((eventoId) => {
      this.eventoId = eventoId;
    });

    this.storage.get('deportesConfig').then((deporteConfig) => {
      this.deportes = deporteConfig;
    });
    this.storage.get('deporteSeleccionado').then((deporteSeleccionado) => {
      if (deporteSeleccionado == null)
        this.textDeporte = '';
      else
        this.textDeporte = deporteSeleccionado.text;
    });

    this.storage.get('pantallaSeleccionado').then((pantallaSeleccionado) => {
      if (pantallaSeleccionado == null)
        this.textPantalla = '';
      else
        this.textPantalla = pantallaSeleccionado;
    });
    this.storage.get('serverData').then((serverData) => {
      this.commonServer = serverData.commonServer;
      this.genericServer = serverData.genericServer;
      this.conjuntoServer = serverData.conjuntoServer;
      this.socketServer = serverData.socketServer;
      // const connection = hubConnection(`${this.socketServer}`, { qs: 'name=remotoSquash' + Math.floor(Math.random() * 100) + 1 + '&group=remotoSquash' });
      // this.hubProxy = connection.createHubProxy('MarcadorSquashHub');

      // connection.start({ transport: 'longPolling', xdomain: true })
      //   .done(function () {
      //     console.log('Ahora conectado, ID de conexión =' + connection.id);
      //   })
      //   .fail(function () { console.log('No se pudo conectar'); });
      // this.hubProxy.on('addPantalla', (text) => {
      //   this.pantallas = text;
      //   text.forEach(element => {
      //     console.log(element);
      //   });
      // });
    });
  }

  clickDeporte(item) {

    this.storage.set('deporteSeleccionado', item).then(() => {
      this.textDeporte = item.text;
    })
  }
  pantallaSelected(pantalla) {
    console.log(pantalla);
  }

  butonsClick() {
    //this.hubProxy.invoke('controlPantalla', 'remoto', 'squash');
    this.storage.get('serverData').then((serverData) => {
      this.commonServer = serverData.commonServer;
      this.genericServer = serverData.genericServer;
      this.conjuntoServer = serverData.conjuntoServer;
      this.socketServer = serverData.socketServer;
    });

  }

  clickPantalla(item) {
    this.storage.set('pantallaSeleccionado', item).then(() => {
      this.textPantalla = item;
    })
  }
  saveServers(estado) {
    let data;
    if (estado) {
      data = {
        commonServer: this.commonServer,
        genericServer: this.genericServer,
        socketServer: this.socketServer,
        conjuntoServer: this.conjuntoServer
      }
    } else {
      data = {
        commonServer: urls.urlCommon,
        genericServer: urls.urlGeneric,
        conjuntoServer: urls.urlConjunto,
        socketServer: urls.urlSockets
      }
      this.commonServer = data.commonServer;
      this.genericServer = data.genericServer;
      this.socketServer = data.socketServer;
      this.conjuntoServer = data.conjuntoServer
      this.eventoId = 4;
      this.nroPeriodos=7;
    }


    Promise.all([
      this.storage.set('serverData', data),
      this.storage.set('eventoId', this.eventoId),
      this.storage.set('nroPeriodos', this.nroPeriodos),
    ]).then(() => {
      let toast = this.toastCtrl.create({
        message: 'Se guardo con Exito la configuración.',
        duration: 2500,
        position: 'bottom'
      });

      toast.onDidDismiss(() => {

      });
      toast.present();
    });
  }
}
