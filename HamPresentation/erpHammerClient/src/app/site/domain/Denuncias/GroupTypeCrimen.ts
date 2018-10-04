import { TypeCrimen } from '../../domain/Denuncias/TypeCrimen';

export class GroupTypeCrimen {

    OrganizationId : number;
    Name : string;
    Level : number;
    DependentId : number;
    TypeCrimens: TypeCrimen[]=[];

    constructor(values: Object = {}) {
        Object.assign(this, values);

    }
}