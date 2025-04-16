using OpenAI.Chat;

ChatClient client = new(
  model: "gpt-4o-mini",
  apiKey: Environment.GetEnvironmentVariable("OPENAI_API_KEY")
);

string prompt = "Summarize the following text: 'Italy is known for its rich history and beautiful cities. Visitors often enjoy exploring Rome, Florence and Venice...'";

await foreach (var message in client.CompleteChatStreamingAsync(prompt))
{
    foreach (var item in message.ContentUpdate)
    {
        Console.WriteLine(item.Text);
    }
}

