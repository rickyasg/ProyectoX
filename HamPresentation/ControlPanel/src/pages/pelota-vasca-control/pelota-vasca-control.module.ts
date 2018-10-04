import { NgModule } from '@angular/core';
import { IonicPageModule } from 'ionic-angular';
import { S46ControlPage } from './pelota-vasca-control';
import { ComponentsModule } from '../../components/components.module';

@NgModule({
  declarations: [
    S46ControlPage,
  ],
  imports: [
    IonicPageModule.forChild(S46ControlPage),ComponentsModule
  ],
})
export class PelotaVascaControlPageModule {}
