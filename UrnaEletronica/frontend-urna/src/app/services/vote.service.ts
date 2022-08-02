import { HttpClient, HttpHeaders, HttpResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Candidate } from '../candidate';
import { Vote } from '../vote';

var httpOptions = {headers: new HttpHeaders({"Content-Type": "application/json"})};
@Injectable({
  providedIn: 'root'
})

export class VoteService {
  private candidates : Candidate[];
  private candidatesMap = new Map<number, Candidate>();
  url = 'http://localhost:5000/votes';
  urlPost = 'http://localhost:5000/vote';

  constructor(private http: HttpClient) {}

  async getCandidatos() {
    this.candidates = await this.http.get<Candidate[]>(this.url)
      .toPromise()
      .catch(error => error);


    this.candidates.forEach( (candidato) => {
      this.candidatesMap.set(candidato.legenda, candidato);
    });
  }

  getCandidato(legenda: number) {
    let candidato = this.candidatesMap.get(legenda);
    if (!candidato)
      return candidato;

    return candidato;
  }

  async postVoto(legenda: string) : Promise<HttpResponse<Object>> {
    let voto: Vote;

    let candidato = this.getCandidato(Number(legenda));
    if (candidato) {
      voto = new Vote(candidato.legenda);
    } else {
      voto = new Vote(1);
    }

    return await this.http.post(this.urlPost , voto, httpOptions)
      .toPromise()
      .catch(error => error);
  }

}