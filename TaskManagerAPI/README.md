# Task Manager API 📝

## Overview
A lightweight, foundational RESTful API built to handle core CRUD (Create, Read, Update, Delete) operations. This project demonstrates the standard ASP.NET Core request pipeline and basic database integration using Entity Framework Core.

## Technical Architecture
* **Framework:** .NET 8 / ASP.NET Core Web API
* **Language:** C#
* **Database:** SQLite
* **ORM:** Entity Framework Core
* **Documentation:** Swagger / OpenAPI

## Key Features
* **Full CRUD Functionality:** Endpoints to retrieve all tasks, create new tasks, update existing tasks, and delete tasks.
* **Asynchronous Operations:** Utilizes `async/await` patterns with Entity Framework Core (`ToListAsync`, `SaveChangesAsync`) to ensure the server remains responsive under load.
* **Data Validation:** Implements data annotations (e.g., `[Required]`, `[MaxLength]`) at the model level to automatically validate incoming HTTP requests and return `400 Bad Request` when necessary.

## Getting Started

### Prerequisites
* [.NET 8 SDK](https://dotnet.microsoft.com/download)
* EF Core CLI Tools (`dotnet tool install --global dotnet-ef`)

### Installation & Setup
1. Clone the repository:
   ```bash
   git clone <your-github-repo-url>
