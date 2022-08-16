import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Candidate } from 'src/models/Candidate';
import { TotalVotes } from 'src/models/TotalVotes';
import { Vote } from 'src/models/Vote';
import { AlertasService } from '../services/alertas.service';
import { CandidateService } from '../services/candidates.service';
import { VoteService } from '../services/votes.service';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent implements OnInit {

  listVotes: any[] = [];

  votestotal: TotalVotes = new TotalVotes();

  constructor(
    public httpclient: HttpClient,
    private voteService: VoteService,
    private candidateService: CandidateService,
    private alert: AlertasService) { }

  ngOnInit(): void {
    this.getAllVotes();

  }


  getAllVotes() {
    this.voteService.getAllVotes().subscribe((data: any) => {
      this.listVotes = data;
      this.listVotes = this.listVotes.splice(0);
      console.log(this.listVotes);
    });

  }
}
