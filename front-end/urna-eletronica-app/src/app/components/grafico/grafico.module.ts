import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { GraficoComponent } from './grafico.component';
import { HighchartsChartModule } from 'highcharts-angular';



@NgModule({
  declarations: [
    GraficoComponent
  ],
  imports: [
    CommonModule,
    HighchartsChartModule
  ],
  exports: [
    GraficoComponent
  ]

})
export class GraficoModule { }
