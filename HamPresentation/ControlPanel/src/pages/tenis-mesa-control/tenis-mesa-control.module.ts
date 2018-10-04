import { NgModule } from '@angular/core';
import { IonicPageModule } from 'ionic-angular';
import { S13ControlPage } from './tenis-mesa-control';
import { ComponentsModule } from '../../components/components.module';
@NgModule({
  declarations: [
    S13ControlPage,
  ],
  imports: [
    IonicPageModule.forChild(S13ControlPage),ComponentsModule
  ],
})
export class TenisMesaControlPageModule {}
