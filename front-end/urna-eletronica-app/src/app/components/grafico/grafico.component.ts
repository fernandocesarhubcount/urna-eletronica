import { MensagemService } from './../../service/mensagem/mensagem.service';
import { Options } from './../../../../node_modules/highcharts/highcharts.d';
import * as am4charts from '@amcharts/amcharts4/charts';
// amCharts imports
import * as am4core from '@amcharts/amcharts4/core';
import { isPlatformBrowser } from '@angular/common';
import { Component, Inject, NgZone, OnInit, PLATFORM_ID } from '@angular/core';
import { HttpResponse } from './../../interfaces/http-response';
import { VotosResultado } from './../../interfaces/votos-resultado';
import { VotoService } from '../../service/voto/voto.service';
import * as Highcharts from 'highcharts';


@Component({
  selector: 'app-grafico',
  templateUrl: './grafico.component.html',
  styleUrls: ['./grafico.component.css']
})
export class GraficoComponent implements OnInit {

  dadosGrafico: VotosResultado[] = [];
  highcharts = Highcharts;
  listaNomeCandidato: string[] = [];
  listaVotos: number[] = [];


  chartOptions: Highcharts.Options = {
    title: {
      text: "Resultado da votação"
    },
    xAxis: {
      title: {
        text: 'Candidatos'
      },
      categories: []
    },
    yAxis: {
      title: {
        text: "Quantidade de votos"
      }
    },
    series: [{
      data: [],
      type: 'bar'
    }]
  }



  private chart !: am4charts.XYChart;
  constructor(
    private _mensagemService: MensagemService,
    private _votoService: VotoService,

    ) { }

  ngOnInit(): void {
    this.buscarVotos();


  }

  buscarVotos() {
    this._votoService.buscarVotos().subscribe((resultado: HttpResponse) => {
      const dados = resultado.dados as VotosResultado[];
      if(resultado.sucesso && dados.length >= 1 ) {
        const dados = resultado.dados as VotosResultado[];
        this.dadosGrafico = [...dados];
        this.separarNomeCandidatoEQtdVotos();
        this.chartOptions = this.criarOptionsGrafico();
      } else if(resultado.dados == null || dados.length === 0 ) {
        this._mensagemService.mostraMensagem('Não existem votos a serem mostrados');
      } else {
        this._mensagemService.mostraMensagem('Não foi possível retornar os votos registrados');
      }
    }, (error)=> {
      this._mensagemService.mostraMensagem('Não foi possível retornar os votos registrados');
      console.error(error);
    })
  }

  separarNomeCandidatoEQtdVotos(): void {
    this.dadosGrafico.map(e=> {
      this.listaNomeCandidato.push(`${e.nomeCandidato} (${e.legenda})`);
      this.listaVotos.push(e.qtdVotos);
    });
  }

  criarOptionsGrafico(): Options {
    console.log("Lista de nomes", this.listaNomeCandidato);
    console.log("Lista de votos", this.listaVotos);
    return {
      chart: {
        type: 'column',
        borderColor: 'black',
        borderWidth: 2,
        width: 1000,
        height: 500
      },
      title: {
        text: "Resultado da votação"
      },
      xAxis: {
        title: {
          text: 'Candidatos'
        },
        categories: this.listaNomeCandidato
      },
      yAxis: {
        title: {
          text: "Quantidade de votos"
        }
      },
      series: [{
        data: this.listaVotos,
        type: 'bar',
        borderColor: 'black',
        borderWidth: 2,
        dataLabels: {
          enabled: true,
          rotation: -90,
          color: '#FFFFFF',
          align: 'right',
          format: '{point.y:.f}', // formatação da qtd de votos para int
          y: 10, // 10 pixels down from the top
          style: {
            fontSize: '13px',
            fontFamily: 'Verdana, sans-serif'
          }
        }

      }],
    }
  }



}
