﻿using OllamaSharp;

// These variables are needed to access the Ollama Models
Uri modelEndpoint = new("http://localhost:11434");
string modelName = "deepseek-r1:1.5b";

// Initialize the chat client using OllamaChatClient - everything else the same!
IChatClient chatClient = new OllamaApiClient(modelEndpoint, modelName);

string question = "If I have 3 apples and eat 2, how many bananas do I have?";
var response = chatClient.GetStreamingResponseAsync(question);

Console.WriteLine($">>> User: {question}");
Console.Write(">>>");
Console.WriteLine(">>> DeepSeek (might be a while): ");

await foreach (var item in response)
{
    Console.Write(item);
}