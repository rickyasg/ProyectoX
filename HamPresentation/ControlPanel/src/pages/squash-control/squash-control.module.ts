import { NgModule } from '@angular/core';
import { IonicPageModule } from 'ionic-angular';
import { S49ControlPage } from './squash-control';
import { ComponentsModule } from '../../components/components.module';


@NgModule({
  declarations: [
    S49ControlPage,
  ],
  imports: [
    IonicPageModule.forChild(S49ControlPage),
    ComponentsModule
  ],
  exports:[
    S49ControlPage
  ]
})
export class SquashControlPageModule { }
