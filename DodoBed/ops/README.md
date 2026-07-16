#  Operations & Developer Tooling

This directory houses the **automation scripts, database utilities, and developer tools** used to manage, maintain, and run the DodoBed ecosystem. Rather than executing repetitive manual tasks by hand, Waney93 uses these scripts to streamline developer workflows, manage cloud assets, and orchestrate data migrations.

`/ops` is a **console TypeScript application**—a single, scriptable CLI rather than a collection of ad-hoc shell scripts—so tooling stays type-safe, testable, and consistent with the rest of the DodoBed stack.

---

##  Why a TypeScript Console App

*   **Type Safety:** Scripts that touch databases, cloud resources, and environment configuration benefit from the same compile-time guarantees as the rest of the codebase.
*   **Consistency:** One runtime, one dependency set, one way to run a task—`npm run <script>`—instead of a mix of bash, PowerShell, and one-off Node scripts.
*   **Discoverability:** New scripts register as commands in the same CLI, so the whole team can find and run them without digging through scattered files.

---

##  What Lives Here

*   **Database Utilities:** Seeding, backups, and migrations across the back-office and front-office data stores.
*   **Automation Scripts:** Repetitive maintenance tasks (cleanup jobs, scheduled housekeeping, environment resets) that would otherwise be done manually.
*   **Cloud Asset Management:** Helper scripts that complement the Terraform configurations in [`/platform`](../platform/README.md)—e.g. seeding remote resources, rotating secrets, or syncing configuration.
*   **Developer Tools:** Local setup and workflow scripts that get a new environment up and running quickly.

---

##  Getting Started

### Prerequisites
*   [Node.js](https://nodejs.org/) (LTS)

### Running a Script
```bash
cd ops/<script-name>
npm install
npm run 
```
possible scripts include:
*   `sync-assets-to-s3` — Syncs local assets to the S3 bucket used by the front-office application.
*   `smoke-test-endpoints` — Runs a quick check against the back-office and front-office endpoints to ensure they are reachable and responding as expected.

