export class Vote {


  constructor(candidatoId: number) {
    this.CandidatoId = candidatoId;

    this.Datadovoto = new Date();
  }

  Id!: number;
  Datadovoto!: Date;
  CandidatoId!: number;
}
