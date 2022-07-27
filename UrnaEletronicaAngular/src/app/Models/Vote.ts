export class Vote {
    constructor(legendaCandidato: number, dataVoto: Date) {
        this.legendaCandidato = legendaCandidato;
        this.dataVoto = dataVoto;
    }

    id: number;
    legendaCandidato?: number;
    dataVoto: Date;
}
