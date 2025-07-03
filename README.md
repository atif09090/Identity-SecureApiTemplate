# 🔐 Identity_SecureApiTemplate

A secure, scalable ASP.NET Core Web API template using **JWT Authentication**, **ASP.NET Core Identity**, and **Entity Framework Core** on **.NET 8**.

This project provides a plug-and-play base for building secure REST APIs with support for user registration, login, and protected endpoints.

---

## 🚀 Features

- ✅ **ASP.NET Core Identity** with custom `ApplicationUser`
- 🔐 **JWT Bearer Authentication**
- 🧩 Modular service structure
- ⚙️ **EF Core** with SQL Server
- 🔄 Swagger/OpenAPI via `Swashbuckle.AspNetCore`
- 🧪 User login & registration endpoints
- 🌐 CORS configuration
- 📂 Clean, scalable project layout

---

## 📁 Folder Structure

```plaintext
Identity-SecureApiTemplate/
│
├── Configuration/
│ └── CorsOptions.cs
│
├── Controllers/
│ ├── AuthController.cs
│ └── SecureDataController.cs
│
├── Data/
│ ├── ApplicationDbContext.cs
│ └── ApplicationUser.cs
│
├── Migrations/ # EF Core Migrations
│
├── Models/
│ ├── JwtSettings.cs
│ ├── LoginRequest.cs
│ └── RegisterRequest.cs
│
├── Services/
│ └── JwtTokenService.cs
│
├── appsettings.json
├── launchSettings.json
├── Program.cs
└── Identity-SecureApiTemplate.csproj
