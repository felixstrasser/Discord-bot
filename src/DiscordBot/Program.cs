using System;
using System.Threading.Tasks;
using DSharpPlus;
namespace DiscordBot

{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--== The bot has started and is now active ==--");
            MainAsync().GetAwaiter().GetResult();
        }

        static async Task MainAsync()
        {
            var discord = new DiscordClient(new DiscordConfiguration()
        {
            // The token should be secret, so I obviously don't want it floating around on the internet. If you want to use this bot,
            // just create the file discordtoken.txt in the src folder and paste your token in there, nothing else.
            Token = System.IO.File.ReadAllText(@"discordtoken.txt"),
            TokenType = TokenType.Bot
        });
        
        // If you eant to add jokes to the bot, add them to the jokes.txt file. Each joke needs a new line.
        string[] allLines = System.IO.File.ReadAllLines(@"text_files/jokes.txt");
        Random rnd1 = new Random();

        discord.MessageCreated += async e =>
        {
            if (e.Message.Content.ToLower().StartsWith("tell joke")) 
            await e.Message.RespondAsync (allLines[rnd1.Next(allLines.Length)]);

            if (e.Message.Content.ToLower().StartsWith("tell credit")) 
            await e.Message.RespondAsync("Coding by Felix Strasser, jokes found by Lukas Manee, organisation by Danial Surmust. Written in C# using DSharpPlus. Stay creative, code on!");

            if (e.Message.Content.ToLower().StartsWith("tell rules"))
            await e.Message.RespondAsync(System.IO.File.ReadAllText(@"text_files/rules.txt"));

            if (e.Message.Content.ToLower().StartsWith("tell help")) 
            await e.Message.RespondAsync("Here are a few commands you can try: tell joke, tell rules, tell credit, tell nsfw. Have fun!");

            if (e.Message.Content.ToLower().StartsWith("boo!")) 
            await e.Message.RespondAsync("WHA! Wow, that was scary...");
        };

        await discord.ConnectAsync();
        await Task.Delay(-1);
        }
    }
}