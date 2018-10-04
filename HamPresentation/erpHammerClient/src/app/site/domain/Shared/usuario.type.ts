import { Menu } from './menu.type';


export class Usuario {
   /**Old Estructura */
    UsuarioId: number;
    Usuario: string;
    OficinaId: string;
    IsActivo: boolean;
    PersonaId: number;
    FechaRegistro: Date;
    /**End */
    UserId: number;
    User: string;
    PersonId: number;
    Username: string;
    Register:Date;
    TOC: Menu[];

    constructor(values: Object = {}) {
        Object.assign(this, values);
    }
}
