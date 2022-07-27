import { Component, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { NgbModal, NgbModalConfig } from '@ng-bootstrap/ng-bootstrap';
import { Candidate } from '../Models/Candidate';
import { CandidateService } from './candidate.service';

@Component({
  selector: 'app-candidate',
  templateUrl: './candidate.component.html',
  styleUrls: ['./candidate.component.css']
})
export class CandidateComponent implements OnInit {

  public formCandidato : FormGroup;
  public newCandidate : Candidate;
  public isEnvioFormSucesso : boolean;
  public modalHeaderMessage : string;
  public modalBodyMessage : string;
  @ViewChild('confirmationModal') confirmationModal : any;

  constructor(private fb : FormBuilder,
              private candidateService : CandidateService,
              private config: NgbModalConfig, 
              private modalService: NgbModal) { 
    config.backdrop = 'static';
    config.keyboard = false;
  }

  ngOnInit() {
    this.createForm();
  }

  createForm() {
    this.formCandidato = this.fb.group({
      legenda: ['', Validators.compose([Validators.required, Validators.pattern("^[1-9][0-9]$")])],
      nome: ['', Validators.compose([Validators.required, Validators.pattern("^[a-zA-Z áãâéêíóôõú]{6,20}$")])],
      nomeVice: ['', Validators.compose([Validators.required, Validators.pattern("^[a-zA-Z áãâéêíóôõú]{6,20}$")])]
    })
  }

  get legenda() { return this.formCandidato.get('legenda'); }
  get nome() { return this.formCandidato.get('nome'); }
  get nomeVice() { return this.formCandidato.get('nomeVice'); }

  submitForm() {
    this.newCandidate = this.formCandidato.value;
    this.newCandidate.dataRegistro = new Date();

    this.candidateService.post(this.newCandidate).subscribe({
      next: candidate => {
        this.isEnvioFormSucesso = true;
        this.openModal();
      },
      error: err => {
        this.isEnvioFormSucesso = false;
        this.openModal();
      }
    });
  }

  openModal() {
    if (this.isEnvioFormSucesso) {
      this.modalHeaderMessage = "Sucesso";
      this.modalBodyMessage = "Candidato cadastrado com sucesso."
    }
    else {
      this.modalHeaderMessage = "Erro";
      this.modalBodyMessage = "Número de candidato já cadastrado."
    }

    this.modalService.open(this.confirmationModal);
  }

}
