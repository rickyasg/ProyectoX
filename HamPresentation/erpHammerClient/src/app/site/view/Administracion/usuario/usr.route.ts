﻿import { Routes } from '@angular/router';
import { UserPassComponent } from '../../Administracion/usuario/user-pass/user-pass.component';
//  import { DetalleUsuarioComponent } from '../../Administracion/usuario/usuario-detalle/usuario-detalle.component';
//  import { UsuarioRegistroComponent } from '../../Administracion/usuario/usuario-registro/usuario-registro.component';

export const UsrRoutes: Routes = [
   { path: 'repass/:id', component: UserPassComponent},
//    { path: 'detalle-usuario/:usuarioId', component: DetalleUsuarioComponent},
//    { path: 'usuario-registro', component: UsuarioRegistroComponent}


];
