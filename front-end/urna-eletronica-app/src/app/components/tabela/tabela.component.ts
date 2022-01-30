import { MensagemService } from './../../service/mensagem/mensagem.service';
import { HttpResponse } from './../../interfaces/http-response';
import { Candidato } from './../../interfaces/candidato';
import { Component, Input, OnInit, ViewChild } from '@angular/core';
import { MatTable } from '@angular/material/table';
import { CandidatoService } from 'src/app/service/candidato/candidato.service';


@Component({
  selector: 'app-tabela',
  templateUrl: './tabela.component.html',
  styleUrls: ['./tabela.component.css']
})
export class TabelaComponent {

  displayedColumns: string[] = ['legenda', 'nomeCompleto', 'nomeVice', 'idCandidato'];
  dataSource: Candidato[] = [];

  @Input() set dados(dados: Candidato[]) {
    console.log('Dados que chegaram na tabela: Input ', this.dados);
    this.dataSource = dados;
  }

  get dados(): Candidato[] {
    return this.dataSource;
  }

  @ViewChild(MatTable)
  table!: MatTable<Candidato>;

  constructor(
    private _candidatoService: CandidatoService,
    private _mensagemService: MensagemService) {
    this.dataSource = this.dados;
  }

  apagarCandidato(candidato: Candidato): void {
    const confirmacao = confirm('Deseja confirmar a exclusão do Candidato');
    if (confirmacao) {
      console.log(candidato);
      const id = candidato.idCandidato as number;
      this._candidatoService.apagarCandidato(id).subscribe((rersultado: HttpResponse) => {
        if (rersultado.sucesso) {
          this._mensagemService.mostraMensagem('Candidato apagado com sucesso');
          this.removerCandidatoTabela(candidato);
        }
      }, (error) => {
        console.log(error);
        this._mensagemService.mostraMensagem('Não foi possivel apagar o candidato');
      });
    }
  }

  removerCandidatoTabela(candidato: Candidato): void {
    this.dataSource.splice(this.dataSource.indexOf(candidato), 1);
    this.table.renderRows();
  }
}
