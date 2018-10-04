import { BrowserModule } from '@angular/platform-browser';
import { ErrorHandler, NgModule } from '@angular/core';
import { IonicApp, IonicErrorHandler, IonicModule } from 'ionic-angular';
import { SplashScreen } from '@ionic-native/splash-screen';
import { StatusBar } from '@ionic-native/status-bar';
import { HttpModule } from '@angular/http';
import { IonicStorageModule } from '@ionic/storage';

import { MyApp } from './app.component';
import { HomePage } from '../pages/home/home';
import { Vibration } from '@ionic-native/vibration';
import { Insomnia } from '@ionic-native/insomnia';
// import { SquashListPage } from '../pages/squash-list/squash-list';
// import { SquashControlPage } from '../pages/squash-control/squash-control';
// import {BotonComponent} from '../components/boton/boton';

import { PrvSquashProvider } from '../providers/prv-squash/prv-squash';
import { PrvDeporteProvider } from '../providers/prv-deporte/prv-deporte';

@NgModule({
  declarations: [
    MyApp,
    HomePage
  ],
  imports: [
    BrowserModule,
    HttpModule,
    IonicModule.forRoot(MyApp),
    IonicStorageModule.forRoot()
  ],
  bootstrap: [IonicApp],
  entryComponents: [
    MyApp,
    HomePage
  ],
  providers: [
    StatusBar,
    SplashScreen,
    { provide: ErrorHandler, useClass: IonicErrorHandler },
    PrvDeporteProvider,
    PrvSquashProvider,
    Vibration,
    Insomnia
  ]
})
export class AppModule { }
