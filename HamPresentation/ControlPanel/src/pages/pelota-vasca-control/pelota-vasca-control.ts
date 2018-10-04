import { Component } from '@angular/core';
import { Storage } from '@ionic/storage';

import { IonicPage, NavController, NavParams, ToastController, AlertController } from 'ionic-angular';
import { Deporte } from '../../domain/deporte/Deporte';
import { hubConnection } from 'signalr-no-jquery';
import * as urls from '../../providers/global';
import { Periodo } from '../../domain/deporte/Periodo';
import { Vibration } from '@ionic-native/vibration';
import { Texto } from '../../domain/deporte/texto';
import { Matematicas } from '../../domain/deporte/math';


@IonicPage()
@Component({
  selector: 'page-pelota-vasca-control',
  templateUrl: 'pelota-vasca-control.html',
})
export class S46ControlPage {

  refrescar = false;
  botonesB: any[];
  cronograma_id = 0;
  cronogramaItem: any;
  deporte: string;
  botonesA: any[];
  periodos: any[];
  idCompetidorA = 0;
  idCompetidorB = 0;
  Equipo_a_nombre = '';
  Equipo_b_nombre = '';
  puntajeA = 0;
  puntajeB = 0;
  action = 0;
  action_descanso = 0;
  visible = false;
  reset = false;
  reversa = false;
  tiempo = '00:00';
  tiempo_descanso = '00:00';
  forzar_tiempo = '00:00';
  forzar_tiempo_descanso = '00:00';
  deporte_data: Deporte;
  periodo_titulo: '';
  periodo_punto: 0;
  mensaje = '';
  textButton: '';
  lado: number;
  ladoA = 0;
  ladoB = 0;
  captura_tiempo = true;
  periodo_actual = 0;
  posesion = 0;
  texto_utilidad: Texto;
  solo_lectura = 1;
  hubProxy: any;
  server: any = {};
  marcadorSet: any;
  matematicas: Matematicas;
  prueba_texto = '';
  listaConcluidos: number[] = [];

  constructor(
    public navCtrl: NavController,
    public navParams: NavParams,
    private storage: Storage,
    private vibration: Vibration,
    private toastCtrl: ToastController,
    public alertCtrl: AlertController
  ) {
    this.getDAtaDeporte();
    this.getCronograma();
    this.storage.remove('periodo-seleccionado');
    this.texto_utilidad = new Texto();
    this.matematicas = new Matematicas();
  }
  ionViewWillLeave() {
    // try {
    //   hubConnection.stop();
    // } catch (error) {
    //   hubConnection.stop();
    // }
    //alert(123);
  }
  ionViewCanEnter() {
    this.storage.get('serverData').then(serverData => {
      this.server = serverData;
      const connection = hubConnection(`${this.server.socketServer}`, {
        qs:
          'name=remotopelotaVasca' +
          Math.floor(Math.random() * 100) +
          1 +
          '&group=remotopelotaVasca'
      });
      this.hubProxy = connection.createHubProxy('MarcadorPelotaVascaHub');

      connection
        .start({ transport: 'longPolling', xdomain: true })
        .done(function () {
          console.log('Ahora conectado, ID de conexión =' + connection.id);
        })
        .fail(function () {
          console.log('No se pudo conectar');
        });
      connection.stateChanged((change) => {
        console.log(change);
        if (change.newState === 4) {
          this.setMessage('Intentando Conectar...', 1500, 'top');
          connection
            .start({ transport: 'longPolling', xdomain: true })
            .done(function () {
              console.log('Ahora conectado, ID de conexión =' + connection.id);
            })
            .fail(function () {
              console.log('No se pudo conectar');
            });
        }
        if (change.newState === 2) {
          this.setMessage('Intentando Conectar...', 1500, 'top');
        }
        if (change.newState === 1) {
          this.onInitMarcador();
          this.setMessage('Conexión Establecida...', 3500, 'top');
        }
      });
    });
    return true;
  }

  ionViewDidLoad() {

  }
  private getDAtaDeporte() {
    this.storage.get('deporteSeleccionado').then(val => {
      try {
        this.deporte_data = val;
        this.deporte = val.text;
      } catch (error) { }
    });
  }
  private getCronograma() {
    this.storage.get('cronograma').then(val => {
      this.cronograma_id = val;
      this.getDataCronograma(val);
    });
  }

