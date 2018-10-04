// import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Http, Response } from '@angular/http';
import * as urls from '../global';
import { Parametro } from '../../domain/deporte/parametro';
import { Deporte } from '../../domain/deporte/Deporte';
import { Periodo } from '../../domain/deporte/Periodo';
import { Storage } from '@ionic/storage';
import { EquipoPersona } from '../../domain/deporte/equipoPersona';
/*
  Generated class for the PrvDeporteProvider provider.

  See https://angular.io/guide/dependency-injection for more info on providers
  and Angular DI.
*/
@Injectable()
export class PrvDeporteProvider {
  dataServer: any = {};
  constructor(public http: Http,
    private storage: Storage) {
    this.storage.get('serverData').then((serverData) => {
      if (serverData === null) {
        this.dataServer = {
          commonServer: urls.urlCommon,
          genericServer: urls.urlGeneric,
          conjuntoServer: urls.urlConjunto,
          socketServer: urls.urlSockets
        }
      } else {
        this.dataServer = serverData;
      }
    });
  }
  getParametrosDeporte(
    competidorId: number,
    planillaId: number,
    deporteId: number,
    deportePeriodoId: number
    // equipoId: number
  ): Promise<Parametro[]> {
    return (
      this.http
        // tslint:disable-next-line:max-line-length
        .get(
          `${
          this.dataServer.conjuntoServer
          // tslint:disable-next-line:max-line-length
          }/api/Set/GetSucesoPartido?competidorId=${competidorId}&planillaId=${planillaId}&deporteId=${deporteId}&deportePeriodoId=${deportePeriodoId}`
        )
        .toPromise()
        .then((r: Response) => r.json() as Parametro[])
    );
  }
  getSucesosDeporte(deporteId: number): Promise<any[]> {
    return this.http
      .get(
        `${this.dataServer.conjuntoServer}/api/Set/GetParametroSuceso?deporteId=${deporteId}&control=1&visor=0`
      )
      .toPromise()
      .then((r: Response) => r.json() as any[]);
  }

  getDeportes(eventoId: number): Promise<Deporte[]> {
    return this.http
      .get(`${this.dataServer.genericServer}/api/Generic/GetDeportes?eventoId=${eventoId}`)
      .toPromise()
      .then((r: Response) => r.json() as Deporte[]);
  }

  getPeriodoPartido(eventoId: number, deporteId: number): Promise<Periodo[]> {
    return this.http
      .get(
        `${
        this.dataServer.conjuntoServer
        }/api/Set/GetDeportePeriodo?eventoId=${eventoId}&deporteId=${deporteId}`
      )
      .toPromise()
      .then((r: Response) => r.json() as Periodo[]);
  }
  getEquiposPersona(EquipoId: number): Promise<EquipoPersona[]> {
    return this.http
      .get(`${this.dataServer.conjuntoServer}/api/Set/getEquiposPersona?EquipoId=${EquipoId}`)
      .toPromise()
      .then((r: Response) => r.json() as EquipoPersona[])
  }

  getPersonas(competidorId: number): Promise<any[]> {
    return this.http
      .get(
        `${this.dataServer.conjuntoServer}/api/Set/getEquipoPersona?competidorId=${competidorId}`
      )
      .toPromise()
      .then((r: Response) => r.json() as any[]);
  }
  getPersonaId(competidorId: number): Promise<number> {
    return this.http
      .get(
        `${this.dataServer.conjuntoServer}/api/Set/getPersonaId?competidorId=${competidorId}`
      )
      .toPromise()
      .then((r: Response) => r.json() as number);
  }
}

