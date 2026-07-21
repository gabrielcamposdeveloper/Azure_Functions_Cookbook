# 🌊 Azure Blob Storage Pipeline

In this Cookbook, we don't just show isolated examples. We connected **Triggers**, **Input Bindings**, and **Output Bindings** to create a complete, real-world data processing pipeline using the **.NET 8 Isolated Worker Model**.

This guide explains how the Blob Storage examples work together to process a document automatically.

---

## 🧠 How It Works (The Concept)

Imagine a system that receives raw documents, processes them, and makes the final version available for users to download. Our pipeline does exactly that using three steps:

1. **The Entry Point:** A file is uploaded to an `uploads` container. (We can do this via our helper Console App or via an HTTP POST request).
2. **The Processor (Trigger + Output):** An Azure Function automatically wakes up when it detects the new file in the `uploads` container. It reads the text, converts it to UPPERCASE, adds a signature, and automatically saves the new file into a `documents` container.
3. **The Reader (Input):** A user accesses a specific URL. The Azure Function uses an Input Binding to quickly fetch the processed file from the `documents` container and displays it in the browser.

---

## ⚙️ Technical Deep Dive

Here is how the magic happens under the hood in our code:

### 1. `BlobTriggerExample` (The Engine)
This function uses a hybrid approach. It acts as both the listener and the writer.
* **The Trigger:** `[BlobTrigger("uploads/{name}")] string fileContent`
  Instead of using a `Stream` (which can cause JSON deserialization errors in the Isolated Model for plain text), we ask the Azure framework to deliver the file content directly as a `string`.
* **The Output Binding:** `[BlobOutput("documents/{name}")]`
  By placing this attribute on the method itself, whatever `string` the method returns is automatically saved as a new file in the `documents` container. No Azure SDK boilerplate required!

### 2. `BlobInputBindingExample` (The API)
This is an HTTP Trigger that fetches data.
* **The Input Binding:** `[BlobInput("documents/{fileName}")] string? fileContent`
  When a user hits the route `/api/blob-input/pipeline-test.txt`, Azure takes the `{fileName}` from the URL, goes to the `documents` container, grabs the file, and injects its content into the `fileContent` variable before the first line of code even runs.

### 3. `BlobOutputBindingExample` (Alternative Entry)
This shows the **Multiple Output** pattern. Because an HTTP trigger needs to return an HTTP Response *and* we want to save a Blob, we return a custom class (`BlobOutputResponse`). This class tells Azure exactly what goes to the browser and what goes to the Storage Account.

---

## 🚀 Step-by-Step: How to Run the Pipeline

Follow these steps to see the full cycle in action on your local machine.

### Prerequisites
Make sure your **Azurite** emulator is running (listening on port 10000).

### Step 1: Start the Azure Functions Host
Open a terminal in the root of your `AzureFunctionsCookbook` project and run:
```bash
func start

```

Wait until the ASCII logo appears and the HTTP routes are listed. **Leave this terminal open.**

### Step 2: Inject the File

Open a **second terminal**, navigate to the `BlobUploader` console app folder, and run it:

```bash
cd BlobUploader
dotnet run

```

*What happens:* The console app connects to your local Azurite, creates the `uploads` and `documents` containers (if they don't exist), and uploads a file named `pipeline-test.txt` with lowercase text into the `uploads` container.

### Step 3: Watch the Trigger React

Go back to your **first terminal** (where `func start` is running). You should immediately see logs like this:

```text
info: AzureFunctionsCookbook.BlobTriggerExample[0]
      ⚙️ [TRIGGER DISPARADO] Lendo arquivo: pipeline-test.txt
info: AzureFunctionsCookbook.BlobTriggerExample[0]
      ✅ Processamento concluído. Salvando na pasta 'documents'.

```

*What happened:* The function detected the file, converted the text to uppercase, and saved the result in the `documents` container.

### Step 4: Consume the Processed File

Open your web browser and navigate to the Input Binding route:

```text
http://localhost:7071/api/blob-input/pipeline-test.txt

```

*What happens:* You will see the final result displayed in your browser:

> THIS TEXT STARTED IN LOWERCASE FROM THE UPLOADER!
> [PROCESSADO COM SUCESSO PELO BLOB TRIGGER!]

🎉 **Congratulations!** You just executed a complete, event-driven serverless pipeline locally.
