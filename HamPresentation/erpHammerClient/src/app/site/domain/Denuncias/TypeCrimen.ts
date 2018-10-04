export class TypeCrimen {
    TypeCrimeId: number;
    Crime: string;
    Description:string;
    Code:string;
    constructor(values: Object = {}) {
        Object.assign(this, values);
    }
}
