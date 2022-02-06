export class Vote {
    public candidateId : number;
    public dataVoto : Date;

    constructor(candidateId: number) {
        this.candidateId = candidateId;
    }
}
