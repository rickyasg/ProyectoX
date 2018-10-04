export class Office {
  
    OfficeId:number=0;
    Name:string;
    Level:number=0;
    DependentId:number=0;
    Address:string;

    constructor(values: Object = {}) {
        Object.assign(this, values);
    }
}