using System.Threading.Tasks;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;

public class Ping : BaseCommandModule{
    [Command("ping")]

    public async Task PingCommand(CommandContext context){
        await context.RespondAsync("Pong!");
    }
}