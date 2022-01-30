import { Candidato } from './candidato';

export interface Voto {
  id?:number;
  idCandidato?: number;
  dataVoto: Date;
  votoEmBranco: boolean;
}
