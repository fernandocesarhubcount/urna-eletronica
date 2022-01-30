import { SharedModule } from './../../shared/shared.module';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TabelaComponent } from './tabela.component';



@NgModule({
  declarations: [
    TabelaComponent
  ],
  imports: [
    CommonModule,
    SharedModule
  ],
  exports: [TabelaComponent]
})
export class TabelaModule { }
