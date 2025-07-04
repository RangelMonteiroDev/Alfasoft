# ContactManager 📇

Sistema de gerenciamento de contatos desenvolvido em **ASP.NET Core com Razor Pages**, utilizando **MariaDB** via Docker como banco de dados.

## Funcionalidades
- CRUD completo de contatos
- Autenticação simples (login estático)
- Validações com Data Annotations
- Soft delete
- Testes unitários manuais integrados ao projeto principal

## Tecnologias Utilizadas
- .NET 9
- Razor Pages
- Entity Framework Core
- MariaDB 10.6 (via Docker)
- xUnit (testes unitários)
- Docker Compose
- C#

## Como executar a aplicação

### 1. Suba o banco de dados com Docker:
```bash
docker-compose up -d

### Execute o projeto
dotnet run --framework net9.0

### Executar os Testes
var test = new ContactValidationTests();
test.Contact_With_Valid_Data_Should_Be_Valid();

### Estrutura de diretórios
ContactManager/
├── Models/
│   └── Contact.cs
├── Pages/
│   └── Contacts/
│       ├── Index.cshtml
│       ├── Create.cshtml
│       └── ...
├── Data/
│   └── ApplicationDbContext.cs
├── Tests/
│   └── ContactValidationTests.cs
├── appsettings.json
├── Program.cs
└── ContactManager.csproj


