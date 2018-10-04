export class Zoning {
  

    ZoningId:number=0;
    Department:number=0;
    Province:number;
    Municipality:number;
    Zone:number;
    Description:string;
    Level:number=0;
    DependentId:number=0;
    
    
    constructor(values: Object = {}) {
        Object.assign(this, values);
    }
}
