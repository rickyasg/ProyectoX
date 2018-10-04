import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { LocationStrategy, HashLocationStrategy } from '@angular/common';
import { AppRoutes } from './app.routes';

import { NguiAutoCompleteModule } from '@ngui/auto-complete';

import 'rxjs/add/operator/toPromise';

import { AccordionModule } from 'primeng/accordion';
import { AutoCompleteModule } from 'primeng/autocomplete';
import { ButtonModule } from 'primeng/button';
import { CalendarModule } from 'primeng/calendar';
import { CheckboxModule } from 'primeng/checkbox';
import { CodeHighlighterModule } from 'primeng/codehighlighter';
import { ConfirmDialogModule } from 'primeng/ConfirmDialog';
import { ContextMenuModule } from 'primeng/contextmenu';
import { DataGridModule } from 'primeng/primeng';
import { DataListModule } from 'primeng/primeng';
import { DataScrollerModule } from 'primeng/primeng';
import { DataTableModule } from 'primeng/primeng';
import { DialogModule } from 'primeng/primeng';
import { DragDropModule } from 'primeng/primeng';
import { DropdownModule } from 'primeng/primeng';
import { EditorModule } from 'primeng/primeng';
import { FieldsetModule } from 'primeng/primeng';
import { FileUploadModule } from 'primeng/primeng';
import { GalleriaModule } from 'primeng/primeng';
import { GMapModule } from 'primeng/primeng';
import { GrowlModule } from 'primeng/primeng';
import { InputMaskModule } from 'primeng/primeng';
import { InputSwitchModule } from 'primeng/primeng';
import { InputTextModule } from 'primeng/primeng';
import { InputTextareaModule } from 'primeng/primeng';
import { LightboxModule } from 'primeng/primeng';
import { ListboxModule } from 'primeng/primeng';
import { MegaMenuModule } from 'primeng/primeng';
import { MenuModule } from 'primeng/primeng';
import { MenubarModule } from 'primeng/primeng';
import { MessagesModule } from 'primeng/primeng';
import { MultiSelectModule } from 'primeng/primeng';
import { OrderListModule } from 'primeng/primeng';
import { OverlayPanelModule } from 'primeng/primeng';
import { PaginatorModule } from 'primeng/primeng';
import { PanelModule } from 'primeng/primeng';
import { PanelMenuModule } from 'primeng/primeng';
import { PasswordModule } from 'primeng/primeng';
import { PickListModule } from 'primeng/primeng';
import { ProgressBarModule } from 'primeng/primeng';
import { RadioButtonModule } from 'primeng/primeng';
import { RatingModule } from 'primeng/primeng';
import { ScheduleModule } from 'primeng/primeng';
import { SelectButtonModule } from 'primeng/primeng';
import { SlideMenuModule } from 'primeng/primeng';
import { SliderModule } from 'primeng/primeng';
import { SpinnerModule } from 'primeng/primeng';
import { SplitButtonModule } from 'primeng/primeng';
import { StepsModule } from 'primeng/primeng';
import { TabMenuModule } from 'primeng/primeng';
import { TabViewModule } from 'primeng/primeng';
import { TerminalModule } from 'primeng/primeng';
import { TieredMenuModule } from 'primeng/primeng';
import { ToggleButtonModule } from 'primeng/primeng';
import { ToolbarModule } from 'primeng/primeng';
import { TooltipModule } from 'primeng/primeng';
import { TreeModule } from 'primeng/primeng';
import { TreeTableModule } from 'primeng/primeng';

import { AppComponent } from './app.component';
import { AppMenuComponent, AppSubMenu } from './app.menu.component';
import { AppTopBar } from './site/view/components/topbar/tabbar.component';
import { AppFooter } from './app.footer.component';
import { InlineProfileComponent } from './app.profile.component';

import { AuthGuard } from './site/shared/auth.guard';
import { Login } from './site/view/components/login/login.component';
import { MasterPage } from './site/view/components/mastePage/master-page.component';
// import { UsuarioListadoComponent } from './site/view/Administracion/usuario/usuario-listado/usuario-listado.component';
// import { DetalleUsuarioComponent } from './site/view/Administracion/usuario/usuario-detalle/usuario-detalle.component';
// import { UsuarioPrivilegiosComponent } from './site/view/Administracion/usuario/usuario-privilegios/usuario-privilegios.component';

