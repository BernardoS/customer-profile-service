![alt text](capa-wallet-profile.png)

# Customer Profile Service

Este é um dos serviços que compõem a aplicação "WalletProfile", a proposta é ser uma aplicação básica para mapear o perfil de investimento de um usuário e assim sugerir uma carteira de investimentos personalizada com base nisso.

## Propósito do projeto

Este projeto tem como objetivo exercitar algumas práticas relacionadas ao desenvolvimento de aplicações ASP.NET, desde a modelagem do domínio a implementação utilizando padrões conhecidos no mercado.

🔹 Responsável por:

Cadastro de clientes
Definição do perfil de investidor (Conservador, Moderado, Agressivo)

🔹 Como funciona:

Ao criar o cliente, o próprio serviço já calcula o perfil
Pode usar Strategy Pattern internamente

📌 Evento publicado:

`CustomerProfileCreated`

----
## Tecnologias utilizadas

- .NET
- RabbitMQ (implementações futuras)
- Entity Framework (implementações futuras)

----

## Integrações

Este serviço terá integração com outros serviços para compor o "WalletProfile", são eles:

- RecommentationService: Voltado para montar as recomendações com base no perfil;
- MarketDataService: Voltado para capturar os dados do mercado em tempo real para servir como parâmetro para as recomendações.

----

Desenvolvido por https://github.com/BernardoS/