#  Front-Office Operations System

This directory houses the customer-facing and guest-relations engine of the DodoBed ecosystem. It is specifically designed to support the **front desk team** in managing customer interactions, processing orders, resolving scheduling conflicts, and streamlining customer requests.

---

## Architectural Vision: Multi-Client Ready

The `/front-office` directory is organized with scale in mind. By separating the client interfaces into their own distinct directories, we ensure the backend can power multiple front-office experiences (Web, Mobile, etc.) as the business grows.

        📁 front-office/
        ├── 📁 web/        # Current: .NET MVC Web App (Onion Architecture)
        └── 📁 mobile/     # Future: iOS/Android applications

#  The Web Portal: .NET MVC with Onion Architecture

The application inside the `/web` folder is built using **.NET 10 MVC**. To maintain clean boundaries and ensure long-term maintainability, the codebase adheres to the **Onion Architecture** pattern.

        [ Client Browser (HTML/CSS/JS) ]
                        │
                        ▼
            ┌────────────────────────┐
            │     Presentation       │  (MVC Controllers & Razor Views)
            │  ┌───────────────────┐ │
            │  │  Infrastructure   │ │  (Persistence, API Clients, Services)
            │  │  ┌─────────────┐  │ │
            │  │  │ Application │  │ │  (Front Desk Use Cases, Validation)
            │  │  │  ┌───────┐  │  │ │
            │  │  │  │ Core  │  │  │ │  (Order Entities, Conflict Policies)
            │  │  │  └───────┘  │  │ │
            │  └───────────────────┘ │
            └────────────────────────┘

### Core Front Desk Workflows Handled
1.  **Order Entry & Customization:** Streamlined forms for the front desk to configure bed sizes, materials, and delivery preferences alongside the customer.
2.  **Conflict Resolution:** Intelligent handling of production bottlenecks (e.g., inventory shortages, delayed shipping dates) with real-time alternative scheduling suggestions.
3.  **Customer Profiles & History:** A unified view of customer interactions, past orders, and custom preferences.

---

##  Onion Layer Responsibilities in MVC

While MVC is often implemented as a simple 3-tier system, applying Onion Architecture here ensures the app remains modular:

| Layer | Namespace/Folder | Responsibility |
| :--- | :--- | :--- |
| **Domain ** | `DodoBed.FrontOffice.Domain` | Core business models (e.g., `Order`, `Conflict`), state enums, and domain validation rules. |
| **Application** | `DodoBed.FrontOffice.Application` | Front-office specific operations, such as "Resolve Schedule Conflict" or "Apply Promo Code." |
| **Infrastructure** | `DodoBed.FrontOffice.Infrastructure` | Handlers for communicating with the Back-Office Web API, database persistence, and external messaging. |
| **Presentation** | `DodoBed.FrontOffice.Web` | Razor Views, ViewModels, Controllers, authentication middleware, and Tailwind CSS configuration. |

---

##  Getting Started (Web Portal)

### Prerequisites
*   [.NET 10 SDK](https://dotnet.microsoft.com/)

### Running the Web App
1. Navigate to the web folder:
   ```bash
   cd web
   dotnet restore
   dotnet watch --project DodoBed.FrontOffice.Web
   ```
