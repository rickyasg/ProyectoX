import { Routes, RouterModule } from '@angular/router';
import { ModuleWithProviders } from '@angular/core';
import { MasterPage } from './site/view/components/mastePage/master-page.component';
import { Login } from './site/view/components/login/login.component';
// tslint:disable-next-line:max-line-length
import { MasterRoutes } from './site/view/components/mastePage/master-page.routes';
// import { UsersListComponent } from './site/view/Administracion/usuario/users-list/users-list.component';


// import { PmenuComponent } from './site/view/pmenu/pmenu.component';
// tslint:disable-next-line:max-line-length
// import { CronogramaConjuntoComponent } from './site/component/grilla/cronograma-conjunto/cronograma-conjunto.component';


export const routes: Routes = [
  ...MasterRoutes,
  { path: 'login', component: Login },
  // { path: 'userList', component: UsersListComponent },
  // { path: 'cronograna-conjunto', component: CronogramaConjuntoComponent },
  // { path: 'Acre', component: PmenuComponent }
];

export const AppRoutes: ModuleWithProviders = RouterModule.forRoot(routes);
