# Usando o end-point

Tracking.sln
  ├──port:
  │   └──https://localhost:7095/
  └──end-point:
      ├──●1. [Cadastrar] o tipo de eleição, Exemplo: Presidente, Veriador, Deputador // Possibilidade infinitas. 
      │   ├──+ Election[Post]: /elections
      │   │
      │   │       {
      │   │         "name": "string", 
      │   │        "active": true
      │   │       }
      │   │
      │   ├── ... //FAÇA A COPIA DO ID Eleição que vai está logo no response: Exemplo > 388fba5d-9d87-45c0-b02f-9a987a74d42c 
      │   │
      ├──●2. [Cadastrar] o candidato
      │   ├──+ Candidate[Post]: /candidates   
      │   │
      │   │        { 
      │   │            "name": "string",        //Nome do candidato
      │   │             "candidateLegend": 0,    //Legenda, 13, 17, 12, 56, .....
      │   │             "viceName": "string",    //Nome do Vice
      │   │             "electionId": "COLAR AQUI O ID DA ETAPA [1] REFERENTE A O TIPO DE ELEIÇÃO QUE O CANDIDATO VAI PARTICIPAR",
      │   │             "registerDate": "2022-08-02T19:37:23.409Z", //AUTOMATICO
      │   │             "amountVote": 0 //SE POR ACASO QUISER QUE O CANDIDATO INICIE JÁ COM QUANTIDADE DE VOTO. 
      │   │        }
      │   │
      │   ├── ... //NÃO ESQUECER DE INSERIR O ID DO TIPO DE ELEIÇÃO NA CHAVE [electionId]
      │   │     
      ├──●3. [Verificar] titulo de eleito. // Já está de forma que o modelBuilder persiste no banco 
      │   ├──+ Electorate[Get]: /electorate 
      │   │
      │   │        [
      │   │            {
      │   │                "singleVoterTitle": "007321"
      │   │            }
      │   │         ]
      │   │
      │   ├── ... //FAÇA A COPIA DO ID singleVoterTitle, referente ao titulo de eleitor: Exemplo > 007321, vai ser utilizado no passo 4. 
      │   │
      ├──●4. [Efetiva] o VOTO 
      │   ├──+ Vote[Post]: /electorate 
      │   │
      │   │           {
      │   │              "singleVoterTitle": "string", // COLAR AQUI O NÚMERO DO TITULO DE ELEITOR REFERENTE A ETAPA [3]
      │   │               "candidateLegend": [
      │   │                   0                         //Adicionar o número da legenda do candidato, pra efetivar o voto
      │   │                 ],
      │   │                  "totalCandidateVote": 0      //Se não optar em efetuar o voto gerando por um unico ID 1 to 1, basta colocar quantidade acima de 1. 
      │   │           }
      │   │
      │   ├── ... //NÃO ESQUECER DE INSERIR NA CHAVE [singleVoterTitle] O VALOR DO TITULO : Exemplo > 007321  
      │   │
      ├──●4. Verificar o Comprovante do voto // Basta colocar o ID gerado e exibido no response do Metodo VotePost
      │   ├──+ Vote[Get] : /votes/{id}
      │   │
      │   │ 
      ├──●5. Verificar os tipos de eleições cadastradas.
      │   ├──+ Election[GetAll] : /elections
      │   │
      ├──●6. Verificar os todos os candidatos.
      │   ├──+ Candidate[GetAll] : /candidates
      │   │
      ├──●7. Verificar os todos votos relacionados aos candidatos.
      │   ├──+ CandidateVote[Get] : /candidates/relatory
      │   │
      ├──●Packages utilizados
      │   ├──+ .NET 6    
      │   ├──+ .ENTITY FRAMEWORK  
      │   ├──+ .DAPPER
      │   ├────Database:    
      │   │       ├──En
      │   │       └──SQLServer   
      └──02/08/22 - 17:18
