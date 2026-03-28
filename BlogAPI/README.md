# Relational Blog API 📚

## Overview
A production-simulated RESTful API demonstrating relational database architecture and secure data transfer patterns. This project manages a One-to-Many relationship between Authors and Posts, focusing on clean architecture, optimized database queries, and preventing common API vulnerabilities like circular references and over-posting.

## Technical Stack
* **Framework:** .NET 8 / ASP.NET Core Web API
* **Language:** C#
* **Database:** SQLite
* **ORM:** Entity Framework (EF) Core
* **Documentation:** Swagger / OpenAPI

## Architectural Decisions & Key Features

### 1. Relational Database Mapping
Configured primary and foreign key relationships (One-to-Many) between `Author` and `Post` entities using Entity Framework Core. The database schema is entirely code-first, utilizing EF Core Migrations to generate and manage the SQLite tables.

### 2. Data Transfer Object (DTO) Pattern
Implemented strict DTOs (`PostCreateDto`, `PostResponseDto`, `AuthorCreateDto`, etc.) to decouple the database models from the API presentation layer. 
* **Security:** Prevents over-posting vulnerabilities by only accepting specific fields from the client.
* **Stability:** Flattens complex database relationships to prevent infinite JSON serialization loops.
* **Efficiency:** Limits the payload size by returning only necessary data to the client.

### 3. Eager Loading & Query Optimization
Utilized asynchronous LINQ and EF Core's `.Include()` method to optimize database queries. This forces SQL `INNER JOIN`s behind the scenes, allowing the API to fetch related Author and Post data efficiently in a single database round-trip rather than falling back on performance-heavy lazy loading.

### 4. API Endpoint Structure
* `POST /api/Authors` - Accepts an `AuthorCreateDto` and provisions a new author.
* `POST /api/Posts` - Accepts a `PostCreateDto` (containing an `AuthorId`) and establishes the foreign key relationship.
* `GET /api/Posts` - Returns a list of `PostResponseDto` objects, mapping the relational data into a flat, client-friendly structure.