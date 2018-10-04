import { Routes } from '@angular/router';
import { VwFormularioComponent } from '../Denuncias/vw-formulario/vw-formulario.component';
import { VwListadosComponent } from '../Denuncias/vw-listados/vw-listados.component'

export const DenunciasRoutes: Routes = [
    { path: 'form-denuncias', component: VwFormularioComponent },
    { path: 'form-vw-listado', component: VwListadosComponent}
];