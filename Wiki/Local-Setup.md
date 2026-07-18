Aqui está o segundo arquivo, o **`Local-Setup.md`**.

Você pode criar a pasta `/Wiki` na raiz do seu projeto (caso ainda não exista) e salvar este conteúdo dentro dela com o nome `Local-Setup.md`.

```markdown
# 🛠️ Local Setup & Running the Project

Running Azure Functions locally should be simple! We've configured this project to run seamlessly using the local storage emulator, without needing to create real resources on the Azure Portal right away.

Follow these steps to get your environment up and running.

## 1️⃣ Prerequisites

Before you begin, make sure you have the following installed:

1. **[.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)**
2. **[Azure Functions Core Tools v4](https://learn.microsoft.com/en-us/azure/azure-functions/functions-run-local)**
   * *Tip:* If you have Node.js installed, just run: `npm install -g azure-functions-core-tools@4 --unsafe-perm true`
3. **Azurite** (Local Azure Storage Emulator)
   * *Tip:* You can install it as a VS Code extension, or run it via Docker: `docker run -p 10000:10000 -p 10001:10001 -p 10002:10002 mcr.microsoft.com/azure-storage/azurite`

## 2️⃣ Clone and Configure

Make sure you are on the correct branch:

```bash
git clone [https://github.com/gabrielcamposdeveloper/AzureFunctionsCookbook.git](https://github.com/gabrielcamposdeveloper/AzureFunctionsCookbook.git)
cd AzureFunctionsCookbook
git checkout AzureFuncitionsCookbook-v2

```

Navigate to the main project folder (`/AzureFunctionsCookbook`) and ensure you have a `local.settings.json` file. It should look exactly like this to connect to your local Azurite emulator:

```json
{
  "IsEncrypted": false,
  "Values": {
    "AzureWebJobsStorage": "UseDevelopmentStorage=true",
    "FUNCTIONS_WORKER_RUNTIME": "dotnet-isolated"
  }
}

```

> **💡 Cookbook Gotcha:** Because this repository contains multiple examples (Cosmos DB, Service Bus, Kafka, etc.), the Functions host will try to find connection strings for ALL of them when it starts. If you only want to test a specific trigger (like the Blob Trigger), simply comment out the `[Function("...")]` attribute in the files you are not currently testing to avoid startup errors.

## 3️⃣ Start the Application

1. **Start Azurite**: Ensure your Azurite emulator is running on port 10000.
2. Open a terminal in the main project folder (`/AzureFunctionsCookbook`).
3. Run the following command:

```bash
func start

```

If everything is correct, you will see the Azure Functions ASCII logo and a list of your active HTTP routes and Triggers in the terminal. **Leave this terminal open!**

---

## 🚀 Testing the Examples (The Easy Way)

To make testing easier, we included a helper Console App called **`BlobUploader`** in the repository. It automatically generates and uploads files to your local Azurite emulator to trigger the Azure Functions.

### Testing the Blob Trigger & Bindings:

With your Azure Functions app running in Terminal 1, open a **second terminal** and navigate to the `BlobUploader` project:

```bash
cd BlobUploader
dotnet run

```

**What happens next?**

1. **The Trigger:** Look at Terminal 1. You will instantly see a beautiful log showing that the `BlobTriggerExample` caught the file `sample.txt` being uploaded to the `uploads` container.
2. **The Binding:** Open your browser and navigate to:
`http://localhost:7071/api/blob-input/sample.txt`
You will see the message `"Hello Azure Functions!"` on your screen. The `BlobInputBindingExample` successfully read the file from the `documents` container and returned it as an HTTP response.

Happy coding! 🎉

```

```