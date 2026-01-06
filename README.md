# Pedeai 🍔 — iFood-like (Projeto de Estudo)

O **Pedeai** é um projeto backend inspirado no iFood, desenvolvido exclusivamente para fins educacionais, com o objetivo de praticar e aprofundar conhecimentos em **C# e .NET 8**.

O foco do projeto está na **arquitetura**, **boas práticas** e **conceitos modernos de backend**, como:

- API REST e GraphQL
- Autenticação com JWT
- Organização por módulos (Auth, Catalog, Ordering)
- CQRS (Commands & Handlers)
- Entity Framework Core e migrations
- Separação de camadas (Domain, Application, Infrastructure)

> ⚠️ Este projeto **não possui qualquer vínculo com o iFood** e **não tem fins comerciais**, sendo apenas uma implementação inspirada para estudo e experimentação.

---

## 🛠️ Pré-requisitos

- [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)
- [SQLite](https://www.sqlite.org/download.html) (opcional, para inspecionar o banco)
- Editor de código (VS Code, Visual Studio, Rider, etc.)

---

## 🗂️ Arquitetura do Banco

[Link para o Lucidchart com o MER](https://lucid.app/lucidspark/dd1ccfb5-25e6-4f8d-a937-330f356ddb33/edit?view_items=unkgSUEYL2V6&page=0_0&invitationId=inv_ef198246-d07b-42ee-aa53-b896304dceef)

## ⚡ Instalação

1. Clone o repositório:

```bash
git clone <REPO_URL>
cd Pedeai
```

2. Restaure as dependências:

```bash
dotnet restore
```

3. Crie e pasta para o banco de dados SQLite:

```bash
mkdir Temp
```

4. Configure a connection string no appsettings.json ou via variáveis de ambiente:

```json
"ConnectionStrings": {
  "DefaultConnection": "Data  Source=./Temp/my-db.db"
}
```

---

## 🏗️ Criar e aplicar migrations

1. Instale o dotnet-ef se ainda não tiver:

```bash
dotnet tool install --global dotnet-ef
```

2. Crie uma migration inicial:

```bash
dotnet ef migrations add InitialCreate
```

3. Aplique as migrations para criar o banco:

```bash
dotnet ef database update
```

---

## 🚀 Executar o projeto

Execute o projeto com o comando:

```bash
dotnet run
```

O servidor estará rodando em `https://localhost:5205`.

## 📜 Documentação da API

A documentação interativa da API está disponível em `https://localhost:5205/swagger`.

