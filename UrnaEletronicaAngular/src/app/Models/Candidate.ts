export class Candidate {

    constructor(legenda : number, nome : string, nomeVice : string, dataRegistro : Date) {
        this.legenda = legenda;
        this.nome = nome;
        this.nomeVice = nomeVice;
        this.dataRegistro = dataRegistro;
    }

    legenda : number;
    nome : string;
    nomeVice : string;
    dataRegistro : Date;
}