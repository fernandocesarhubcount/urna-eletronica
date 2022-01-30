import { MensagemService } from './../../service/mensagem/mensagem.service';
import { FormVoto } from './../../interfaces/form-voto';
import { Voto } from './../../interfaces/voto';
import { Component, OnInit } from '@angular/core';

import { Candidato } from './../../interfaces/candidato';
import { HttpResponse } from './../../interfaces/http-response';
import { MatSnackBar } from '@angular/material/snack-bar';
import { CandidatoService } from '../../service/candidato/candidato.service';
import { VotoService } from '../../service/voto/voto.service';

@Component({
  selector: 'app-urna',
  templateUrl: './urna.component.html',
  styleUrls: ['./urna.component.css']
})
export class UrnaComponent implements OnInit {

  digito1?: string;
  digito2?: string;
  candidato !: Candidato;
  voto !: FormVoto;
  Fim = false;

  constructor(
    private _candidatoService: CandidatoService,
    private _mensagemService: MensagemService,
    private _votoService: VotoService) { }

  ngOnInit(): void {
  }

  addCodigo(digito: string): void {
    if (!this.digito1)
      this.digito1 = digito;
    else if (!this.digito2) {
      this.digito2 = digito;
      let codigo = this.converterCodigo(this.digito1, this.digito2);
      this.buscarCandidato(codigo);
    }
    else
      this._mensagemService.mostraMensagem("O código do usuário já foi inserido");
  }

  converterCodigo(digito1: string, digito2: string): number {
    return Number.parseInt(digito1 + digito2);
  }

  buscarCandidato(codigo: number) {
    this._candidatoService.obterCandidato(codigo).subscribe((result: HttpResponse) => {
      if (!result.dados) {
        this._mensagemService.mostraMensagem("Não foi possivel encontrar o candidato digitado");
        let votoNulo = confirm("Não foi possivel encontrar o cadastro do candidato.\nDeseja anular o voto?");
        if (votoNulo) {
          this.criarCandidatoNulo();
          this.criarVotoNulo();
        } else {
          this.corrigir();
        }
        return;
      }
      this.candidato = result.dados;
    }, (error: HttpResponse) => {
      this._mensagemService.mostraMensagem("Não foi possivel encontrar o candidato digitado");
      console.log(error.dados);
    });
  }

  corrigir() {
    this.digito1 = undefined;
    this.digito2 = undefined;
    this.candidato = {
      idCandidato: undefined,
      nomeCompleto: "",
      legenda: undefined,
      nomeVice: "",
      dataDeRegistro: undefined
    };
  }

  confirmarVoto() {
    if (!this.candidato) {
      this._mensagemService.mostraMensagem("O candidato não é valido para confirmação do voto");
    } else {
      if (!this.voto?.votoEmBranco) {
        this.voto = {
          idCandidato: this.candidato.idCandidato,
          votoEmBranco: false,
          dataDoVoto: new Date()
        }
      }
      this.criarVotoNormal();
      this._votoService.votar(this.voto).subscribe((response: HttpResponse) => {
        this._mensagemService.mostraMensagem(response.mensagem);
        this.Fim = true;
      }, (error: HttpResponse) => {
        this._mensagemService.mostraMensagem("Não foi possível gravar o voto");
        console.log(error);
      });
    }
  }

  InciarVotacao(): void {
    this.Fim = false;
    this.corrigir();
  }

  criarVotoNormal(): void {
    this.voto = {
      idCandidato: this.candidato.idCandidato,
      votoEmBranco: false,
      dataDoVoto: new Date(),
    }
  }

  criarVotoEmBraco(): void {
    this.candidato = {
      idCandidato: undefined,
      legenda: undefined,
      nomeCompleto: "EM BRANCO",
      nomeVice: "EM BRANCO",
      dataDeRegistro: new Date()
    };
    this.voto = {
      idCandidato: undefined,
      votoEmBranco: true,
      dataDoVoto: new Date(),
    }
  }

  criarVotoNulo(): void {
    this.criarCandidatoNulo();
    this.voto = {
      idCandidato: this.candidato.idCandidato,
      votoEmBranco: false,
      dataDoVoto: new Date(),
    }
  }

  criarCandidatoNulo(): void {
    this.candidato = {
      idCandidato: undefined,
      nomeCompleto: "NULO",
      legenda: undefined,
      nomeVice: "NULO",
      dataDeRegistro: undefined
    };
  }
}

