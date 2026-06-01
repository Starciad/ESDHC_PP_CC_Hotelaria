# Trabalho de Paradigmas de Programação - Sistema de Gerenciamento de Reservas para Hotel

## Sumário

- [Trabalho de Paradigmas de Programação - Sistema de Gerenciamento de Reservas para Hotel](#trabalho-de-paradigmas-de-programação---sistema-de-gerenciamento-de-reservas-para-hotel)
  - [Sumário](#sumário)
  - [Visão Geral](#visão-geral)
  - [Introdução](#introdução)
  - [Funcionalidades](#funcionalidades)
  - [Rotas](#rotas)
  - [Ferramentas](#ferramentas)
  - [Créditos](#créditos)

## Visão Geral

- Sistema de Gerenciamento de Reservas para Hotel.
- Projeto de Paradigmas de Programação (CC2M).
- Ciência da Computação | Centro Universitário Dom Helder Câmara.

## Introdução

Este projeto é uma aplicação web construída com o framework ASP.NET Core MVC, destinada a gerenciar reservas em um hotel. Ele permite que os usuários criem reservas, adicionem dependentes (hóspedes adicionais) e visualizem as informações das reservas. O projeto é estruturado em camadas, seguindo boas práticas de desenvolvimento, e utiliza Entity Framework Core para acesso ao banco de dados.

## Funcionalidades

- **Gerenciamento de Reservas**: Os usuários podem criar novas reservas, selecionando as datas de check-in e check-out, o tipo de quarto e adicionando dependentes (hóspedes adicionais) à reserva.
- **Visualização de Reservas**: Os usuários podem visualizar as informações das reservas criadas, incluindo detalhes como datas, tipo de quarto e dependentes.
- **Autenticação e Autorização**: O sistema possui um sistema de autenticação e autorização para garantir que apenas usuários registrados possam criar reservas e acessar informações sensíveis.
- **Interface Amigável**: A aplicação possui uma interface amigável e responsiva, facilitando a navegação e a interação dos usuários com o sistema.

## Rotas

| Rota                         | Descrição                                                                                                                                                |
| ---------------------------- | -------------------------------------------------------------------------------------------------------------------------------------------------------- |
| `/`                          | Página inicial do site.                                                                                                                                  |
| `/About/Index`               | Página de informações sobre o hotel.                                                                                                                     |
| `/Account/Login`             | Tela de login para usuários existentes.                                                                                                                  |
| `/Account/Register`          | Tela de registro para novos usuários.                                                                                                                    |
| `/Contact/Index`             | Página de contato para os usuários entrarem em contato com o hotel.                                                                                      |
| `/Home/Index`                | Página principal do site, exibindo informações gerais e opções de navegação.                                                                             |
| `/Reservations/Create`       | Tela para criar uma nova reserva, onde os usuários podem selecionar as datas de check-in e check-out, escolher o tipo de quarto e adicionar dependentes. |
| `/Reservations/Success/{id}` | Página de sucesso após a criação de uma reserva.                                                                                                         |
| `/Rooms/Index`               | Página para visualizar os quartos disponíveis.                                                                                                           |

## Ferramentas

| Biblioteca/Framework      | Descrição                                                                                                                    |
| ------------------------- | ---------------------------------------------------------------------------------------------------------------------------- |
| **ASP.NET Core MVC**      | Framework para construção de aplicações web seguindo o padrão Model-View-Controller.                                         |
| **Entity Framework Core** | ORM (Object-Relational Mapper) para acesso ao banco de dados.                                                                |
| **ASP.NET Core Identity** | Sistema de autenticação e autorização para gerenciar usuários e roles.                                                       |
| **JQuery**                | Biblioteca JavaScript para manipulação do DOM, facilitação de operações AJAX e principalmente para validação de formulários. |
| **Font Awesome**          | Biblioteca de ícones para melhorar a interface do usuário.                                                                   |

## Créditos

Esse projeto foi desenvolvido por um grupo de estudantes como parte do curso de Paradigmas de Programação. Os membros do grupo são:

- [Davi Fernandes](https://github.com/Starciad)
- [Gabriel Souza](https://github.com/medeirosszg)
- [João Rezende](https://github.com/joaorezende73)
- [Julia Pereira](https://github.com/juuliahelena)
- [Marcos Bacelar](https://github.com/)
- [Maria Santiago](https://github.com/Maria-Rsantiago)
