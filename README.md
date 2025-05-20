# JobAdsAPI

This project is a RESTful API for managing job advertisements, built as a school assignment to practice backend development with **ASP.NET**, **C#**, and **SQL database** technologies.

---
## 📄 Project Overview
This API project is focused on **job advertisements** gathered from [Finn.no](https://www.finn.no), specifically targeting **Back-End** roles. To save time and stay focused, relevant data was extracted using simple AI prompts, filtering out only the necessary information.

Rather than aiming for a complete analysis of the job market, the project's main goal is to **demonstrate core backend development concepts**, such as:

- Building RESTful endpoints  
- Performing CRUD operations  
- Implementing database relationships  
- Using EF Core migrations
- Modeling real-world relationships in a database:
  - One-to-One (1:1)
  - One-to-Many (1:N)
  - Many-to-Many (N:N)

---
## 🛠 Technologies Used

- **ASP.NET Core MVC** (ControllerBase)
- **C# 13 / .NET 9**
- **SQLite** 
- **Entity Framework Core** 
- **Scalar** for API documentation and testing  
  *(used instead of Swagger, as Swagger is being removed from Microsoft templates)*
- **Package Manager Console** (for managing migrations)  

---
## 🔗 API Endpoints

| Method | Endpoint             | Description                   |
|--------|----------------------|-------------------------------|
| GET    | `/api/jobad`         | List all job ads              |
| GET    | `/api/jobad/{id}`    | Get a job ad by ID            |
| POST   | `/api/jobad`         | Create a new job ad           |
| PUT    | `/api/jobad/{id}`    | Update a job ad               |
| DELETE | `/api/jobad/{id}`    | Delete a job ad               |
| GET    | `/api/jobad/ping`    | Check database connectivity   |

---
## 📂 Project Structure

<details>
<summary><strong>▶️ Controllers</strong></summary>

    └── JobAdController.cs
</details>

<details>
<summary><strong>▶️ Data</strong></summary>

     └── JobAdDbContext.cs
</details>

<details>
<summary><strong>▶️ Migrations</strong></summary>

    ├── 20250519123448_NewMigration.cs  
    └── ...  
</details>

<details>
<summary><strong>▶️ Models</strong></summary>  

    ├── ExpierienceLevel.cs  
    ├── JobAd.cs  
    ├── JobAdDescription.cs  
    ├── Location.cs  
    ├── OtherSkill.cs  
    └── WorkType.cs  
</details>

<details>
<summary><strong>▶️ Rest</strong></summary>

    appsettings.json  
    Program.cs  
    (other project files, e.g., .csproj, README.md, etc.)  
</details>

---

## 🎥 Tutorial Sources

- [Creating API with DB & CRUD (Video 1)](https://www.youtube.com/watch?v=AKjG2tjI07U&t=3649s)  
- [Building Database Relations (Video 2)](https://www.youtube.com/watch?v=kMewc-TjO2s)


