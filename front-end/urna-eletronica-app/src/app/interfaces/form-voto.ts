import { Candidato } from './candidato'

export interface FormVoto {
  idCandidato?: number;
  dataDoVoto: Date;
  votoEmBranco: boolean;
}
