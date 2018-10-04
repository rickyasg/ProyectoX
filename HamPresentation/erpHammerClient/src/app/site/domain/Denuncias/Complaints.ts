import { Complainant } from 'app/site/domain/Denuncias/Complainant';
import { Timestamp } from 'rxjs';
export class Complaints {
    ComplaintId:number=0;
    FiscalCase:string;
    OfficeId:number;
    OrganizationId:number;
    ZoningId:number;
    ParameterTypeViaId:number;
    NameStreet:string;
    DetailAddrees:string;
    DateFact: Date;
    HourFact:Date;
    Detail: Text; 
    Denunciante:Complainant;


    constructor(values: Object = {}) {
        this.Denunciante= new Complainant();
        Object.assign(this, values);
    }
}

