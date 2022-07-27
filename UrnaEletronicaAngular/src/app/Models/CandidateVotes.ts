import { Candidate } from "./Candidate";

export class CandidateVotes {

    constructor(candidate : Candidate, votesQuantity:number) {
        this.candidate = candidate;
        this.votesQuantity = votesQuantity
    }

    candidate?: Candidate;
    votesQuantity : number;
}
