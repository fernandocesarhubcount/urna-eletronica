import { Component, OnInit, ViewChild } from '@angular/core';
import { NgbModal, NgbModalConfig } from '@ng-bootstrap/ng-bootstrap';
import { CandidateService } from '../candidate/candidate.service';
import { Candidate } from '../Models/Candidate';
import { Vote } from '../Models/Vote';
import { VoteService } from './vote.service';

@Component({
  selector: 'app-vote',
  templateUrl: './vote.component.html',
  styleUrls: ['./vote.component.css']
})
export class VoteComponent implements OnInit {

  public candidateLegendaInput = '';
  public candidateFetched : Candidate | null;
  public isPostSucesso : boolean;
  public modalHeaderMessage : string;
  public modalBodyMessage : string;
  @ViewChild('confirmationModal') confirmationModal : any;

  constructor(private voteService : VoteService,
              private candidateService : CandidateService,
              private config: NgbModalConfig, 
              private modalService: NgbModal) { 
    config.backdrop = 'static';
    config.keyboard = false;
  }

  ngOnInit() {
  }

  appendValue(value : number) {
    if (this.candidateLegendaInput.length < 2) {
      this.candidateLegendaInput = this.candidateLegendaInput.concat(value.toString());
      this.getCandidateByLegenda();
    }
  }

  submitNullVote() {
    var vote = new Vote(null, new Date());

    this.voteService.post(vote).subscribe({
      next: () => {
          this.isPostSucesso = true;
          this.openModal();
      },
      error: () => {
        this.isPostSucesso = false;
        this.openModal();
      }
    })
  }

  submitVote(){
    var vote = new Vote(this.candidateFetched.legenda, new Date());

    this.voteService.post(vote).subscribe({
      next: () => {
          this.isPostSucesso = true;
          this.openModal();
      },
      error: () => {
        this.isPostSucesso = false;
        this.openModal();
      }
    })
    
  }

  getCandidateByLegenda() {
    if (this.candidateLegendaInput.length < 2) return;
    var candidateLegenda = parseInt(this.candidateLegendaInput);
    this.candidateService.getCandidateByLegenda(candidateLegenda).subscribe({
      next: (candidate : Candidate) => {
        this.candidateFetched = candidate;
      },
      error: (error : any) => {
        this.candidateFetched = null;
      }
    })
  }


  clearInput() {
    this.candidateLegendaInput = '';
    this.candidateFetched = null;
  }

  openModal() {
    if (this.isPostSucesso) {
      this.modalHeaderMessage = "Sucesso";
      this.modalBodyMessage = "Voto computado com sucesso."
    }
    else {
      this.modalHeaderMessage = "Erro";
      this.modalBodyMessage = "Erro na computação do voto. Tente novamente."
    }

    this.modalService.open(this.confirmationModal);
  }

}
