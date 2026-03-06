### **WaterDelivery - Backend API**

Esta é uma API desenvolvida em ASP.NET Core como parte de um estudo sobre arquitetura de back-end, segurança e persistência de dados. O projeto funciona como um MVP (Minimum Viable Product) para a gestão de um estabelecimento de entrega de garrafões de água, permitindo o controle desde o registro do cliente até a entrega da água.

📽️ **Demonstração em Vídeo**

https://youtu.be/vo00-ewBMnA

Usei um Frontend simples para consumir a API.

🛠️ **Tecnologias e Ferramentas**
O projeto foi construído utilizando o ecossistema do .NET 8:

- **Framework Principal:** ASP.NET Core (Web API)
- **Persistência de Dados:** Entity Framework Core (Code First)
- **Banco de Dados:** PostgreSQL (via Npgsql)
- **Segurança:**
  - Autenticação e Autorização via JWT (JSON Web Tokens).
  - Criptografia de senhas com BCrypt.Net-Next.
- **Documentação:** Swagger (OpenAPI) para teste facilitado dos endpoints.

🏗️ **Arquitetura e Organização**
Para garantir a escalabilidade e a fácil manutenção, o projeto foi estruturado utilizando princípios de **Clean Architecture** e **DDD (Domain-Driven Design)**, dividido nas seguintes camadas:

- **Presentation (API):** Ponto de entrada do sistema, contendo os Controllers,
- **Domain:** Contém as entidades de negócio e regras fundamentais.
- **Application:** Onde reside a lógica de uso (comandos, consultas e interfaces).
- **Infrastructure:** Responsável pela persistência (EF Core) e integração com o PostgreSQL.

🚀 **Funcionalidades Principais**

- **Registro de Clientes:** Cadastro seguro para acesso à plataforma.
- **Pedidos Flexíveis:** Opção de pedido imediato ou agendamento de horário para a entrega do garrafão.
- **Painel Administrativo:** O administrador acompanha todos os pedidos em tempo real.

🏗️ **Destaques Técnicos**

Ao desenvolver este primeiro projeto em .NET, foquei em implementar padrões que garantem a segurança e a manutenibilidade:

- **Segurança de Dados:** Implementação de Hash com BCrypt para garantir que nenhuma senha seja armazenada em texto puro no PostgreSQL.
- **Autenticação JWT:** Proteção de rotas sensíveis, exigindo um Bearer Token válido para o acesso.
- **Migrations:** Uso total do EF Core Tools para versionamento do banco de dados.
- **Interface de Testes:** Integração completa com Swagger, permitindo que qualquer pessoa teste a API diretamente pelo navegador.
