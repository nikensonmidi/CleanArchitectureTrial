#  DodoBed Enterprise Ecosystem

> **A Production-Grade Reference Architecture by [Waney93](https://waney93.com/)**
> 
> This repository serves as a live, end-to-end showcase of Waney93's consulting capabilities—spanning system architecture, enterprise software engineering, DevOps, and cloud infrastructure.

---

##  Project Overview

DodoBed is designed to demonstrate how Waney93 solves complex business problems using modern technology stacks. Instead of isolated demo projects, DodoBed integrates back-office logistics, customer-facing interfaces, automated infrastructure, and clear business workflows into a cohesive enterprise system.

---

##  System Architecture & Workflows

Before writing code, we design for scale. You can explore our system designs in the `/diagrams` directory:
*   **System Architecture:** High-level topology of services, databases, and network boundaries.
*   **Business Workflows:** Mapping out how data flows from a customer order to the manufacturing floor.

---

##  Repository Structure

This repository is split into distinct logical boundaries, reflecting a real-world enterprise deployment:

###  1. Back-Office (`/back-office`)
The engine of the manufacturing process.
*   **`Manufacturing.Services` (Web API):** A robust backend managing inventory, assembly lines, and order fulfillment.
*   **`Manufacturing.UI` (Web UI):** An administrative dashboard for factory floor supervisors and operations teams.

###  2. Front-Office (`/front-office`)
The customer-facing digital storefront.
*   **Web (`.NET MVC`):** A responsive, server-rendered web application where customers customize and order their beds.
*   **Mobile (iOS):** *Coming Soon* — A native companion app for tracking deliveries and managing customer accounts.

###  3. Platform & Cloud (`/platform`)
*   **Terraform:** Infrastructure as Code (IaC) configurations to provision secure, repeatable, and autoscaling cloud resources.

###  4. Operations (`/ops`)
*   **Scripts:** Automation scripts handling database maintenance.
