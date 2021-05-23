# StoneChallenge
Desafio - Distribuição dos lucros

-----------------Tecnologias utilizadas:

Para o desafio proposto foi criada duas APIs em .Core 5 com conceitos de clean architecture, clean code e DDD:
 - EmployeeManagement.Api : Responsavel pela inserção remoção e obtenção dos funcionarios
 - ProfitSharing.Api : Responsavel pelo cálculo da participação de lucros

Resiliencia utilizado Polly onde a ProfitSharing.Api tenta três retries do request para a EmployeeManagement.Api na obtenção de funcionarios cadastrados dentro de 15 segundos.

Em questão de monitoramento as duas apis contam com healthcheck nativo utilizando os seguinte endpoint [api]/api/hc e também com uma comunicação utilizando o ElmahIo onde todos os logs gerados pelas duas aplicações ficam armazenadas e enviam erros por e-mail. Para acessar apenas utilizem o
site https://app.elmah.io/dashboard/ e fazer login com as seguintes credenciais:
login: desafiodistribuicaodelucros@gmail.com
password: Stonechallenge1@

e para checar os e-mails disparados acessar a seguinte conta de e-mail do gmaail:
login: desafiodistribuicaodelucros@gmail.com
password: stonechallenge

Foi utilizado Xunit para os testes unitarios

Para o uso Git foi utilizado gitflow com conventional commits

As duas Apis utilizam versionamento nativo e também contam com documentação em swagger onde tem os endpoints necessários algumas informações de contato e o tipo de licença, podendo ser possivel testar os endpoints mandando um post pelo proprio swagger.

Persistencia de dados utilizando MongoDB Atlas

-----------------Passos para testar a aplicação:
É necessário rodar as duas apis (EmployeeManagement.Api,ProfitSharing.Api) simultanemanete sendo acessado pelo StoneChallenge.sln

É necessário a inserção dos funcionários, para isso utilizar o endpoint /api/v1/EmployeeManagement/AddEmployees da EmployeeManagement.Api (encontrado no proprio swagger) colocando então a lista de funcionário fornecidos pelo próprio participacao-nos-lucros.pdf 
Após inserido caso queira remover algum funcionario basta mandar um post para o endpoint /api/v1/EmployeeManagement/RemoveEmployees passando uma lista com a matricula e o nome do(s) funcionario(s) que desaja remover

Após os funcionários estarem registrados apenas mandar um valor decimal que representa o valor que deseja ser distribuido para o endpoint /api/v1/ProfitSharingCalculator/CalculateProfitSharing da ProfitSharing.Api que ela fará a divisão desse valor considerando todos os pesos passados no desafio e calculará a divisão de lucros, caso o montante seja menor que o necessário para cada um receber sua participação o sistema distribuirá a todos os funcionarios cadastrados a sua parte do dinheiro fazendo uma redução porcentual considerando o que cada um deveria receber e o valor disponivel.

Muito obrigado pela oportunidade de realizar o desafio
