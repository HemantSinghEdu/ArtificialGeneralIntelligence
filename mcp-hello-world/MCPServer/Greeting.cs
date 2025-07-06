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
