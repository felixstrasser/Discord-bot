using System;
using System.Threading.Tasks;
using DSharpPlus;
using DSharpPlus.CommandsNext;
namespace DiscordBot
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("The bot has started and is now active");
            MainAsync().GetAwaiter().GetResult();
        }

        static async Task MainAsync()
        {
            var discord = new DiscordClient(new DiscordConfiguration()
        {
            Token = "Nzc4NTM0ODgwNTQ3NzAwNzQz.X7TZHA.OIH0vi8zWw-rR4yLxyZ0_PUmEfs",
            TokenType = TokenType.Bot
        });

        //code zwischen mir...
        
        Random r = new Random();
        
        //you can add as many jokes as you want!
        string[] words =  { "What’s the best thing about Switzerland? I don’t know, but the flag is a big plus.",
                            "What do you call a pig that does Karate? A pork chop.",
                            "Today at the bank, an old lady asked me to check her balance. So I pushed her over.",
                            "Why did Shakespeare only write in pen? Pencils confused him. 2B or nor 2B?",
                            "I tried phone sex once. But the holes were too small.",
                            "What do you call a dog with no legs? It doesn’t matter what you call him, he isn’t coming.",
                            "I asked my cat what’s two minus two? He said nothing.",
                            "What do you call a boomerang that won’t come back? A stick.",
                            "My wife told me to take the spider out instead of killing him. Went out. Had a few drinks. Nice guy. He’s a web designer.",
                            "What did the calculator say to the maths student? You can count on me.",
                            "Why do fish live in salt water? Because pepper makes them sneeze!",
                            "What do you call an old snowman? Water!",
                            "Why are ghosts such bad liars? Because you can see right through them.",
                            "Why is Santa always so happy? He likes to live in the present!",
                            "How do you catch a whole school of fish? With bookworms.",
                            "What did one plate say to the other plate? Dinner’s on me!",
                            "Why did the cookie go to the hospital? Because he felt crummy.",
                            "What do you call a cow that eats your grass? A lawn moo-er.",
                            "What is a robot’s favorite snack? Computer chips.",
                            "Why did the banana go to the hospital? He was peeling really bad.",
                            "Why did Mickey Mouse take a trip into space? He was looking for his buddy Pluto.",
                            "Why did the student eat his homework? Because his teacher told him it was a piece of cake!"};

        discord.MessageCreated += async e =>
        {
            if (e.Message.Content.ToLower().StartsWith("tell joke")) 
            await e.Message.RespondAsync(words[r.Next(0, words.Length)]);
        };

        discord.MessageCreated += async e =>
        {
            if (e.Message.Content.ToLower().StartsWith("tell credit")) 
            await e.Message.RespondAsync("Coding by Felix Strasser, jokes found by Lukas Manee, Organisation by Danial Surmust. Written in C# using DSharpPlus. Stay creative, code on!");
        };

        discord.MessageCreated += async e =>
        {
            if (e.Message.Content.ToLower().StartsWith("tell horny")) 
            await e.Message.RespondAsync("*BONK* go to horny jail!");
        };

        //...und mir :D

        await discord.ConnectAsync();
        await Task.Delay(-1);
        }
    }
}