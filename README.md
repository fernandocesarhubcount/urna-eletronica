# Parabéns Desenvolvedores!

Se você recebeu este teste é porque você foi um dos selecionados para a fase de conhecimento da vaga da HubCount.

Mas vamos para o que importa: O Teste.

## Urna Eletrônica

### DESAFIO: desenvolver uma urna eletrônica

### Descrição Front-end 

 - Criar três tela em HTML, CSS e JS (com ou sem frameworks)
 - **Primeira tela** => deve ter o layout parecido com o de uma urna eletrônica (não é necessário mostrar a foto, apenas nome e vice, se tiver), possuindo 3 passos:
  1. Inserir o código do candidato à prefeito (2 dígitos), mostrar o dado do candidato e aguardar a tecla de confirmar, limpar ou branco.
  2. Inserir o código do candidato à vereador (5 dígitos), mostrar o dado do candidato e aguardar a tecla de confirmar, limpar ou branco.
  3. Tela de fim, com um botão de reiniciar votação.
 - **Segunda tela** => cadastro e listagem (com opção de deletar e editar) de candidatos com os seguintes campos (sem layout definido, fique à vontade para criar um):
  1. Tipo de candidatura (prefeito ou vereador)
  2. Nome Completo
  3. Nome do Vice (para prefeito apenas)
  4. Legenda
 - **Terceira tela** => dashboard com a quantidade que cada candidato recebeu, mantendo a ordem de quem recebeu mais votos em primeiro na listagem.
  
### Descrição Back-end

 - Desenvolver uma API om C# e Entity Framework (o body de retorno e de envio deverá ser em JSON), com os seguintes endpoints:
 
 1. **/candidate [via POST]**: Registro de candidatos.
 2. **/candidate  [via DELETE]**: Exclusão de candidatos.
 3. **/candidate [via EDIT]**: Edição de candidatos
 4. **/vote [via POST]**: cadastro dos votos. Deverá tratar os votos nulos.
 5. **/votes [via GET]**: retorna os  candidatos (nome, legenda...) com a quantidade de votos que cada um recebeu. OBS: inclua a opção de filtrar por tipo de candidato (Prefeito ou Vereador), sendo que o tipo 0 (zero) deverá retornar todos os votos e o tipo 3 deverá retornar os votos brancos e/ou nulos.
 
 - O registro de candidatos deverá conter:
 1. **Nome Completo** (_string_)
 2. **Nome do Vice** (_string?_)
 3. **Data de registro** (_DateTime_)
 4. **Legenda** (_int32_)
 5. **Tipo do Candidato** (_**1**-prefeito e **2**-vereador_)
 
 - O registro de votos deverá conter:
 1. **Id do candidato** (_referência à tabela de candidatos_)
 2. **Data do voto** (_DateTime_)
 3. **Código de votação do cidadão**, sendo a união da data no formato yyyyMMdd com o IP da máquina em que está sendo feita a votação, encriptografado em MD5 (exemplo: 20201127192.168.0.1, que é igual a 97b4b4545f558b3d27cebf0aa8b8109e).

### Regras do teste:

- Crie um branch deste repositório e, quando estiver finalizado, realize um pull request para a master
- Desenvolver e entregar até a meia noite da data combinada.
- Utilizar a linguagem C# com o Entity Framework (_Requisitos Obrigatórios_)
- Pode utilizar qualquer outra ferramenta que te agrade
- Havendo qualquer dúvida sobre o teste é só entrar em contato pelo e-mail: fernando.cesar@hubcount.com.br

### Método de avaliação por prioridade (_da mais para a menos importante_):

1. Data de entrega: não ultrapassar o deadline.
2. Funcionalidade: deve funcionar da forma pedida.
3. Ferramentas: deve utilizar as tecnologias obrigatórias.
4. Validações: deve validar os campos e retornar mensagens amigáveis.
5. Código: bem escrito e bem descrito.
6. Plus*: desenvolver com algum framework JS, preferência por AngularJS ou Angular 2+.
7. Plus II*: layout.
8. Plus III*: outras tecnologias utilizadas.

\*: _o importante são os outros pontos, mas esse poderá ser escolhido como ponto de desempate_
