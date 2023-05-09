Testes Automatizados com Selenium Webdriver e NUnit!
Código criado por: Samuel de Matos Pereira!

Requerimentos:
- Navegador Google Chrome Versão 113.0.5672.64;
- Visual Studio 2022;
- wampserver3.3.0_x64 (para a execução dos testes no website de exemplo);

Instalação:
- Ponha a pasta "Teste de exemplo" diretamente no disco local C:;
- Abra a pasta "Teste de exemplo" e ponha os atalhos na área de trabalho (exceto o teste de exemplo.dll), 
assim poderá abrir o código e o NUnit GUI diretamente pela área de trabalho!

Instalação do website de demonstração:
- Descompacte o arquivo "website";
- Ponha a pasta "login" no seguinte endereço: C:\wamp64\www
- Execute o wamp64, abra o navegador e digite "http://localhost/". Abra o "phpMyAdmin"
(que já é instalado junto com o wamp64), faça login com "root" e crie uma tabela chamada 
"usuarios "com as seguintes colunas:
id (int, AUTO_INCREMENT);
nome (varchar(140));
email (varchar(140));
senha (varchar(16));
texto (longtext);

Observações:
- Wampserver precisa estar ativado para poder demonstrar os testes;
- Os testes podem ser executados tanto diretamente pelo Visual Studio quanto pelo GUI do NUnit;
- Os prints estarão na pasta "Prints" e os logs na pasta "Logs". Ambas as pastas localizadas dentro da pasta "Teste de exemplo";