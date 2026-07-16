#  Platform & Cloud Infrastructure

This directory houses the **Infrastructure as Code (IaC)** configurations used to provision and manage the cloud resources for the entire DodoBed ecosystem. Written entirely in **Terraform**, it codifies every cloud resource backing the back-office, front-office, and supporting services—ensuring environments are reproducible, auditable, and version-controlled.

---

##  Structure

The Terraform configuration is split into two logical stages: a one-time **bootstrap** that prepares remote state management, and the **main** configuration that provisions the actual application infrastructure.

        📁 platform/
        ├── 📁 bootstrap/      # One-time setup: S3 backend + DynamoDB lock table
        └── 📁 main/           # Core infrastructure: modules, root config & environments
            ├── 📁 modules/    # Reusable Terraform modules (networking, compute, data, etc.)
            ├── main.tf        # Root module wiring the infrastructure together
            ├── active.hcl     # Configuration for the live, active environment
            └── recovery.hcl   # Configuration for the disaster-recovery environment

---

##  1. Bootstrap (`/bootstrap`)

Before any application infrastructure can be provisioned, Terraform needs a secure, shared place to store its state. The bootstrap configuration provisions exactly that—and only that:

*   **S3 Bucket:** Stores the Terraform state file remotely, with versioning enabled so state history can be recovered if something goes wrong.
*   **DynamoDB Table:** Provides state locking, preventing concurrent `terraform apply` runs from corrupting the state.

This stage is applied **once per AWS account/environment**, before the main configuration is ever run, and rarely changes afterward.

---

##  2. Main Configuration (`/main`)

With the remote backend in place, the main configuration provisions and manages the actual cloud resources for the DodoBed ecosystem (networking, compute, databases, and supporting services consumed by `/back-office` and `/front-office`).

*   **`modules/`** — Reusable, composable Terraform modules that encapsulate individual pieces of infrastructure. The root configuration wires these together rather than duplicating resource definitions per environment.
*   **`main.tf`** — The root module that ties everything together: declaring providers, invoking modules, and defining shared resources.
*   **`active.hcl`** — Environment-specific variables and backend configuration for the **active** (primary/production) environment.
*   **`recovery.hcl`** — Environment-specific variables and backend configuration for the **recovery** (disaster-recovery) environment, allowing infrastructure to be stood up independently in a failover scenario.

Keeping `active` and `recovery` as separate `.hcl` files—while sharing the same `modules/` and `main.tf`—ensures both environments stay structurally identical and only differ in the values that matter (region, sizing, naming, etc.).

---

##  Getting Started

### Prerequisites
*   [Terraform](https://developer.hashicorp.com/terraform)
*   AWS credentials with permission to manage the target resources

### 1. Bootstrap the backend (one-time)
```bash
cd bootstrap
terraform init
terraform apply
```

### 2. Provision the main infrastructure
```bash
cd main
terraform init -backend-config=active.hcl
terraform apply -var-file=active.hcl
```

To target the recovery environment instead, swap `active.hcl` for `recovery.hcl` in both commands.
