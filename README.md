# 🏎️ GPFormula1 — Sistema de Gestão de Fórmula 1

Este projeto é uma aplicação completa para gerenciamento de dados da Fórmula 1, incluindo pilotos, equipes, temporadas, grandes prêmios e resultados de corrida.

A solução segue uma arquitetura limpa e organizada, utilizando:

- **ASP.NET Core 10 (API)**
- **Entity Framework Core**
- **SQL Server**
- **Arquitetura em camadas (API, Domínio, Infra, Negócio)**
- **Repositórios + Services**
- **Swagger/OpenAPI**
- **Aspire (em desenvolvimento)**
- **Blazor Web (em desenvolvimento)**

---

## 📂 Estrutura do Projeto

```
GPFormula1/
├── src/
│   ├── GPFormula1.Api/             → API REST com Swagger
│   ├── GPFormula1.Dominio/         → Entidades, Interfaces e Services
│   ├── GPFormula1.Infra/           → DbContext, Configurations, Repositórios
│   ├── GPFormula1.Negocio/         → Camada de negócios (em breve)
│   ├── GPFormula1.AppHost/         → Aspire AppHost (em breve)
│   └── GPFormula1.Web/             → Blazor Web App (em breve)
└── GPFormula1.sln
```

---

## 🗄️ Banco de Dados

O projeto utiliza **SQL Server** com **Entity Framework Core** e **Code-First Migrations**.

### Entidades Implementadas:
- ✅ **Piloto** - Id, Nome, Nacionalidade, Numero, EquipeId
- ✅ **Equipe** - Id, Nome, Pais, Sede
- ✅ **Temporada** - Id, Ano
- ✅ **GrandePremio** - Id, Nome, Pais, Circuito, Data, TemporadaId
- ✅ **ResultadoCorrida** - Id, Posicao, Pontos, PilotoId, GrandePremioId

### Relacionamentos:
- Piloto → Equipe (N:1)
- GrandePremio → Temporada (N:1)
- ResultadoCorrida → Piloto (N:1)
- ResultadoCorrida → GrandePremio (N:1)

---

## ✅ Progresso do Projeto

### 🧱 1. Camada de Infraestrutura (CONCLUÍDO)
- ✅ `F1DbContext` configurado
- ✅ Configurações Fluent API para todas as entidades
- ✅ `RepositorioBase<T>` genérico
- ✅ Repositórios concretos (Piloto, Equipe, Temporada, GrandePremio, ResultadoCorrida)
- ✅ Migrations criadas e aplicadas com sucesso

### 🎯 2. Camada de Domínio (CONCLUÍDO)
- ✅ Entidades de domínio
- ✅ Interfaces de repositórios
- ✅ Interface `IPilotoService`

### 🧩 3. Camada de Serviços (EM ANDAMENTO)
- ✅ `PilotoService` - CRUD completo com regras de negócio
- ⏳ `EquipeService` - Próximo
- ⏳ `TemporadaService` - Próximo
- ⏳ `GrandePremioService` - Próximo
- ⏳ `ResultadoCorridaService` - Próximo

### 🌐 4. API REST (EM ANDAMENTO)
- ✅ `PilotoController` - Endpoints RESTful completos
  - `GET /api/Piloto` - Listar todos
  - `GET /api/Piloto/{id}` - Buscar por ID
  - `POST /api/Piloto` - Criar novo
  - `PUT /api/Piloto/{id}` - Atualizar
  - `DELETE /api/Piloto/{id}` - Remover
- ✅ DTOs para Piloto (`CriarPilotoDto`, `AtualizarPilotoDto`)
- ✅ Swagger configurado e funcionando
- ✅ Injeção de dependência configurada no `Program.cs`

### 🔧 5. Configurações
- ✅ `appsettings.json` com connection string
- ✅ `launchSettings.json` configurado para abrir Swagger automaticamente
- ✅ Program.cs organizado com métodos separados

---

## 🚀 Como Executar

### 1. Pré-requisitos
- .NET 10 SDK
- SQL Server (LocalDB ou SQL Server Express)
- Visual Studio 2026 ou VS Code

### 2. Configurar Banco de Dados
```bash
cd src/GPFormula1.Infra
dotnet ef migrations add InitialCreate -s ../GPFormula1.Api
dotnet ef database update -s ../GPFormula1.Api
```

### 3. Executar a API
```bash
cd src/GPFormula1.Api
dotnet run
```

A API estará disponível em:
- **HTTPS**: https://localhost:7216/swagger
- **HTTP**: http://localhost:5153/swagger

---

## 📋 Próximos Passos

### 🔜 Curto Prazo
- [ ] Criar Services para Equipe, Temporada, GrandePremio e ResultadoCorrida
- [ ] Criar Controllers correspondentes
- [ ] Implementar tratamento de erros global
- [ ] Adicionar validações com FluentValidation

### 🎯 Médio Prazo
- [ ] Integrar com Aspire AppHost
- [ ] Configurar containers Docker (SQL Server)
- [ ] Implementar Health Checks
- [ ] Criar Dashboard de observabilidade

### 🎨 Longo Prazo
- [ ] Criar projeto Blazor Web
- [ ] Implementar páginas de gestão (Pilotos, Equipes, etc.)
- [ ] Criar componentes reutilizáveis
- [ ] Implementar autenticação e autorização
- [ ] Adicionar testes unitários e de integração

---

## 🛠️ Tecnologias Utilizadas

- **[.NET 10](https://dotnet.microsoft.com/)** - Framework principal
- **[Entity Framework Core](https://docs.microsoft.com/ef/core/)** - ORM
- **[SQL Server](https://www.microsoft.com/sql-server)** - Banco de dados
- **[Swagger/OpenAPI](https://swagger.io/)** - Documentação da API
- **[Aspire](https://learn.microsoft.com/dotnet/aspire/)** - Orquestração (em breve)
- **[Blazor](https://dotnet.microsoft.com/apps/aspnet/web-apps/blazor)** - Frontend (em breve)

---

## 👨‍💻 Autor

**Leonardo**  
Projeto desenvolvido para estudo e evolução em .NET, arquitetura limpa e aplicações modernas.

---

## 📜 Licença

Este projeto é livre para estudo e uso pessoal.
