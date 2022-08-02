export class Vote {
    id: string;
    candidateId: string;
    dataVoto: string;
    legenda: number;

    constructor(legenda: number) {
        this.legenda = legenda;
    }
}
