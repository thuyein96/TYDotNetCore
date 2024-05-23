// See https://aka.ms/new-console-template for more information
using Newtonsoft.Json;
using System.Text.Json.Serialization;
using TYDotNetCore.ConsoleAppHttpClientExample;

Console.WriteLine("Hello, World!");

HttpClientExample httpClient = new HttpClientExample();
await httpClient.AsyncRun();

Console.ReadLine();