  private getDataCronograma(id: string) {
    this.botonesA = [];
    this.botonesB = [];

    this.storage.get(id).then(val => {
      if (val === null) {
        return;
      }
      this.cronogramaItem = val;
      this.idCompetidorA = this.cronogramaItem.CompetidorAId;
      this.idCompetidorB = this.cronogramaItem.CompetidorBId;
      this.Equipo_a_nombre = this.cronogramaItem.NombreReducidoEquipoA;
      this.Equipo_b_nombre = this.cronogramaItem.NombreReducidoEquipoB;
      this.prueba_texto = this.cronogramaItem.Prueba;
      for (
        let index = 0;
        index < this.cronogramaItem.botoneraA.length;
        index++
      ) {
        const botonA = this.cronogramaItem.botoneraA[index];
        const botonB = this.cronogramaItem.botoneraB[index];
        this.botonesA.push(botonA);
        this.botonesB.push(botonB);
      }

      this.periodos = this.cronogramaItem.periodos.sort((a, b) => {
        if (b.Orden > a.Orden) {
          return -1;
        } else {
          if (b.Orden < a.Orden) {
            return 1;
          } else {
            return 0;
          }
        }
      });
      for (let index = 0; index < this.periodos.length; index++) {

        this.periodos[index].Punto = this.prueba_texto.includes('individual') ? 10 : 15;

      }
      this.storage.set("periodos", this.periodos);
    });
  }

  play() {
    this.action = 1;
    this.visible = true;
  }
  play_descanso() {
    this.action_descanso = 5;
  }
  pause_descanso() {
    this.action_descanso = 3;
  }
  stop_descanso() {
    this.action_descanso = 2;
  }
  setTiempo() {
    this.action = 5;
    this.visible = true;
  }
  pause() {
    this.action = 3;
    this.visible = false;
  }
  reload() {
    this.reset = !this.reset;
    this.pause();
    this.tiempo = '00:00';
    this.reversa = false;

    this.pause_descanso();
    this.tiempo_descanso = '00:00';
  }
  stop() {
    this.action = 2;
  }
  private reloadPeriodo($event) {
    this.puntajeA = isNaN($event.marcadorA) ? 0 : $event.marcadorA;
    this.puntajeB = isNaN($event.marcadorB) ? 0 : $event.marcadorB;
    this.refrescar = !this.refrescar;
  }

  iniciarCronometro($event) {
    const periodo_seleccionado = $event;
    this.periodo_actual =
      periodo_seleccionado.Orden - 1 > 0 ? periodo_seleccionado.Orden - 1 : 0;

    this.initPeriodo(periodo_seleccionado);
    this.reloadPeriodo($event);
    this.reloadBotonera($event);
    this.hubProxy.invoke('PeriodoEvent', $event);

    this.onChengeMArcador();
  }
  private initPeriodo(periodo_seleccionado) {
    this.lado = 2;
    this.solo_lectura = 1;
    this.mensaje = '';
    this.periodo_titulo = periodo_seleccionado.Periodo;
    this.periodo_punto = periodo_seleccionado.Punto;

    const tiempo_aux =
      periodo_seleccionado.Tiempo !== ''
        ? new String(periodo_seleccionado.Tiempo).split(':')
        : '00:00:00'.split(':');

    if (tiempo_aux.length === 3) {
      this.tiempo = tiempo_aux[1] + ':' + tiempo_aux[2];
      this.reversa =
        Number(periodo_seleccionado.TipoCronometro) === 2 ? true : false;

      if (Number(periodo_seleccionado.TipoPeriodo) === 4) {
        this.setTiempo();
      } else {
        this.finReversa_descanso();
      }
    }
  }
  finReversa_descanso() {
    console.log('inicia cronometro del periodo');
    this.solo_lectura = this.periodos[this.periodo_actual].TipoPeriodo === 4 ? 1 : 0;
    this.setTiempo();
  }
  private initMensajesButton($event, valor: number) {
    this.captura_tiempo = !this.captura_tiempo;
    this.textButton = $event.Parametro;

    //*********************************************************** */
    this.storage.get(String(this.cronograma_id)).then(val => {
      val.periodos[this.periodo_actual].BotoneraA = [];
      val.periodos[this.periodo_actual].BotoneraB = [];
      val.periodos[this.periodo_actual].marcadorA = this.puntajeA;
      val.periodos[this.periodo_actual].marcadorB = this.puntajeB;

      this.botonesA.forEach(element => {
        val.periodos[this.periodo_actual].BotoneraA.push(element);
      });
      this.botonesB.forEach(element => {
        val.periodos[this.periodo_actual].BotoneraB.push(element);
      });

      this.storage.set(String(this.cronograma_id), val);

    });
    this.onChengeMArcador();
  }
  clickA($event, accion: boolean) {

    const tipo = $event.Tipo;
    const valor = tipo === 2 ? 0 : Number($event.ValorSuceso);
    if (valor > 0) {
      this.posesion = 1;
    }
    if (accion) {
      this.mensaje = $event.Parametro;
      this.puntajeA += valor;
    } else {
      this.mensaje = '';
      this.puntajeA = this.puntajeA - valor < 0 ? 0 : this.puntajeA - valor;
    }
    this.periodos[this.periodo_actual].marcadorA = this.puntajeA;


    if (this.puntajeA > 0) {
      this.lado = this.matematicas.parImpar(this.puntajeA) ? 2 : 1;
    }
    this.initMensajesButton($event, valor);
  }
  clickB($event, accion: boolean) {

    const tipo = $event.Tipo;
    const valor = tipo === 2 ? 0 : Number($event.ValorSuceso);

    if (valor > 0) {
      this.posesion = 2;
    }
    if (accion) {
      this.mensaje = $event.Parametro;
      this.puntajeB += valor;
    } else {
      this.mensaje = '';
      this.puntajeB = this.puntajeB - valor < 0 ? 0 : this.puntajeB - valor;
    }
    this.periodos[this.periodo_actual].marcadorB = this.puntajeB;

    if (this.puntajeB > 0) {
      this.lado = this.matematicas.parImpar(this.puntajeB) ? 2 : 1;
    }
    this.initMensajesButton($event, valor);
  }

