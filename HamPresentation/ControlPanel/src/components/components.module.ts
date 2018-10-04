import { NgModule } from '@angular/core';
import { BotonComponent } from './boton/boton';
import { IonicModule } from 'ionic-angular';
import { CronometroComponent } from './cronometro/cronometro';
import { BotonPeriodoComponent } from './boton-periodo/boton-periodo';
import { BotonIzqDerComponent } from './boton-izq-der/boton-izq-der';
@NgModule({
	declarations: [BotonComponent,
    CronometroComponent,
    BotonPeriodoComponent,
    BotonIzqDerComponent],
	imports: [IonicModule],
	exports: [BotonComponent,
    CronometroComponent,
    BotonPeriodoComponent,
    BotonIzqDerComponent]
})
export class ComponentsModule {}
