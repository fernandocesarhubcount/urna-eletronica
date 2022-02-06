import { Component, OnInit } from '@angular/core';
import { Candidate } from '../_models/candidate';
import { DashboardService } from './dashboard.service';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent implements OnInit {
  public candidates: Candidate[];
  public brancoCandidate: Candidate = new Candidate();
  public totalVotos: number = 0;

  constructor(private service : DashboardService) { }

  // Recebe lista de todos os candidatos, atribui os atributos do candidato branco ao objeto "brancoCandidate", e calcula o total de votos (para efetuar cálculo de %)
  async ngOnInit() {
    this.candidates = await this.service.getCandidatos();
    Object.assign(this.brancoCandidate, this.candidates.find(c => c.legenda == 0));
    this.candidates.forEach(candidate => {
      this.totalVotos += candidate.qtdVotos;
    });
  }

  // Converte / formata em porcentagem
  toCandidatePercentage(candidate: Candidate) {
    if (this.totalVotos == 0) // Evita divisão por 0
      return "0.00";
    return (candidate.qtdVotos*100/this.totalVotos).toFixed(2);
  }

}
