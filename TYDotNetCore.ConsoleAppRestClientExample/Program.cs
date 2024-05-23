// See https://aka.ms/new-console-template for more information
using TYDotNetCore.ConsoleAppRestClientExample;

Console.WriteLine("Hello, World!");

RestClientExample restClientExample = new RestClientExample();
await restClientExample.AsyncRun();

Console.ReadLine();