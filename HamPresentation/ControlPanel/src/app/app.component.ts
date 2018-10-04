import { Component } from '@angular/core';
import { Platform, AlertController  } from 'ionic-angular';
import { StatusBar } from '@ionic-native/status-bar';
import { SplashScreen } from '@ionic-native/splash-screen';
import { Storage } from '@ionic/storage';
import { HomePage } from '../pages/home/home';
import { Insomnia } from '@ionic-native/insomnia';
import * as urls from '../providers/global';
@Component({
  templateUrl: 'app.html'
})
export class MyApp {
  rootPage: any = 'SquashListPage';
  deporte: any;
  eventoId: any;

  constructor(platform: Platform,
    statusBar: StatusBar,
    splashScreen: SplashScreen,
    private storage: Storage,
    private insomnia: Insomnia,
    private alertCtrl: AlertController) {
    this.deporte = [{ id: 27, text: 'Bádminton' }, { id: 46, text: 'Pelota Vasca' }, { id: 11, text: 'Ráquetbol' }, { id: 49, text: 'Squash' }, { id: 13, text: 'Tenis de Mesa' }, { id: 51, text: 'Tenis' }];
    this.eventoId = 4;
    //this.screenOrientation.lock(this.screenOrientation.ORIENTATIONS.LANDSCAPE);
    platform.ready().then(() => {
      // Okay, so the platform is ready and our plugins are available.
      // Here you can do any higher level native things you might need.
      Promise.all(
        [
          this.storage.get('eventoId').then((eId) => {
            if (eId == null) {
              this.storage.set('eventoId', this.eventoId);
            }
          }),
          this.storage.get('deportesConfig')
            .then(datosdeporte => {
              if (datosdeporte == null) {
                this.storage.set('deportesConfig', this.deporte);
              }
            }),
          this.storage.get('serverData')
            .then((serverData) => {
              if (serverData == null) {
                const data = {
                  commonServer: urls.urlCommon,
                  genericServer: urls.urlGeneric,
                  conjuntoServer: urls.urlConjunto,
                  socketServer: urls.urlSockets
                }
                this.storage.set('serverData', data);
              }
            })
        ]
      ).then(value => {
        //Hacer tareas al completar las solicitudes
        this.insomnia.keepAwake()
          .then(
            () => console.log('success'),
            () => console.log('error')
          );
      })
        .catch((error) => {
          console.log(error);
        });

      statusBar.styleDefault();
      splashScreen.hide();
      platform.registerBackButtonAction(() => {

        let nav = this.rootPage.getActiveNavs()[0];
        let activeView = nav.getActive();

        if(activeView.name === "SquashListPage") {
            if (nav.canGoBack()){ //Can we go back?
                nav.pop();
            } else {
                const alert = this.alertCtrl.create({
                    title: 'Mensaje',
                    message: '¿Desea salir del control?',
                    buttons: [{
                        text: 'No',
                        role: 'cancel',
                        handler: () => {
                            console.log('Application exit prevented!');
                        }
                    },{
                        text: 'Si',
                        handler: () => {
                            //platform.exitApp(); // Close this application
                        }
                    }]
                });
                alert.present();
            }
        }
    });
    });
  }
}
