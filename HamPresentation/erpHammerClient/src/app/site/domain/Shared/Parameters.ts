export class Parameters {
    GroupId: number;
    ParameterId: number;
    Parameter: string;
    Short: string;
    Discription: string;
    Hidden: boolean;
    

    /*Parametros de Generic*/
    
    constructor(values: Object = {}) {
        Object.assign(this, values);
    }
}
