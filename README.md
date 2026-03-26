# 🏎️ GPFormula1 — Sistema de Gestão de Fórmula 1

Este projeto é uma aplicação completa para gerenciamento de dados da Fórmula 1, incluindo pilotos, equipes, temporadas, grandes prêmios e resultados de corrida.

A solução segue uma arquitetura limpa e organizada, utilizando:

- **ASP.NET Core 8 (API)**
- **Entity Framework Core**
- **SQL Server**
- **Arquitetura em camadas (API, Domínio, Infra)**
- **Repositórios + Services**
- **Aspire (em breve)**
- **Blazor Web (em breve)**

---

## 📂 Estrutura do ProjetoGPFormula1/ 
		│ 
		├── GPFormula1.Api/          → API REST
		├── GPFormula1.Dominio/      → Entidades e interfaces 
		├── GPFormula1.Infra/        → DbContext, Migrations, Repositórios 
		└── GPFormula1.sln           → Solução

---

## 🗄️ Banco de Dados

O projeto utiliza **SQL Server** com migrations do Entity Framework Core.

🚀 Próximos Passos
- Criar camada de Services
- Criar Controllers da API
- Integrar com Aspire AppHost
- Criar interface Blazor Web
- Criar testes automatizados

👨‍💻 Autor
Leonardo
Projeto desenvolvido para estudo e evolução em .NET, arquitetura limpa e aplicações modernas.

📜 Licença
Este projeto é livre para estudo e uso pessoal.
