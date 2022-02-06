import { HttpClient, HttpResponse } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Candidate } from '../_models/candidate';
import { Vote } from '../_models/Vote';

@Injectable({
  providedIn: 'root'
})
export class UrnaService {
  private candidates : Candidate[];
  private candidatesMap = new Map<number, Candidate>();

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) {
    
  }

  // GET: Lista de candidatos e votos
  async getCandidatos() {
    this.candidates = await this.http.get<Candidate[]>(this.baseUrl + 'api/votes')
      .toPromise()
      .catch(error => error);

    // Converte candidatos numa HashTable / HashMap, indexados por legenda
    this.candidates.forEach( (candidato) => {
      this.candidatesMap.set(candidato.legenda, candidato);
    });
  }

  // Acessa o candidato por legenda, direto na hash table.
  getCandidato(legenda: number) {
    let candidato = this.candidatesMap.get(legenda);
    if (!candidato)
      return null;

    return candidato;
  }

  // POST: Novo voto a um candidato ou branco
  async postVoto(legenda: number) : Promise<HttpResponse<Object>> {
    let voto: Vote;

    // Candidato válido ou voto em branco
    let candidato = this.getCandidato(legenda);
    if (candidato) {
      voto = new Vote(candidato.candidateId);
    } else {
      voto = new Vote(0);
    }

    // Enviar voto à API .map(response => response.json())
    return await this.http.post(this.baseUrl + 'api/vote', voto, {observe: 'response'})
      .toPromise()
      .catch(error => error);
  }

}
