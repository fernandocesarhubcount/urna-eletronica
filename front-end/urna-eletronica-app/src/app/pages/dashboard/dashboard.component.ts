import { HttpResponse } from './../../interfaces/http-response';
import { VotosResultado } from './../../interfaces/votos-resultado';
import { VotoService } from '../../service/voto/voto.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent implements OnInit {

  dados: VotosResultado[] = [];
  constructor(private _votoService: VotoService) { }

  ngOnInit(): void {
  }

}
