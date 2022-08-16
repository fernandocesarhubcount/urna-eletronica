import { HttpClient } from '@angular/common/http';
import { Candidate } from './../../models/Candidate';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { CandidateService } from '../services/candidates.service';
import { AlertasService } from '../services/alertas.service';

@Component({
  selector: 'app-cadastro',
  templateUrl: './cadastro.component.html',
  styleUrls: ['./cadastro.component.css']
})

export class CadastroComponent implements OnInit {
  public form!: FormGroup;
  nome!: string;
  vice!: string;
  legenda!: number;
  data: Date = new Date();


  candidato: Candidate = new Candidate(this.nome, this.vice, this.data, this.legenda);

  constructor(
    public httpclient: HttpClient,
    private fb: FormBuilder,
    private candidateService: CandidateService,
    private alert: AlertasService
  ) {
    this.form = this.fb.group({
      nome: ['', Validators.compose([
        Validators.minLength(2),
        Validators.maxLength(100),
        Validators.required
      ])],
      vice: ['', Validators.compose([
        Validators.minLength(2),
        Validators.maxLength(100),
        Validators.required
      ])],
      legenda: ['', Validators.compose([
        Validators.min(1),
        Validators.max(99),
        Validators.required
      ])]


    });
  }

  ngOnInit(): void {

  }


  addCandidato() {
    this.candidateService.postCandidate(this.candidato).subscribe((data: any) => {
      this.candidato = data;
      this.alert.showAlertSuccess('Candidato cadastrado com sucesso!')
      this.candidateService.getAllCandidates();
    },
      error => {
        console.log(error);
        this.alert.showAlertDanger('Ocorreu um erro no cadastro do candidato, lembre que todos são obrigatórios');


      });

  }
}
