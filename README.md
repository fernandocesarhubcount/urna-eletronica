## Urna Eletrônica (Votação exclusiva para Prefeito)

### Descrição Front-end 

 - **Primeira tela** => layout parecido com o de uma urna eletrônica, possui 3 passos:
  1. Inserir o código do candidato à prefeito (2 dígitos), mostrar o dado do candidato e aguardar a tecla de confirmar, limpar ou branco.
  2. Tela de fim, com um botão de reiniciar a votação.
 - **Segunda tela** => cadastro e listagem (com opção de editar e deletar) de candidatos com os seguintes campos:
  1. Nome Completo
  2. Legenda
 - **Terceira tela** => dashboard com a quantidade que cada candidato recebeu, mantendo a ordem de quem recebeu mais votos em primeiro na listagem.
  
### Descrição Back-end

 - API com C# e Entity Framework (body de retorno e de envio em JSON), com os seguintes endpoints:
 
 1. **/candidate [via POST]**: Registro de candidatos.
 2. **/candidate  [via DELETE]**: Exclusão de candidatos.
 3. **/vote [via POST]**: cadastro dos votos. Deverá tratar os votos nulos.
 4. **/votes [via GET]**: retorna os  candidatos (nome, legenda...) com a quantidade de votos que cada um recebeu.
 
 - O registro de candidatos contém:
 1. **Nome Completo** (_string_)
 2. **Nome do Vice** (_string_)
 3. **Data de registro** (_DateTime_)
 4. **Legenda** (_int32_)
 
 - O registro de votos contém:
 1. **Id do candidato** (_referência à tabela de candidatos_)
 2. **Data do voto** (_DateTime_)