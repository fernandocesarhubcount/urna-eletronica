import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Candidate } from "src/models/Candidate";

@Injectable(
  { providedIn: 'root' }
)

export class CandidateService {
  private readonly url = 'https://localhost:5001/candidate'

  constructor(private http: HttpClient) { }

  getAllCandidates() {
    return this.http.get(this.url)
  }

  getByLegendaCandidate(id: number) {
    return this.http.get(this.url + `/${id}`)
  }

  postCandidate(candidate: Candidate) {
    return this.http.post(this.url, candidate)
  }

  putCandidate(id: number, candidate: Candidate) {
    return this.http.put(this.url + `/${id}`, candidate)
  }

  deleteCandidate(id: number) {
    return this.http.delete(this.url + `/${id}`)
  }
}
