export class Complainant {
        ComplainantId : number=0;  
        Name :string ;
        SecondName : string ;
        LastName : string;
        SecondLastName :string ;
        NroDocument : string;
        ParameterExtent : number ;
        ParameterGender :number ;
        BirthDate :Date ;
        ParameterCivilStatus : number ;
        ParameterNationality : number;
        Address : string;
        Phone : string;

        LaborDataId :number ;
        Occupation :string ;
        Workplace :string;
        wPhone : string;
        wAddress : string;


    constructor(values: Object = {}) {
        Object.assign(this, values);
    }
}

