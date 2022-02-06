export enum MsgStatus {
    Empty, 
    CandidateNotFilled, // Você deve preencher o número da legenda
    VoteSuccess, // Voto concluído com sucesso
    GenericVoteError, // Não foi possível enviar o voto
    GenericCandidateAddError, // Não foi possível enviar o candidato
    GenericCandidateDeleteError, // Não foi possível deletar o candidato
    CandidateDeleteSuccess, // Candidato removido com sucesso
    LegendaCandidateAddError, // Legenda já está sendo utilizada
  }