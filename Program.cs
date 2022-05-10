using DSharpPlus;
using DSharpPlus.Entities;
using DSharpPlus.CommandsNext;
using DSharpPlus.EventArgs;
using System.IO;
using System.Reflection;
using System.Text;
using Newtonsoft.Json;

class Program{

    static void Main(string[] args){

        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("Bot is up and running!");
        Console.ResetColor();

        MainAsync().GetAwaiter().GetResult();
    }

    // the actaul main method of the bot
    internal static async Task MainAsync(){

        // string tokenPath = @"/home/alex/cshaprbot/tokenconfig/token.txt";
        // List<string> lines = new List<string>();
        // string token = "";

        // lines = File.ReadAllLines(tokenPath).ToList();

        // foreach(string line){}

        // creating discord object

        var json = string.Empty;
        using (var fs = File.OpenRead("config.json"))
        using (var sr = new StreamReader(fs, new UTF8Encoding(false)))
            json = await sr.ReadToEndAsync().ConfigureAwait(false);

        var configJson = JsonConvert.DeserializeObject<ConfigJson>(json);

        var discord = new DiscordClient(new DiscordConfiguration(){
            Token = configJson.Token,
            TokenType = TokenType.Bot
        });
        
        var commands = discord.UseCommandsNext(new CommandsNextConfiguration(){
            StringPrefixes = new[] { "?" }
        });

        // commands.RegisterCommands<Ping>();
        commands.RegisterCommands<greet>();
        commands.RegisterCommands<UserInfo>();
        commands.RegisterCommands<Avv>();
        commands.RegisterCommands<Mute>();
        commands.RegisterCommands<Unmute>();
        commands.RegisterCommands<Kick>();
        commands.RegisterCommands<Ban>();
        commands.RegisterCommands<Unban>();
        commands.RegisterCommands<Poll>();
        commands.RegisterCommands<DmMember>();
        commands.RegisterCommands<HelpCommand>();
        // commands.RegisterCommands<HelpCommand>();
        commands.RegisterCommands<Nick>();

        discord.MessageCreated += async (s, e) => {
            if(e.Message.Content.Contains("cri")){
                await e.Message.RespondAsync("Be happi!");
            }
        };

        discord.MessageCreated += async (s, e) => {
            if(e.Message.Content.StartsWith("?ping")){
                await e.Message.RespondAsync($"Ping! {discord.Ping}ms");
            }
        };

        discord.MessageCreated += async (s, e) => {
            if(e.Message.Content.Contains("andza") && e.Author != discord.CurrentUser){
                await e.Message.RespondAsync("Andza? Mislis Andza Trandza HAHAHHAHHA");
            }
        };


        // running the bot
        await discord.ConnectAsync();

        await Task.Delay(-1);
    }

}