import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { environment } from "src/environments/environment"
import { Candidate } from "../Models/Candidate";

@Injectable()
export class CandidateService {

route = `${environment.apiRoute}/candidate`;

constructor(private http : HttpClient) {
    
}

post(candidate : Candidate) : Observable<Candidate> {
    return this.http.post<Candidate>(this.route, candidate);
}

delete(candidateId : number) {
    return this.http.delete<Candidate>(`${this.route}/${candidateId}`);
}

getCandidateByLegenda(legendaCandidate: number) : Observable<Candidate>{
    return this.http.get<Candidate>(`${this.route}/${legendaCandidate}`);
}

}
