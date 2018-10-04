import { NgModule } from '@angular/core';
import { IonicPageModule } from 'ionic-angular';
import { S27ControlPage } from './badminton-control';
import { ComponentsModule } from '../../components/components.module';

@NgModule({
  declarations: [
    S27ControlPage,
  ],
  imports: [
    IonicPageModule.forChild(S27ControlPage),ComponentsModule
  ],
})
export class BadmintonControlPageModule {}
