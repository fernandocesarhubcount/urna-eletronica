import { Component, OnInit, ViewChild } from '@angular/core';
import { NgbModal, NgbModalConfig } from '@ng-bootstrap/ng-bootstrap';
import { CandidateService } from '../candidate/candidate.service';
import { Candidate } from '../Models/Candidate';
import { CandidateVotes } from '../Models/CandidateVotes';
import { VoteService } from '../vote/vote.service';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent implements OnInit {

  public candidatesVotes : CandidateVotes[];
  public isDeletedSucesso : boolean;
  public modalHeaderMessage : string;
  public modalBodyMessage : string;
  @ViewChild('confirmationModal') confirmationModal : any;

  constructor(private voteService : VoteService,
              private candidateService : CandidateService,
              private config: NgbModalConfig, 
              private modalService: NgbModal) { }

  ngOnInit() {
    this.getCandidatesWithVotes();
  }

  getCandidatesWithVotes() {
    this.voteService.get().subscribe({
      next: candidatesVotes => {
        this.candidatesVotes = candidatesVotes;
      },
      error: err => {
        console.error(err);
      }
    });
  }

  excluirCandidato(candidate : Candidate) {
    this.candidateService.delete(candidate.legenda).subscribe({
      next: () => {
        this.isDeletedSucesso = true;
        this.openModal();
        this.getCandidatesWithVotes();
      },
      error: () => {
        this.isDeletedSucesso = false;
        this.openModal();
        this.getCandidatesWithVotes();
      }
    })
  }

  openModal() {
    if (this.isDeletedSucesso) {
      this.modalHeaderMessage = "Sucesso";
      this.modalBodyMessage = "Candidato excluído com sucesso."
    }
    else {
      this.modalHeaderMessage = "Erro";
      this.modalBodyMessage = "Erro na exclusão do candidato."
    }

    this.modalService.open(this.confirmationModal);
  }

}
