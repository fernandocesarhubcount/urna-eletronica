# Parabéns Desenvolvedores!

Se você recebeu este teste é porque você foi um dos selecionados para a fase de conhecimento da vaga da HubCount.

Mas vamos para o que importa: O Teste.

## Urna Eletrônica (Votação exclusiva para Presidente)

### DESAFIO: desenvolver uma urna eletrônica

### Descrição Front-end 

 - Criar três tela em HTML, CSS e JS (com ou sem frameworks)
 - **Primeira tela** => deve ter o layout parecido com o de uma urna eletrônica (não é necessário mostrar a foto, apenas nome e vice), possuindo 3 passos:
  1. Inserir o código do candidato à prefeito (2 dígitos), mostrar o dado do candidato e aguardar a tecla de confirmar, limpar ou branco.
  2. Tela de fim, com um botão de reiniciar votação.
 - **Segunda tela** => cadastro e listagem (com opção de deletar) de candidatos com os seguintes campos (sem layout definido, fique à vontade para criar um):
  1. Nome Completo
  2. Legenda
 - **Terceira tela** => dashboard com a quantidade que cada candidato recebeu, mantendo a ordem de quem recebeu mais votos em primeiro na listagem.
  
### Descrição Back-end

 - Desenvolver uma API om C# e Entity Framework (o body de retorno e de envio deverá ser em JSON), com os seguintes endpoints:
 
 1. **/candidate [via POST]**: Registro de candidatos.
 2. **/candidate  [via DELETE]**: Exclusão de candidatos.
 3. **/vote [via POST]**: cadastro dos votos. Deverá tratar os votos nulos.
 4. **/votes [via GET]**: retorna os  candidatos (nome, legenda...) com a quantidade de votos que cada um recebeu.
 
 - O registro de candidatos deverá conter:
 1. **Nome Completo** (_string_)
 2. **Nome do Vice** (_string_)
 3. **Data de registro** (_DateTime_)
 4. **Legenda** (_int32_)
 
 - O registro de votos deverá conter:
 1. **Id do candidato** (_referência à tabela de candidatos_)
 2. **Data do voto** (_DateTime_)

### Regras do teste:

- Crie um branch deste repositório e, quando estiver finalizado, realize um pull request para a master e me envie um e-mail (fernando.cesar@hubcount.com.br)
- Desenvolver e entregar até a meia noite da data combinada.
- Utilizar a linguagem C# com o Entity Framework e ferramentas web como Javascript, HTML e CSS(_Requisitos Obrigatórios_)
- Pode utilizar qualquer outra ferramenta que te agrade
- Havendo qualquer dúvida sobre o teste é só entrar em contato pelo e-mail: fernando.cesar@hubcount.com.br

### Método de avaliação por prioridade (_da mais para a menos importante_):

1. Data de entrega: não ultrapassar o deadline (7 dias do envio do teste).
2. Funcionalidade: deve funcionar da forma pedida.
3. Ferramentas: deve utilizar as tecnologias obrigatórias.
4. Validações: deve validar os campos e retornar mensagens amigáveis.
5. Código: bem escrito e bem descrito.
6. Plus*: desenvolver com algum framework JS (AngularJS, Angular 2+, React, Vue ...).
7. Plus II*: layout (você não é designer, mas sabemos como uma urna se parece).
8. Plus III*: outras tecnologias utilizadas (Dapper, Bootstrap ...).

\*: _o importante são os outros pontos, mas esse poderá ser escolhido como ponto de desempate_
