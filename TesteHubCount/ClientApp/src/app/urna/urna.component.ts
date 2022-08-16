import { Observable } from 'rxjs';
import { TotalVotes } from './../../models/TotalVotes';
import { Component, OnInit, Input, OnChanges, SimpleChanges } from '@angular/core';
import { Vote } from 'src/models/Vote';
import { AlertasService } from '../services/alertas.service';
import { VoteService } from '../services/votes.service';
import { HttpClient } from '@angular/common/http';
import { CandidateService } from '../services/candidates.service';

@Component({
  selector: 'app-urna',
  templateUrl: './urna.component.html',
  styleUrls: ['./urna.component.css']
})
export class UrnaComponent implements OnInit, OnChanges {
  public corrigeInput: any = '';
  voteCandidatoId: string = '';
  votes!: TotalVotes;
  value: any;
  candidato: any;
  candidatos!: any[];

  constructor(
    public httpclient: HttpClient,
    private voteService: VoteService,
    private candidateService: CandidateService,
    private alert: AlertasService
  ) { }

  ngOnChanges(changes: SimpleChanges): void {
    alert(changes)
    console.log(changes)
  }

  ngOnInit(): void {
    this.getAllCandidates();
  }

  addVote(parametro: string) {
    const candidatoId = Number(parametro);
    let vote = new Vote(candidatoId);
    let candVotado = this.getByLegendaCandidate(parametro);
    vote.CandidatoId = candidatoId;
    this.voteService.postVote(vote).subscribe((data: any) => {
      vote = data;
      this.alert.showAlertSuccess('Voto realizado com sucesso!')
    }, error => {
      console.log(error);
      this.alert.showAlertDanger('Ocorreu um erro no voto');

    });
  }

  addBrancoVote() {
    let vote = new Vote(-2);
    this.voteService.postVote(vote).subscribe((data: any) => {
      vote = data;

      this.alert.showAlertSuccess('Voto em branco realizado com sucesso!')
    }, error => {
      console.log(error);
      this.alert.showAlertDanger('Ocorreu um erro no voto');



    });
  }
  getAllCandidates() {
    this.candidateService.getAllCandidates().subscribe((data: any) => {
      this.candidatos = data;
    });
  }

  getByLegendaCandidate(parametro: string) {
    const legenda = Number(parametro)
    this.candidateService.getByLegendaCandidate(legenda).subscribe((data: any) => {
      this.candidato = data;
    });
  }


  click(x: string) {


  }







}
