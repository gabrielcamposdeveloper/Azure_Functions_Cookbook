# 🚀 Azure Functions Cookbook - Version 2.0

<p align="center">
  <img src="https://img.shields.io/badge/.NET%208-512BD4?logo=dotnet&logoColor=white" alt=".NET 8" />
  <img src="https://img.shields.io/badge/Azure%20Functions-0062AD?logo=microsoftazure&logoColor=white" alt="Azure Functions" />
  <img src="https://img.shields.io/badge/License-MIT-success" alt="MIT License" />
  <img src="https://img.shields.io/badge/PRs-Welcome-brightgreen" alt="PRs Welcome" />
</p>

> ⚠️ **IMPORTANT:** The current active development and updated .NET 8 Isolated Worker examples are on the `AzureFuncitionsCookbook-v2` branch. Please make sure you are using this branch!

> A community-driven collection of practical **Azure Functions** examples built with **.NET 8 Isolated Worker**.

This repository was created to help developers learn Azure Functions through practical, production-inspired examples. Whether you're just getting started or looking for a quick reference, you'll find organized and ready-to-run samples covering the most common Azure Functions scenarios.

---

## 📑 Table of Contents

- [⚡ What are Azure Functions?](#-what-are-azure-functions)
- [🚀 Getting Started (Local Setup)](#-getting-started-local-setup)
- [📚 Examples](#-examples)
- [🎯 Goals](#-goals)
- [🛠️ Technologies](#️-technologies)
- [📂 Project Structure](#-project-structure)
- [🚀 Roadmap](#-roadmap)
- [🤝 Contributing](#-contributing)
- [📋 Looking for your first contribution?](#-looking-for-your-first-contribution)
- [⭐ Support the Project](#-support-the-project)
- [👨‍💻 Author](#-author)
- [📄 License](#-license)

---

## ⚡ What are Azure Functions?

New to Serverless or the Isolated Worker Model? 

Azure Functions is a serverless compute service that enables you to run event-driven code on-demand without having to explicitly provision or manage infrastructure. 

👉 **[Learn the core concepts and why we use the .NET 8 Isolated Worker Model in our Wiki!](./Wiki/What-Are-Azure-Functions.md)**

---

## 🚀 Getting Started (Local Setup)

Want to run these examples on your machine? It's easier than you think! 

We have prepared a complete, step-by-step guide showing how to set up your local environment, configure the storage emulator (Azurite), and easily test the functions using our helper console apps.

👉 **[Check out the Local Setup Guide in our Wiki!](./Wiki/Local-Setup.md)**  
👉 **[Check out the Complete Blob Storage Pipeline Guide!](./Wiki/Blob-Storage-Pipeline.md)**  

---

## 📚 Examples

### 🎯 Triggers
- ✅ HTTP Trigger
- ✅ Timer Trigger
- ✅ Azure Storage Queue Trigger
- ✅ Blob Storage Trigger
- ✅ Azure Service Bus Trigger
- ✅ Event Hub Trigger
- ✅ Event Grid Trigger
- ✅ Cosmos DB Trigger
- ✅ Kafka Trigger
- 🚧 Durable Functions

### 🔗 Bindings (Input & Output)
- ✅ Blob Storage (Input & Output Bindings)
- ✅ Queue Storage (Output Binding)

### 🛠️ Helper Apps (Event Producers)
- ✅ **BlobUploader**: A console app to inject test files into Blob Storage.
- ✅ **QueueUploader**: A console app to send test messages to Queue Storage.

---

## 🎯 Goals

This project aims to provide high-quality Azure Functions examples for:

- Students
- Junior Developers
- Senior Developers
- Azure enthusiasts
- Developers preparing for technical interviews

Each example focuses on:

- Clean Code
- Best Practices
- Real-world Scenarios
- Easy to Understand
- Ready-to-run Samples

---

## 🛠️ Technologies

- .NET 8 (Isolated Worker Model)
- Azure Storage (Blob & Queue)
- Azure Service Bus
- Azure Event Hub
- Azure Event Grid
- Azure Cosmos DB
- Apache Kafka
- Durable Functions

---

## 📂 Project Structure

```text
📦 Workspace
│
├── 📂 AzureFunctionsCookbook (Main Azure Functions API)
│   ├── 📂 Bindings
│   │   ├── 📂 Blob
│   │   └── 📂 Queue
│   └── 📂 Triggers
│       ├── 📂 Blob
│       ├── 📂 CosmosDB
│       ├── 📂 Durable
│       ├── 📂 EventGrid
│       ├── 📂 EventHub
│       ├── 📂 Http
│       ├── 📂 Kafka
│       ├── 📂 Queue
│       ├── 📂 ServiceBus
│       └── 📂 Timer
│
├── 📂 BlobUploader (Console App for Blob testing)
├── 📂 QueueUploader (Console App for Queue testing)
└── 📂 Wiki (Documentation and Guides)

```

---

## 🚀 Roadmap

Upcoming implementations and examples:

* Dependency Injection
* Advanced Configuration
* Logging Best Practices
* Security & Authentication
* Unit and Integration Testing
* CI/CD Pipelines (GitHub Actions & Azure DevOps)
* Monitoring with Application Insights
* Real-world Scenarios (End-to-End integrations)

---

## 🤝 Contributing

Contributions are always welcome!

If you'd like to contribute to this repository, feel free to browse the **Issues** section and pick one that interests you.

You can contribute by:

* Adding new Azure Functions examples
* Improving existing examples
* Writing documentation
* Fixing bugs
* Improving code quality
* Suggesting new ideas

If you're working on an issue, simply leave a comment so other contributors know it's already in progress. Every contribution, regardless of its size, is greatly appreciated.

---

## 📋 Looking for your first contribution?

Check out the **Issues** page!

Many issues are suitable for first-time contributors and are a great way to get involved with the project. Don't see something you'd like to work on? Feel free to open a new issue with your suggestion!

---

## ⭐ Support the Project

If this repository helped you, please consider giving it a ⭐.

Your support helps the project reach more developers and encourages future improvements.

---

## 👨‍💻 Author

Created and maintained by **Gabriel Campos**

🐙 GitHub: **[gabrielcamposdeveloper](https://github.com/gabrielcamposdeveloper)**

Feel free to explore my other repositories and connect with me.

---
```

```
