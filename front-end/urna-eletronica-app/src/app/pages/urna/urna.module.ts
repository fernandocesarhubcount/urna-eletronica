import { SharedModule } from './../../shared/shared.module';
import { UrnaComponent } from './urna.component';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { UrnaRoutingModule } from './urna-routing.module';



@NgModule({
  declarations: [
    UrnaComponent
  ],
  imports: [
    CommonModule,
    SharedModule,
    UrnaRoutingModule
  ],
  exports:[
    UrnaComponent
  ]
})
export class UrnaModule { }
