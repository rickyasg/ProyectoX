import { Injectable } from '@angular/core';
import { Http, Response, RequestOptions, Headers } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/Rx';
import * as urls from '../../domain/Shared/global';
import { SelectItem } from 'primeng/primeng';
import { Parameters } from 'app/site/domain/shared/Parameters';
import { Zoning } from 'app/site/domain/Shared/Zoning'
import { Office } from  'app/site/domain/shared/office'

@Injectable()
export class ParametroService {

    constructor(private http: Http) { }

    getParametroforCodigo(groupId: number): Promise<SelectItem[]> {
        return this.http.get(`${urls.urlSecurity}/api/Generic/getParameters?groupId=${groupId}`).toPromise().then(
            (r: Response) => r.json().map(item => {
                return { label: item.Parameter, value: item.ParameterId };
            }
            )
        );
     
    }
    getParametro(groupId: number): Promise<Parameters[]> {
        return this.http.get(`${urls.urlSecurity}/api/Generic/getParameters?groupId=${groupId}`).toPromise().then(
            (r: Response) => r.json() as Parameters[]);
    }
    
    getZoning(level: number, dependentId:number): Promise<Zoning[]> {
        return this.http.get(`${urls.urlSecurity}/api/Generic/getZoning?level=${level}&dependentId=${dependentId}`).toPromise().then(
            (r: Response) => r.json() as Zoning[]);
    }

    getOffices(level: number, dependentId:number): Promise<Office[]> {
        return this.http.get(`${urls.urlSecurity}/api/Generic/getOffice?level=${level}&dependentId=${dependentId}`).toPromise().then(
            (r: Response) => r.json() as Office[]);
    }
     
    
}
