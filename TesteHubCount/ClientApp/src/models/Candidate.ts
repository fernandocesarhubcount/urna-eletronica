export class Candidate {

  constructor(nome: string, vice: string, dataRegistro: Date, legenda: number) {

    this.nome = nome;
    this.vice = vice;
    this.dataRegistro = dataRegistro;
    this.legenda = legenda;
  }

  id!: number;
  nome: string;
  vice: string;
  dataRegistro: Date;
  legenda: number;
}
