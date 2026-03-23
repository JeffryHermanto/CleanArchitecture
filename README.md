# Clean Architecture with ASP.NET 10 🚀

This repository demonstrates a **Clean Architecture implementation using ASP.NET 10 Web API**.  
The goal is to provide a **scalable, maintainable, and testable foundation** that can be reused in real-world projects.

---

## 🧱 Architecture Overview

The solution is structured into **four main projects**, following Clean Architecture principles:

CleanArchitecture
│
├── CleanArchitecture.Api
├── CleanArchitecture.Application
├── CleanArchitecture.Domain
└── CleanArchitecture.Infrastructure

### 1️⃣ CleanArchitecture.Api

**Presentation layer**

- Entry point of the application
- Handles HTTP requests and responses
- Configures middleware and dependency injection
- No business logic

### 2️⃣ CleanArchitecture.Application

**Application layer**

- Contains application logic and use cases
- Implements **CQRS** using **MediatR**
- Defines commands and queries
- Depends only on the Domain layer

### 3️⃣ CleanArchitecture.Domain

**Core domain**

- Contains business entities
- Defines repository interfaces
- Completely independent from frameworks
- No dependency on EF Core or ASP.NET

### 4️⃣ CleanArchitecture.Infrastructure

**Infrastructure layer**

- Handles database access using **Entity Framework Core**
- Implements repositories
- Contains `DbContext` and migrations
- Depends on the Application layer

---

## 🔗 Dependency Flow

Api → Application → Domain
Api → Infrastructure → Application → Domain

Dependencies always point **inward**, never outward.

---

## 🗄️ Database & Persistence

- Entity Framework Core
- SQL Server
- Code-first migrations
- All database logic lives in the **Infrastructure** project

---

## 🧩 Key Concepts Used

- Clean Architecture
- Dependency Injection by layer
- Repository Pattern
- CQRS (Commands & Queries)
- MediatR
- Entity Framework Core
- ASP.NET 10 Web API

---

## ▶️ Getting Started

### Prerequisites

- .NET 10 SDK
- SQL Server
- Visual Studio / VS Code

### Setup Steps

1. Clone the repository:

```bash
git clone https://github.com/JeffryHermanto/CleanArchitecture.git
```

2. Open the solution in Visual Studio / VS Code

3. Update the connection string in `CleanArchitecture.Api/appsettings.json`

4. Apply the migrations:

```bash
# Windows PowerShell
Update-Database

# macOS Terminal
dotnet ef database update --project CleanArchitecture.Api
```

### Commands

```bash
# Windows PowerShell
Add-Migration DBInit

# Add migrations (macOS)
dotnet ef migrations add DbInit \
  --project CleanArchitecture.Infrastructure \
  --startup-project CleanArchitecture.Api
```
