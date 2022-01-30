import { CabecalhoModule } from './../components/cabecalho/cabecalho.module';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MaterialModule } from '../material/material.module';
import { HttpClientModule } from '@angular/common/http';
import { ReactiveFormsModule } from '@angular/forms';



@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    HttpClientModule,
    MaterialModule,
    ReactiveFormsModule
  ],
  exports: [
    HttpClientModule,
    MaterialModule,
    ReactiveFormsModule
  ]
})
export class SharedModule { }
