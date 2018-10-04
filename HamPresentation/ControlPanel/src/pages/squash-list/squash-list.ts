import { Component } from '@angular/core';
import { Storage } from '@ionic/storage';
import {
  IonicPage,
  NavController,
  NavParams,
  PopoverController
} from 'ionic-angular';
import { PrvSquashProvider } from '../../providers/prv-squash/prv-squash';
import { PrvDeporteProvider } from '../../providers/prv-deporte/prv-deporte';
import { Texto } from '../../domain/deporte/texto';
import { AlertController } from 'ionic-angular';
import { Cronograma } from '../../domain/deporte/cronograma';

@IonicPage()
@Component({
  selector: 'page-squash-list',
  templateUrl: 'squash-list.html'
})
export class SquashListPage {
  fechaCronograma: any;
  dataCronograma: any[];
  texto: Texto;
  deporteId = 0;
  eventoId = 6;
  deporte = '';
  listaConcluidos: number[] = [];

  constructor(
    public navCtrl: NavController,
    public alertCtrl: AlertController,
    public navParams: NavParams,
    private prvSquashProvider: PrvSquashProvider,
    private prvDeporteProvider: PrvDeporteProvider,
    private storage: Storage
  ) {
    this.texto = new Texto();
    this.deporteId = 49;
    //this.eventoId = 6;
    this.dataCronograma = [];
  }
  ionViewCanEnter() {
    this.initDeporte();
    this.dataCronograma = [];
    return true;
  }
  private initDeporte() {
    this.storage.get('eventoId').then((eventoId) => {
      if (eventoId == null)
        this.eventoId = 4;
      else
        this.eventoId = eventoId;
    });
    this.storage.get('deporteSeleccionado').then(deporteSeleccionado => {
      if (deporteSeleccionado == null) {
        this.deporteId = 0;
      } else {
        console.log(deporteSeleccionado);
        this.deporte = deporteSeleccionado.text;
        this.deporteId = deporteSeleccionado.id;
      }

      this.storage.get('concluidos').then(data => {
        if (data != null && data != undefined) {
          this.listaConcluidos = data;
        }
        this.onChangeFecha();
      });
      //this.deporteId=deporteSeleccionado.;
    });
  }
  ionViewDidLoad() {
    this.fechaCronograma = '02/02/2018';
  }

  openConfig() {
    this.navCtrl.push('SettingsPage');
  }

  onChangeFecha() {
    if (this.deporteId === 0 || this.deporteId === null || this.deporteId === undefined || Number(this.deporteId) === NaN) {
      this.mostrarMensaje('Mensaje', 'Debe elegir un deporte en la configuración del sistema');
    }
    else {
      this.getDataLocal();
    }
  }
  private loadBaseDatos() {
    if (this.dataCronograma.length === 0) {
      this.reload();
    } else {
      console.log(this.dataCronograma)
      console.log('valores cargados local-storage');
    }
  }
  recargarDatos() {
    this.mostrarMensaje('Mensaje', 'Información cargada de la Base de datos');
    this.reload();
  }
  reload() {
    this.dataCronograma = [];
    this.storage.remove('cronograma|' + this.fechaCronograma);
    this.prvSquashProvider
      .getCronograma(this.eventoId, this.deporteId, 0, this.fechaCronograma)
      .then(res => {
        for (let index = 0; index < res.length; index++) {
          const item = res[index];
          this.storage.remove(String(item.CronogramaId));
          this.getData(item, index);
        }
        console.log('valores cargados Base de datos');
      })
      .catch(res => console.log('error'));
  }

