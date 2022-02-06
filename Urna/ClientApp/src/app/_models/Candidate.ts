export class Candidate {
    public constructor(init?: Partial<Candidate>) { // Cria um partial com os dados do form group, se estes existirem
        Object.assign(this, init); // Copia valor a valor para este novo objeto sendo criado.
    }

    public candidateId : number;
    public nome : string;
    public nomeVice : string;
    public legenda : number;
    public dataRegistro : Date;
    public qtdVotos : number;
}
