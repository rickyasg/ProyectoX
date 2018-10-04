// import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Http, Response } from '@angular/http';
import * as urls from '../global';
import { Storage } from '@ionic/storage';

/*
  Generated class for the PrvSquashProvider provider.

  See https://angular.io/guide/dependency-injection for more info on providers
  and Angular DI.
*/
@Injectable()
export class PrvSquashProvider {
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
      } else{
        this.dataServer = serverData;
      }
    });
  }

  getCronograma(eventoId: number, deporteId: number, delegacionId: number, fecha: string): Promise<any[]> {
    return this.http
      .get(`${this.dataServer.conjuntoServer}api/Set/GetProgramacionConjunto?eventoId=${eventoId}&delegacionId=${delegacionId}&deporteId=${deporteId}&fecha=${fecha}`)
      .toPromise()
      .then((r: Response) =>
        r.json() as any[]);
  }
}
