#  System Design & Workflow Diagrams

This directory houses the design artifacts that document how DodoBed is built and how it behaves—produced *before* writing code, so architecture and business logic are agreed upon rather than discovered along the way.

---

##  Structure

        📁 diagrams/
        ├── 📁 system-architecture/   # Topology of services, databases & network boundaries
        └── 📁 business-workflows/    # Order-to-manufacturing data flow

---

##  1. System Architecture (`/system-architecture`)

High-level topology diagrams describing how the pieces of the DodoBed ecosystem fit together:

*   **Services:** How the back-office (`Manufacturing.Services`, `Manufacturing.UI`) and front-office (Web, Mobile) applications communicate.
*   **Databases:** Where data lives for each service and how it's isolated.
*   **Network Boundaries:** Trust zones, public vs. internal endpoints, and how traffic crosses into the infrastructure provisioned in [`/platform`](../platform/README.md).

##  2. Business Workflows (`/business-workflows`)

Diagrams that trace how a request actually moves through the system, end to end:

*   **Order to Manufacturing Floor:** How a customer order placed through the front-office is validated, transformed, and handed off to the back-office, ultimately becoming a task on the factory floor.
*   **Exception Paths:** How conflicts—inventory shortages, delayed shipments—are surfaced back to the front desk for resolution.

---

Diagrams here are meant to be the source of truth for *why* the codebase in [`/back-office`](../back-office/README.md) and [`/front-office`](../front-office/README.md) is shaped the way it is—consult them before making structural changes to either.
