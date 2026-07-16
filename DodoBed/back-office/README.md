#  Back-Office Administration System

This directory houses the core operational engine of the DodoBed manufacturing ecosystem. It consists of a high-performance backend Web API acting as the single source of truth, and a modern, reactive single-page application (SPA) for internal factory management.

---

##  Tech Stack & Architecture Highlights

The back-office showcases a strict separation of concerns.

###  Backend: `Manufacturing.Services` (.NET 10 Web API)
Designed using the **Onion (Clean) Architecture** pattern. This ensures the business domain remains completely decoupled from external frameworks, databases, and UI concerns, making the system highly testable and adaptable.

*   **No Database Lock-in:** The Core Domain is independent of EF Core or any specific database driver.
*   **Highly Testable:** Business logic can be unit-tested without mocking external infrastructure.
*   **Modern C#:** Leverages the latest performance and language features of **.NET 10**.

###  Frontend: `Manufacturing.UI` (Angular SPA)
A responsive administrator dashboard designed for real-time inventory and production tracking.

*   **Fine-Grained Reactivity:** Built using **Angular Signals** for state management, reducing boilerplate and optimizing change detection.
*   **Modern Package Management:** Managed via **`pnpm`** for space-efficient dependency resolution.


---

##  System Architecture

The interaction between the components follows a clean, decoupled boundary:


                  Manufacturing.UI      (Angular + Signals)
               ───────────┬───────────
                          │ HTTP Requests
                          ▼
    ┌───────────────────────────────────────────┐
    │          Manufacturing.Services           │  (Onion Architecture)
    │                                           │
    │   ┌───────────────────────────────────┐   │
    │   │              Apis                 │   │  ( Endpoints)
    │   │   ┌───────────────────────────┐   │   │
    │   │   │      Infrastructure       │   │   │  (EF Core / DB / External APIs)
    │   │   │   ┌───────────────────┐   │   │   │
    │   │   │   │    Application    │   │   │   │  (Use Cases / Interfaces)
    │   │   │   │   ┌───────────┐   │   │   │   │
    │   │   │   │   │   Core    │   │   │   │   │  (Entities / Domain Logic)
    │   │   │   │   │  Domain   │   │   │   │   │
    │   │   │   │   └───────────┘   │   │   │   │
    │   │   └───────────────────────────┘   │   │
    │   └───────────────────────────────────┘   │
    └───────────────────────────────────────────┘

### The Onion Layers Explained

| Layer | Responsibility | Allowed Dependencies |
| :--- | :--- | :--- |
| **1. Domain (Core)** | Enterprise business rules, entities, value objects, and repository interfaces. | *None (Zero external dependencies)* |
| **2. Application** | Use cases, orchestrators, DTOs, and mapping logic. | Core |
| **3. Infrastructure** | EF Core DbContext, migrations, file storage, and email services. | Application, Core |
| **4. Presentation** | Web API Endpoints (Minimal APIs), Controllers, Filters, and Swagger config. | Application, Infrastructure (DI registration only) |

---

##  Getting Started

### Prerequisites
*   [.NET 10 SDK](https://dotnet.microsoft.com/)
*   [Node.js](https://nodejs.org/) (LTS) & [pnpm](https://pnpm.io/) (`npm i -g pnpm`)

### Running the Backend (.NET 10)
1. Navigate to the service folder:
   ```bash
   cd Manufacturing.Services
   dotnet restore
    dotnet build
    ``` 
### Run the frontend (Angular SPA)
1. Navigate to the UI folder:
   ```bash
   cd Manufacturing.UI
   pnpm install
   pnpm start
   ```  
   