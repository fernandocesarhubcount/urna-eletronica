import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { environment } from "src/environments/environment"
import { Candidate } from "../Models/Candidate";
import { CandidateVotes } from "../Models/CandidateVotes";
import { Vote } from "../Models/Vote";

@Injectable()
export class VoteService {

route = `${environment.apiRoute}/vote`;

constructor(private http : HttpClient) {
    
}

get() : Observable<CandidateVotes[]>{
   return this.http.get<CandidateVotes[]>(this.route);
}

post(vote : Vote) : Observable<Vote> {
    return this.http.post<Vote>(this.route, vote);
}

}