  captura($event) {
    console.log($event);
  }
  onChengeMArcador() {

    this.onInitMarcador();
    this.vibration.vibrate(1000);
  }
  onInitMarcador() {

    const dataVisor = {
      pointsA: this.puntajeA,
      pointsB: this.puntajeB,
      nameA: this.Equipo_a_nombre,
      nameB: this.Equipo_b_nombre,
      balon: this.lado,
      text: this.textButton,
      mensaje: this.mensaje,
      posesion: this.posesion,
      idCompetidorA: this.idCompetidorA,
      idCompetidorB: this.idCompetidorB,
      periodos: this.periodos,
      prueba: this.cronogramaItem.Prueba,
      PersonasEquipoA: this.cronogramaItem.PersonasEquipoA,
      PersonasEquipoB: this.cronogramaItem.PersonasEquipoB,
      DelegacionIdA: this.cronogramaItem.DelegacionIdA,
      DelegacionIdB: this.cronogramaItem.DelegacionIdB,
      personaIdA: this.cronogramaItem.personaIdA,
      personaIdB: this.cronogramaItem.personaIdB
    };
    this.hubProxy.invoke('ChangeVisor', dataVisor);
  }
  getTiempo($event) {
    this.hubProxy.invoke('cronometroEvent', $event);
  }
  finReversa() {
    const tipo = this.periodos[this.periodo_actual].TipoPeriodo;
    console.log(tipo + '-' + this.periodo_actual);

    if (this.periodo_actual < this.periodos.length && tipo === 4) {
      const aux = this.periodo_actual + 1;
      const siguiente_periodo = this.periodos[aux];
      if (siguiente_periodo.TipoPeriodo === 4) {
        this.periodo_actual++;

        this.reversa = true;
        this.action = 0;
        this.initPeriodo(siguiente_periodo);
        this.reloadPeriodo(siguiente_periodo);
        console.log(this.tiempo)
        this.forzar_tiempo = this.tiempo;
        this.hubProxy.invoke('PeriodoEvent', siguiente_periodo);
        this.onChengeMArcador();
      }

    }
  }

  getTiempo_descanso($event) {
    this.hubProxy.invoke('cronometroDescuentoEvent', $event);
  }

  public setMessage(text: string, time: number, position: string) {
    let toast = this.toastCtrl.create({
      message: text,
      duration: time,
      position: position
    });

    toast.onDidDismiss(() => {

    });
    toast.present();
  }
  private reloadBotonera($event) {

    this.storage.get(String(this.cronograma_id)).then(val => {

      if (val !== null) {
        if (val.periodos[this.periodo_actual].BotoneraA != undefined) {

          for (let index = 0; index < val.periodos[this.periodo_actual].BotoneraA.length; index++) {
            const item = val.periodos[this.periodo_actual].BotoneraA[index];
            this.botonesA[index].Valor = item.Valor;
          }

        } else {
          this.refrescar = !this.refrescar;
        }

        if (val.periodos[this.periodo_actual].BotoneraB != undefined) {

          for (let index = 0; index < val.periodos[this.periodo_actual].BotoneraB.length; index++) {
            const item = val.periodos[this.periodo_actual].BotoneraB[index];
            this.botonesB[index].Valor = item.Valor;
          }

        }


      }

    });



  }

  gameOver() {
    this.presentConfirm();
  }

  presentConfirm() {
    let alert = this.alertCtrl.create({
      title: 'Finalizar encuentro',
      message: '¿Desea terminar el encuentro?',
      buttons: [
        {
          text: 'No',
          role: 'cancel'
        },
        {
          text: 'Si',
          handler: () => {
            this.storage.get('concluidos').then(data => {
              if (data != null && data != undefined) {
                this.listaConcluidos = data;
              }
              let val1 = this.listaConcluidos.filter(item => item == this.cronograma_id);
              if (val1.length == 0) {
                this.listaConcluidos.push(this.cronograma_id);
              }
              this.storage.set('concluidos', this.listaConcluidos);
              this.navCtrl.pop();
            });
          }
        }
      ]
    });
    alert.present();
  }
}
