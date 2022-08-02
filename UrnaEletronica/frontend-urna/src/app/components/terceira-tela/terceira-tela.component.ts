import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { map } from "rxjs/operators";

import { Candidate } from '../../candidate';
import { CandidateService } from '../../services/candidate.service';

@Component({
  selector: 'app-terceira-tela',
  templateUrl: './terceira-tela.component.html',
  styleUrls: ['./terceira-tela.component.css']
})
export class TerceiraTelaComponent implements OnInit {

  allCandidates: Observable<Candidate[]>;  

  constructor(private candidateService: CandidateService) { 
  }

  ngOnInit(): void {
    this.loadAllCandidates();
  }

  loadAllCandidates() {  
    this.allCandidates = this.candidateService.getAllCandidates().pipe(map((data) => {
      data.sort((a, b) => {
          return a.quantidadeVotos < b.quantidadeVotos ? 1 : -1;
       });
      return data;
      })); 
  } 
}
