import { NgModule } from '@angular/core';
import { IonicPageModule } from 'ionic-angular';
import { SquashListPage } from './squash-list';
import {ComponentsModule} from '../../components/components.module'

@NgModule({
  declarations: [
    SquashListPage,
  ],
  imports: [
    IonicPageModule.forChild(SquashListPage),
    ComponentsModule
  ],
  exports:[
    SquashListPage
  ]
})
export class SquashListPageModule {}
