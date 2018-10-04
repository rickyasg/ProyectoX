import { Injectable } from '@angular/core';
import { Http, Response, RequestOptions, Headers } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/Rx';
import * as urls from '../../domain/Shared/global';
import { SelectItemGroup } from 'primeng/primeng';
import { TypeCrimen } from '../../domain/Denuncias/TypeCrimen';
import { GroupTypeCrimen } from '../../domain/Denuncias/GroupTypeCrimen';
import { Complaints } from 'app/site/domain/Denuncias/Complaints'
 

@Injectable()
export class DenunciasService {

  constructor(public http:Http) { }
 
 
  getTypeCrimen():Promise<TypeCrimen[]>
  {
    return this.http
    .get(`${urls.urlSecurity}/api/Felcc/getTypeCrimen`)
    .toPromise()
    .then((r: Response) =>
        r.json() as TypeCrimen[]);
  }

  getGroupTypeCrimen(search:string):Promise<SelectItemGroup[]>
  {
    return this.http
    .get(`${urls.urlSecurity}/api/Felcc/getGroupTypeCrimen?search=${search}`)
    .toPromise()
    .then((r: Response) =>
        r.json() as SelectItemGroup[]);
  }

  getDenuncias():Promise<any[]>
  {
    return this.http
    .get(`${urls.urlSecurity}/api/Felcc/getDenuncias`)
    .toPromise()
    .then((r: Response) =>
        r.json() as any[]);
  }

  setDenunciaPasoUno(data:Complaints):Observable<Response>
  {
    const headers = new Headers({ 'Content-Type': 'application/json' });
    const options = new RequestOptions({ headers: headers });
    return this.http.post(
      `${urls.urlSecurity}/api/Felcc/SaveDemanda?data=${data}`,
      data,
      options
  );
  }
  setDenunciaPasoDos(data:Complaints):Observable<Response>
  {
    const headers = new Headers({ 'Content-Type': 'application/json' });
    const options = new RequestOptions({ headers: headers });
    return this.http.post(
      `${urls.urlSecurity}/api/Felcc/UpdaDemanda?data=${data}`,
      data,
      options
  );
  }


}
