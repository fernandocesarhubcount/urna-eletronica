import { RouterModule } from '@angular/router';
import { SharedModule } from './../../shared/shared.module';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CabecalhoComponent } from './cabecalho.component';



@NgModule({
  declarations: [
    CabecalhoComponent
  ],
  imports: [
    CommonModule,
    SharedModule,
    RouterModule
  ],
  exports: [
    CabecalhoComponent
  ]
})
export class CabecalhoModule { }
