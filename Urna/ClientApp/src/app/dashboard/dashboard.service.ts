import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Candidate } from '../_models/candidate';

@Injectable({
  providedIn: 'root'
})
export class DashboardService {

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) {
  }

  // GET: Lista de candidatos e votos
  // Diferente das duas outras chamadas em outros componentes, essa inclui brancos e nulos.
  async getCandidatos() {
    return await this.http.get<Candidate[]>(this.baseUrl + 'api/votes')
    .toPromise()
    .catch(error => error);
  }
}
