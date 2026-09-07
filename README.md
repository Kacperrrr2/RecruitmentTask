# Cat Fact Management API

A simple .NET 10 application built following Clean Architecture principles. It fetches random cat facts from an external service (`catfact.ninja`) and appends them to a `cat_facts.txt` file located in the project's root directory.

## Tech Stack & Architecture

* **Framework:** .NET 10
* **Architecture:** Clean Architecture (API, Application, Domain, Infrastructure)
* **API Documentation:** Scalar UI / OpenAPI
* **HTTP Client:** `IHttpClientFactory`

## Project Structure

```text
├── src/
│   ├── RecruitmentTask.Api/             # API Endpoints, OpenAPI Configuration
│   ├── RecruitmentTask.Application/     # Use Cases and Application Interfaces
│   ├── RecruitmentTask.Domain/          # Domain Entities and Repository Interfaces
│   └── RecruitmentTask.Infrastructure/  # Repository Implementations and HTTP Client
└── cat_facts.txt                        # Target file for saved facts
```

## Getting Started

### Prerequisites
* .NET 10.0 SDK

### Commands

1. Clone the repository:
   ```bash
   git clone <repository-url>
   cd <repository-folder>
   ```

2. Build and run the project:
   ```bash
   dotnet build
   dotnet run --project src/RecruitmentTask.Api
   ```

---

## Documentation & API

When running in the Development environment, the interactive **Scalar UI** documentation is available at:
👉 `http://localhost:5102/scalar/v1`

### Endpoints

* **`POST /api/cat-facts/fetch`**
    * **Description:** Fetches a new cat fact from the external API and appends it to the end of the `cat_facts.txt` file.
    * **Response:** `200 OK` on success / `502 Bad Gateway` if the external service fails.