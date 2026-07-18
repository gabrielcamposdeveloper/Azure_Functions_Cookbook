# ⚡ What are Azure Functions?

Azure Functions is a **serverless compute service** from Microsoft that enables you to run event-driven code on-demand without having to explicitly provision or manage infrastructure. 

Instead of building a whole web application to handle a single task, you write a "Function" — a small, focused piece of code that does exactly one job when a specific event happens.

---

## 🔑 Key Concepts

To master Azure Functions, you need to understand two main concepts: **Triggers** and **Bindings**.

### 1. Triggers (The "When")
A trigger is what causes a function to run. Every function must have exactly **one** trigger. 
* *Examples:* An HTTP request is made (`HttpTrigger`), a scheduled time is reached (`TimerTrigger`), or a new file is uploaded to Azure Storage (`BlobTrigger`).

### 2. Bindings (The "What")
Bindings are a declarative way to connect other resources to your function without writing boilerplate connection code.
* **Input Bindings:** Read data from a source (e.g., fetch a specific document from a database when the function starts).
* **Output Bindings:** Write data to a destination (e.g., save a message to a queue or a file to a storage container when the function finishes).

---

## 🌟 Why use Azure Functions?

* **No Infrastructure Management:** You focus solely on your C# code. The Azure platform handles the servers, operating systems, and network configuration.
* **Auto-Scaling:** If your function gets 1 request today and 100,000 requests tomorrow, Azure automatically provisions enough instances to handle the load, and scales back down to zero when the traffic stops.
* **Pay-as-you-go:** You are billed based on the number of executions and the memory consumed per second. If your code isn't running, you don't pay.

---

## 🛠️ The .NET 8 Isolated Worker Model

In this Cookbook, all examples are built using the **Isolated Worker Model**. 

Historically, .NET Azure Functions ran in the same process as the host runtime (In-Process model). Microsoft introduced the **Isolated Worker Model** to run your function app as a standard .NET console app in a separate worker process.

### Benefits of the Isolated Model:
1. **Full Control over Startup:** You use `Program.cs` and `HostBuilder` just like a standard ASP.NET Core or Worker service app.
2. **True Dependency Injection:** Registering your services, DbContexts, and HttpClients is native and straightforward.
3. **Custom Middleware:** You can write middleware to handle requests before and after they reach your function execution (great for auth, logging, or error handling).
4. **No Dependency Conflicts:** Because your code runs isolated from the Azure Functions host, you can use any NuGet package version without conflicting with the packages used by the Azure platform itself.