  private getData(item: any, i: number) {

    let cronograma = new Cronograma();
    cronograma.fecha = this.fechaCronograma;
    cronograma.i = i;
    cronograma.Hora =
      this.texto.lpad(
        '0',
        2,
        String(new Date('1968-11-16T' + item.HoraProgramada).getHours())
      ) +
      ':' +
      this.texto.lpad(
        '0',
        2,
        String(new Date('1968-11-16T' + item.HoraProgramada).getMinutes())
      );
    cronograma.EquipoA = item.EquipoA == null ? '' : item.EquipoA;
    cronograma.EquipoB = item.EquipoB == null ? '' : item.EquipoB;
    cronograma.Escenario = item.Instalacion;
    cronograma.Estado =
      item.MarcadorEquipoA == null || item.MarcadorEquipoB == null
        ? 'Abierto'
        : item.Estado;
    cronograma.Puntuacion =
      (item.MarcadorEquipoA == null ? '0' : item.MarcadorEquipoA) +
      '-' +
      (item.MarcadorEquipoB == null ? '0' : item.MarcadorEquipoB);
    cronograma.EventoId = item.EventoId;
    cronograma.CompetidorAId =
      item.CompetidorAId == null ? 0 : item.CompetidorAId;
    cronograma.CompetidorBId =
      item.CompetidorBId == null ? 0 : item.CompetidorBId;
    cronograma.Planilla = 0;
    cronograma.CronogramaId = item.CronogramaId;
    cronograma.HoraInicio = item.HoraInicio == null ? '00:00' : item.HoraInicio;
    cronograma.HoraFin = item.HoraFin == null ? '00:00' : item.HoraFin;
    cronograma.PlanillaEstado = 0;
    cronograma.Genero = item.Rama;
    cronograma.Prueba = item.Prueba;
    cronograma.Instalacion = item.Instalacion;
    cronograma.PlanillaId = item.CronogramaId;
    cronograma.NombreReducidoEquipoA = item.NombreReducidoEquipoA;
    cronograma.NombreReducidoEquipoB = item.NombreReducidoEquipoB;
    cronograma.EquipoIdA = item.EquipoIdA;
    cronograma.EquipoIdB = item.EquipoIdB;
    cronograma.DelegacionIdA = item.DelegacionIdA;
    cronograma.DelegacionIdB = item.DelegacionIdB;

    this.prvDeporteProvider.getPersonas(item.CompetidorAId).then(rsA => {
      //console.clear()
      console.log(rsA)
      cronograma.listaA = rsA;
      this.prvDeporteProvider.getPersonas(item.CompetidorBId).then(rsB => {
        cronograma.listaB = rsB;
        this.prvDeporteProvider
          .getSucesosDeporte(this.deporteId)
          .then(res => {

            cronograma.botoneraA = res;
            this.prvDeporteProvider
              .getSucesosDeporte(this.deporteId)
              .then(res => {
                cronograma.botoneraB = res;
                this.prvDeporteProvider
                  .getPeriodoPartido(this.eventoId, this.deporteId)
                  .then(res => {

                    cronograma.periodos = res.sort((a, b) => {
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
                    this.prvDeporteProvider.getEquiposPersona(cronograma.EquipoIdA).then(res => {
                      cronograma.PersonasEquipoA = res;
                      this.prvDeporteProvider.getEquiposPersona(cronograma.EquipoIdB).then(res => {
                        cronograma.PersonasEquipoB = res;
                        this.prvDeporteProvider.getPersonaId(cronograma.CompetidorAId).then(res => {
                          cronograma.personaIdA = res;
                          this.prvDeporteProvider.getPersonaId(cronograma.CompetidorBId).then(res => {
                            cronograma.personaIdB = res;
                            /*================================================================*/
                            this.dataCronograma.push(cronograma);
                            this.storage.set(
                              'cronograma|' + this.fechaCronograma,
                              JSON.stringify(this.dataCronograma)
                            );
                          });


                        });



                      });
                    });

                  });
              });
          });
      });
    });

  }
  private getDataLocal() {
    this.dataCronograma = [];

    this.storage.get('cronograma|' + this.fechaCronograma).then(val => {
      this.dataCronograma = JSON.parse(val);
      if (this.dataCronograma === null) {
        this.dataCronograma = [];
      }

      this.dataCronograma = this.setState(this.dataCronograma);
      this.dataCronograma.sort(this.sortByProperty('EstadoLista'))
      this.loadBaseDatos();
    });
  }
  setState(objeto) {
    let auxiliar = new Array();
    objeto.forEach(element => {
      let val1 = this.listaConcluidos.filter(item => item == element.CronogramaId);
      if (val1.length > 0) {
        element.EstadoLista = true;
      } else {
        element.EstadoLista = false;
      }
      auxiliar.push(element);
    });
    return auxiliar;
  }

  sortByProperty(property) {
    return function (x, y) {
      return ((x[property] === y[property]) ? 0 : ((x[property] > y[property]) ? 1 : -1));
    };
  }

  itemSelected(item) {

    this.storage.get(String(item.CronogramaId)).then(val => {
      this.storage.set('cronograma', item.CronogramaId);
      console.clear();
      console.log(val);
      if (val === null) {
        this.storage.set(item.CronogramaId, item).then(val => {
          this.navCtrl.push('S' + this.deporteId + 'ControlPage', { deporte: this.deporte });
        });
      } else {
        this.navCtrl.push('S' + this.deporteId + 'ControlPage', { deporte: this.deporte });
      }

    });

  }
  mostrarMensaje(titulo: string, mensaje: string) {
    let alert = this.alertCtrl.create({
      title: titulo,
      subTitle: mensaje,
      buttons: ['OK']
    });
    alert.present();
  }

  private getNombreDeporte() {
    this.storage.get('deporte').then(val => {
      this.deporte = val;
      if (this.deporte === null) {
        this.deporte = '';
      }
      if (this.deporte === '') {
        this.prvDeporteProvider.getDeportes(this.eventoId).then(res => {
          if (res.length > 0) {
            var dato_deporte = res.filter(
              item => Number(item.DeporteId) === Number(this.deporteId)
            )[0];
            this.deporte = dato_deporte.DeporteDescripcion;
            this.storage.set('deporte', this.deporte);
            this.storage.set('dato_deporte', dato_deporte);
          }
        });
      } else {
        console.log('datos deporte cargados de storage');
      }
    });
  }
}
