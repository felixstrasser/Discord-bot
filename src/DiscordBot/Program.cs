using System;
using System.Threading.Tasks;
using DSharpPlus;
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
            // The token should be secret so I obviously don't want it floating around on the internet. If you want to use this bot,
            // just create the file discordtoken.txt in the src folder and paste your token in there. Nothing else.
            Token = System.IO.File.ReadAllText(@"discordtoken.txt"),
            TokenType = TokenType.Bot
        });
        
        Random r = new Random();

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

            if (e.Message.Content.ToLower().StartsWith("tell credit")) 
            await e.Message.RespondAsync("Coding by Felix Strasser, jokes found by Lukas Manee, organisation by Danial Surmust. Written in C# using DSharpPlus. Stay creative, code on!");

            if (e.Message.Content.ToLower().StartsWith("tell rules"))
            await e.Message.RespondAsync("On this server, we want everyone to be happy and enjoy the testing. We understand that testing and debugging can be fustrating, but please don't get too offensive. If you see something that shouldn't be here, contact an admin. Also, if you want to test anything NSFW, please contact us and we will make your test channel NSFW. Thanks for following the rules and have fun experimenting!");

            if (e.Message.Content.ToLower().StartsWith("tell nsfw")) 
            await e.Message.RespondAsync("https://youtu.be/Dh-CW22axyY");

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