# Bem vindo ao Restaurant API!

Olá! Para executar o Restaurant API você precisa ter instalado o .Net Core 2.1 em seu computador, e também ter um cliente MySql. Você pode utilizar tanto no Visual Studio 2017+ ou no Visual Studio Code!
Os scripts para criação das tabelas e um script para inserir restaurantes estão dentro do arquivos tables.sql dentro da pasta SQL na raiz do projeto.


# Instruções

O sistema possui duas rotas atualmente. Uma para realizar o voto e uma para obter o restaurante do dia, os parâmetros a serem passados para rota você encontra a seguir.

## /api/restaurant/vote

**Rota POST**
recebe um json com os seguintes campos:
"RestaurantId":long, //id do restaurante cadastrado no banco
"ProfessionalId":long //id do profissional mocado
**Retornos**:
200 voto realizado com sucesso
400 erro ao votar, mensagem de retorno informando o motivo

**Mock de profissionais**

    Id | Nome
    1   "João"
	2   "Victor"
	3   "Catherine"
	4   "Osvaldo"
	5   "Patrick"
	6   "Belloto"
	7   "Dioudi"
	8   "Molina"


## /api/restaurant/todayLunch
**Rota GET**
não recebe parametros
retorna um json de sucesso ou falha
em caso de sucesso é informado o Id do Restaurante e Seu nome
**Retornos**:
200 obtido com sucesso
400 erro ao obter restaurante, mensagem de retorno informando o motivo



# Melhorias possíveis
Ao desenvolver o teste, percebi que existem várias melhorias e que por conta do tempo não foi possível implementar

 - Implementar testes de integração, tendo em vista que as validações estão distribuidas e não temos um dominio rico

-	Retirar validações do dto da Service e aplicar um rule pattern
-	Criar CRUD de usuários e autenticação
-	Front-end para exibir de maneira amigável para o usuário
-	Implementar Docker file e Jenkins file para CI/CD
-	kustomizes, configmaps etc para utilizar kubernets