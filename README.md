Mantis - Mariadb + Docker + SeleniumGrid/Node + Jenkins + Padrão de Projeto Page Object+ Selenium WEbDriver.

Foi utilizado o Docker para subi as imagens do Selenium Hub, Mantis, o banco Mariadb, Driver FireFox e Chrome, para cobrir o passo 4 foi criado uma instancia local do Internet Explorer.

Para criar os testes foi adotado as linguagens de programação CSharp e Java Scripts(alguns métodos adotado na arquitetura),o desafio foi feito em cima do Template da nova arquitetura definida pela Base2.

Segue abaixo o desafio definido.

Desafio Automação - Selenium WebDriver


Regras	2
Dicas	3
Exemplos de código 5

Regras

1) Implementar 50 scripts de testes que manipulem uma aplicação web (sugestões: Mantis ou TestLink) com Page Objects.
2) Alguns scripts devem ler dados de uma planilha Excel para implementar Data-Driven.
Quem utilizar Cucumber, SpecFlow ou outra ferramenta de BDD não precisa implementar lendo de uma planilha Excel. Pode ser a implementação de um Scenario Outline.
3) Notem que 50 scripts podem cobrir mais de 50 casos de testes se usarmos Data-Driven. Em outras palavras, implementar 50 CTs usando data-driven não é a mesma coisa que implementar 50 scripts.
4) Os casos de testes precisam ser executados em no mínimo três navegadores. Utilizando o Selenium Grid.
Não é necessário executar em paralelo. Pode ser demonstrada a execução dos browsers separadamente.
Não é uma boa prática executar os testes em todos os browsers em uma única execução. A melhor forma é controlar o browser através de um arquivo de configuração.
.NET: normalmente utiliza-se app.config
Java: normalmente utiliza-se a classe Properties e cria-se um arquivo chamado environment.properties.

(Metas 1 até 4 + as metas abaixo)
5) Gravar screenshots ou vídeo automaticamente dos casos de testes.
6) O projeto deverá gerar um relatório de testes automaticamente com screenshots ou vídeos embutidos. Sugestões: Allure Report ou ExtentReport.
7) A massa de testes deve ser preparada neste projeto, seja com scripts carregando massa nova no BD ou com restore de banco de dados.

(Metas 1 até 7 + as metas abaixo)
8) Um dos scripts deve injetar Javascript para executar alguma operação na tela. O objetivo aqui é exercitar a injeção de Javascript dentro do código do Selenium.
Sugestão: fazer o login usando Javascript ao invés do código do Selenium.
9) Testes deverão ser agendados pelo Jenkins, CircleCI, TFS, TeamCity ou outra ferramenta de CI que preferir.


