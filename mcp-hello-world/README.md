# Creating a simple hello world MCP server

Commands:
1. Create new folder for your project. Open Terminal and execute below command
    ```batch 
        md mcp-hello-world
        cd mcp-hello-world
    ```
2. Create new dotnet console project
    ```batch 
        dotnet new console -n MCPServer
        cd MCPServer
    ```
3. Add MCP package
     ```batch 
        dotnet add package ModelContextProtocol --prerelease
     ```
4. Add Microsoft Extensions Hosting package
    ```batch 
        dotnet add package Microsoft.Extensions.Hosting
    ```
5. Open Program.cs file and add the below  code snippet. Here, we have setup our MCP server.
    ```csharp
        using Microsoft.Extensions.DependencyInjection;
        using Microsoft.Extensions.Hosting;
        using ModelContextProtocol;
        using ModelContextProtocol.Server;
        using System.ComponentModel;

        var builder = Host.CreateEmptyApplicationBuilder(settings: null);

        builder.Services
            .AddMcpServer()
            .WithStdioServerTransport()
            .WithToolsFromAssembly();

        var app = builder.Build();

        await app.RunAsync();
    ```
6. Add a new class file named Greeting.cs, and add a simple Greeting class with an endpoint GetGreeting() to get a greeting message based on name and city
    ```csharp
        using Microsoft.Extensions.Hosting;
        using ModelContextProtocol;
        using ModelContextProtocol.Server;
        using System.ComponentModel;

        namespace MyMcpServer;

        [McpServerToolType]
        public static class Greeting
        {
            [McpServerTool, Description("Get a greeting message for a given name and city")]
            public static string GetGreeting(string name, string city)
            {
                return $"Hello {name}! Welcome to {city}!";
            }
        }

    ```
7. Build the project
    ```bash
    dotnet build
    ```

8. Ensure that node is installed on your system, and that you are able to run npx tool from your terminal. In case it is giving UnauthorizedAccess error, just execute below command in terminal to allow npx to execute.
```bash
Set-ExecutionPolicy -Scope CurrentUser -ExecutionPolicy RemoteSigned
```
If needed, you can revert this later by executing below command,
```bash
Set-ExecutionPolicy -Scope CurrentUser -ExecutionPolicy Restricted
```

9. Execute below npx command to run the mcp inspector tool on our dotnet application
```bash
npx @modelcontextprotocol/inspector dotnet run
```
If the inspector is not already installed, it will ask for confirmation to install, go ahead with that.

10. Once the inpsector is up and running, you may see a message like below
```
MCP Inspector is up and running at http://127.0.0.1:6274
```
Just ctrl+click on the link to open the inspector tool

11. In the VSCode, you would have also received a Session token, just copy that token and paste it in the Inspector --> Configuration --> Proxy Session Token

12. Also ensure that the Command field has the value `dotnet run`

12. Finally, click on the Connect button on the Inspector tool page. If the connection is successful, you will see Tools section with "List Tools" option

13. Click on the List Tools option. You should see "get_greeting" as an option. Click on it.

14. Provide the name and city values and click on "Run Tool" button. You should see a greeting message.
