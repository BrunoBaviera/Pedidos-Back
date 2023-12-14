# Pedidos

Api desenvolvida para simular um E-commerce.

## Construído com
- ASP.NET Core WebAPI 6.0
- Sql Server - Migrations
- Entity Framework Core

## Como funciona

- A aplicação foi desenvolvida com padrão MVC, controle de versão pelo Swagger e padronização nas validações e retornos de cada requisição.
- Foi utilizado AutoMapper para conversão de Model e ViewModel.
- As requisições de GET() podem ser paginadas ou retornar com todos os resultados.
- Foram criados mapeamentos para cada entidade no DBContext com relacionamento entre elas para utilização de Tnclude() e ThenInclude().
