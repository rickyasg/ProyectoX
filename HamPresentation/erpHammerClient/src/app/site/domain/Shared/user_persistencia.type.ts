export class User {
    UsuarioId: number;
    Usuario: string;
    OficinaId: string;
    IsActivo: boolean;
    PersonaId: number;
    FechaRegistro: Date;
    Password: string;
    UserId: number;
    User: string;
    PersonId: number;
    Register:Date;

    constructor(values: Object = {}) {
        Object.assign(this, values);
    }
}
