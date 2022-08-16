import { Vote } from './../../models/Vote';
import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";

@Injectable(
  { providedIn: 'root' }
)

export class VoteService {
  private readonly url = 'https://localhost:5001/'

  constructor(private http: HttpClient) { }

  getAllVotes() {
    return this.http.get(this.url + 'votes')
  }

  postVote(vote: Vote) {
    return this.http.post(this.url + 'vote', vote)
  }


}
