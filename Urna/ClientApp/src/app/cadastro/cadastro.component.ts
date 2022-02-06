import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { Candidate } from '../_models/candidate';
import { CadastroService, isLegenda } from './cadastro.service';
import { MsgStatus } from '../_models/MsgStatus';

@Component({
  selector: 'app-cadastro',
  templateUrl: './cadastro.component.html',
  styleUrls: ['./cadastro.component.css']
})
export class CadastroComponent implements OnInit {
  // Gerenciamento de Mensagem / Erro
  public msgAtual: number = MsgStatus.Empty;

  public candidates: Candidate[];
  public candidateForm: FormGroup;

  constructor(private service : CadastroService, private fb: FormBuilder, private router: Router) { 
    this.candidateForm = this.fb.group({
      nome: ['', [Validators.required, Validators.minLength(4), Validators.maxLength(40)]],
      nomeVice: ['', [Validators.required, Validators.minLength(4), Validators.maxLength(40)]],
      legenda: ['', [Validators.required, isLegenda()] ],
    });
  }

  // Recebe lista de candidatos assim que o componente é iniciado
  async ngOnInit() {
    this.candidates = await this.service.getCandidatos();
  }

  // Método auxiliar para tornar o enum de status de mensagem acessível no template HTML.
  public get MsgStatus() {
    return MsgStatus;
  }

  // Chama a função que remove um candidato específico por ID
  async onDeletar(candidateId: number) {
    let response = await this.service.deleteCandidato(candidateId);
    if (response.ok) {
      // Remove do array devido ao ngModel databinding
      let key = this.candidates.findIndex(c => c.candidateId == candidateId);
      this.candidates.splice(key, 1);
      this.msgAtual = MsgStatus.CandidateDeleteSuccess;
    } else {
      this.msgAtual = MsgStatus.GenericCandidateDeleteError;
    }
  }

  // Envia o formulário de novo candidato
  async onCandidatoSubmit() {
    let candidato = new Candidate(this.candidateForm.value);
    let response = await this.service.postCandidato(candidato);
    if (response.ok) { // Candidato criado com sucesso
      this.router.navigate(['dashboard']);
      return;
    }

    // Legenda já utilizada
    if (response.status == 400) {
      this.msgAtual = MsgStatus.LegendaCandidateAddError;
      return;
    }

    this.msgAtual = MsgStatus.GenericCandidateAddError;
  }

  // Esconde a mensagem sendo exibida atualmente
  hideMensagem() {
    this.msgAtual = MsgStatus.Empty;
  }
}