// import { StepsComponent } from './site/view/components/steps/steps.component';


// tslint:disable-next-line:max-line-length
import { WebcamComponent } from './site/view/components/multimedia/webcam/webcam.component';



import { UserPassComponent } from './site/view/Administracion/usuario/user-pass/user-pass.component';
// import { CronogramaConjuntoComponent } from './site/component/grilla/cronograma-conjunto/cronograma-conjunto.component';
// import { DeportesComponent } from './site/component/dropdown/deportes/deportes.component';
// import { UsuarioRegistroComponent } from './site/view/Administracion/usuario/usuario-registro/usuario-registro.component';
// import { AutocompleteComponent } from './site/component/searchpersona/autocomplete/autocomplete.component';
// import { DialogoConjuntoComponent } from './site/component/dialogo/dialogo-conjunto/dialogo-conjunto.component';
// import { BotonConjuntoComponent } from './site/component/boton/boton-conjunto/boton-conjunto.component';
// import { BuscarPersonaComponent } from './site/component/searchpersona/buscar-persona/buscar-persona.component';
// import { DialogoCompetidorComponent } from './site/component/dialogo-competidor/dialogo-competidor.component';
// tslint:disable-next-line:max-line-length
// import { PmenuComponent } from './site/view/pmenu/pmenu.component';
 import { VwFormularioComponent } from './site/view/Denuncias/vw-formulario/vw-formulario.component';
 import { VwListadosComponent } from './site/view/Denuncias/vw-listados/vw-listados.component';
import { DropParametrosComponent } from './site/component/dropdown/drop-parametros/drop-parametros.component';
import { DropZonificacionComponent } from './site/component/dropdown/drop-zonificacion/drop-zonificacion.component';
import { DropOfficesComponent } from './site/component/dropdown/drop-offices/drop-offices.component';



// export function createConfig(): SignalRConfiguration {
//   const c = new SignalRConfiguration();
//   c.hubName = 'testHub';
//   c.qs = { name: 'donald' };
//   c.url = 'http://localhost:61428';
//   c.logging = true;
//   return c;
// }

@NgModule({
  imports: [
    BrowserModule,
    FormsModule,
    ReactiveFormsModule,
    AppRoutes,
    HttpModule,
    BrowserAnimationsModule,
    AccordionModule,
    AutoCompleteModule,
    ButtonModule,
    CalendarModule,
    CheckboxModule,
    CodeHighlighterModule,
    ConfirmDialogModule,
    ContextMenuModule,
    DataGridModule,
    DataListModule,
    DataScrollerModule,
    DataTableModule,
    DialogModule,
    DragDropModule,
    DropdownModule,
    EditorModule,
    FieldsetModule,
    FileUploadModule,
    GalleriaModule,
    GMapModule,
    GrowlModule,
    InputMaskModule,
    InputSwitchModule,
    InputTextModule,
    InputTextareaModule,
    LightboxModule,
    ListboxModule,
    MegaMenuModule,
    MenuModule,
    MenubarModule,
    MessagesModule,
    MultiSelectModule,
    OrderListModule,
    OverlayPanelModule,
    PaginatorModule,
    PanelModule,
    PanelMenuModule,
    PasswordModule,
    PickListModule,
    ProgressBarModule,
    RadioButtonModule,
    RatingModule,
    ScheduleModule,
    SelectButtonModule,
    SlideMenuModule,
    SliderModule,
    SpinnerModule,
    SplitButtonModule,
    StepsModule,
    TabMenuModule,
    TabViewModule,
    TerminalModule,
    TieredMenuModule,
    ToggleButtonModule,
    ToolbarModule,
    TooltipModule,
    TreeModule,
    TreeTableModule,
    NguiAutoCompleteModule
  ],
  declarations: [
    AppComponent,
    AppMenuComponent,
    AppSubMenu,
    AppTopBar,
    AppFooter,
    InlineProfileComponent,
    Login,
    MasterPage,
    WebcamComponent,
    UserPassComponent,
     VwFormularioComponent,
     VwListadosComponent,
     DropParametrosComponent,
     DropZonificacionComponent,
     DropOfficesComponent
  ],
  providers: [
    { provide: LocationStrategy, useClass: HashLocationStrategy },
    AuthGuard
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
