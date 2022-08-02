import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { Validators, FormGroup, FormBuilder } from '@angular/forms';

import { Candidate } from '../../candidate';
import { CandidateService } from '../../services/candidate.service';

@Component({
  selector: 'app-segunda-tela',
  templateUrl: './segunda-tela.component.html',
  styleUrls: ['./segunda-tela.component.css']
})
export class SegundaTelaComponent implements OnInit {

  public candidate: Candidate = new Candidate();
  allCandidates: Observable<Candidate[]>;
  registerForm: FormGroup;
  submitted = false;

  constructor(private candidateService: CandidateService, private fb: FormBuilder) { }

  ngOnInit(): void {
    this.loadAllCandidates();

    this.registerForm = this.fb.group({
      nomecanditato: ['', Validators.required],
      nomevice: ['', Validators.required],
      legenda: ['', [Validators.required, Validators.pattern('^[0-9]+$')]]
    });
  }

  loadAllCandidates() {  
    this.allCandidates = this.candidateService.getAllCandidates().pipe(map((data) => {
      data.sort((a, b) => {
          return a.quantidadeVotos < b.quantidadeVotos ? 1 : -1;
       });
      return data;
      })); 
  } 

  get registerFormControl() {
    return this.registerForm.controls;
  }

  onSubmit(candidate: Candidate) {
    this.submitted = true;

    if(candidate.legenda > 99){
      this.registerForm.reset();
      return window.alert('A legenda não pode ser maior que 99');
    }

    if (this.registerForm.valid) {
      const candidate = this.registerForm.value; 
      this.candidateService.createCandidate(candidate).subscribe(() => {
        window.alert('Registro de candidato salvo com sucesso.');
        this.loadAllCandidates();  
        },
        error => {
          window.alert(error.error.message)
        }  
      ); 
      this.registerForm.reset();
    }
  }

  deleteCandidato(candidateId: string) {  
    if (confirm("Deseja realmente deletar este candidato?")) {   
      this.candidateService.deleteCandidateById(candidateId).subscribe(() => {   
        window.alert('Registro deletado com sucesso.');
        this.loadAllCandidates();  
      });  
    }  
  }

}
