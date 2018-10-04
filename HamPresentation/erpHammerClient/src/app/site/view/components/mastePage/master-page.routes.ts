// RouterModule
import { Routes } from '@angular/router';
import { MasterPage } from '../mastePage/master-page.component';
import { Login } from '../login/login.component';
import { AuthGuard } from '../../../shared/auth.guard';
import { UsrRoutes } from '../../Administracion/usuario/usr.route';
// import { UsuarioListadoComponent } from '../../Administracion/usuario/usuario-listado/usuario-listado.component';
// import { DetalleUsuarioComponent } from '../../Administracion/usuario/usuario-detalle/usuario-detalle.component';
// import { UsuarioRegistroComponent } from '../../Administracion/usuario/usuario-registro/usuario-registro.component';
// import { BuscarCompetidorComponent } from '../../../component/buscar-competidor/buscar-competidor.component';
import { DenunciasRoutes } from '../../Denuncias/denuncias.route';
// Declaramos la ruta principal inicio y sus rutas hijas
export const MasterRoutes: Routes = [
  { path: '', redirectTo: 'master', pathMatch: 'full' },
  {
    path: 'master',
    component: MasterPage,
    canActivate: [AuthGuard],
    children: [
      ...DenunciasRoutes,
      // { path: 'listado-usuarios', component: UsuarioListadoComponent },
      // {
      //   path: 'detalle-usuario/:usuarioId',
      //   component: DetalleUsuarioComponent
      // },
      // { path: 'usuario-registro', component: UsuarioRegistroComponent },
      // {
      //   path: 'buscarCompetidor/:eventoId',
      //   component: BuscarCompetidorComponent
      // }
      
    ]
  }
];
