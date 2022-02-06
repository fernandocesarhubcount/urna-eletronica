import { THIS_EXPR } from '@angular/compiler/src/output/output_ast';
import { Component, Input, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Candidate } from '../_models/candidate';
import { UrnaService } from './urna.service';
import { MsgStatus } from '../_models/MsgStatus';

@Component({
  selector: 'app-urna',
  templateUrl: './urna.component.html',
  styleUrls: ['./urna.component.css']
})

export class UrnaComponent implements OnInit {
  // Gerenciamento de Mensagem / Erro
  public msgAtual: number = MsgStatus.Empty;

  public decDigit : number;
  public unitDigit : number;
  public status: number = InputStatus.Empty;

  public nomeCandidato : string;
  public nomeVice : string;

  public isTelaVoto : boolean = true;

  constructor(private service : UrnaService, private router: Router) {
    
  }

  // Recebe lista de candidatos
  ngOnInit() {
    this.service.getCandidatos();
  }

  // Método auxiliar para iterar com índice em ngFor
  intervalo(number: number){
    return new Array(number);
  }

  // Método auxiliar para tornar o enum de status de mensagem acessível no template HTML.
  public get MsgStatus() {
    return MsgStatus;
  }

  // Método facilitador para definir nomes de candidato e vice simultaneamente (eles são sempre definidos em conjunto)
  private setNomes(nomeCandidato: string, nomeVice: string) {
    this.nomeCandidato = nomeCandidato;
    this.nomeVice = nomeVice;
  }

  // Quando o input estiver cheio, definir corretamente os campos de nome e vice.
  private onInputFull() {
    let legenda = this.decDigit*10 + this.unitDigit;
    if (legenda == 0) {
      this.setNomes("VOTO BRANCO OU NULO", "");
      return;
    }

    let candidato = this.service.getCandidato(legenda);
    if (!candidato) {
      this.setNomes("CANDIDATO INEXISTENTE - BRANCO OU NULO", "");
      return;
    }

    this.setNomes(candidato.nome, candidato.nomeVice);
  }

  // Métodos de Botões
  onNumberClick(digit: number) { // Números
    // Se tiver espaço para um novo dígito, então colocar.
    if (this.status == InputStatus.Empty) {
      this.decDigit = digit;
      this.status = InputStatus.SingleDigit;
    } else if(this.status == InputStatus.SingleDigit) {
      this.unitDigit = digit;
      this.status = InputStatus.Full
      this.onInputFull(); // Chamar função que receberá informações de candidatos quando input tiver cheio
    }

    // Senão, ignorar clique.
  }

  onBranco() {
    this.decDigit = 0;
    this.unitDigit = 0;
    this.status = InputStatus.Full;
    this.onInputFull();
  }

  onCorrige() {
    this.decDigit = null;
    this.unitDigit = null;
    this.status = InputStatus.Empty;
    this.setNomes("", "");
  }

  async onConfirma() {
    // Ignorar confirmação se for inválida.
    if (this.status != InputStatus.Full) {
      this.msgAtual = MsgStatus.CandidateNotFilled;
      return;
    }

    let legenda = this.decDigit*10 + this.unitDigit;

    let response = await this.service.postVoto(legenda);
    if (response.ok) {
      this.isTelaVoto = false; // Exibe a tela de "FIM"
      this.msgAtual = MsgStatus.VoteSuccess; // Mostra mensagem de sucesso
    } else {
      this.msgAtual = MsgStatus.GenericVoteError;
    }
      
  }

  // Poderia setar essa variável diretamente no html, mas acredito que não seja uma boa prática.
  showTelaVoto() {
    this.isTelaVoto = true;
    this.hideMensagem(); // Fecha a mensagem de voto sucesso
  }

  // Esconde a mensagem sendo exibida atualmente
  hideMensagem() {
    this.msgAtual = MsgStatus.Empty;
  }
}

enum InputStatus {
  Empty,
  SingleDigit,
  Full
}
