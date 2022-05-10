using System.Threading.Tasks;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;

public class greet : BaseCommandModule{
    [Command("greet")]
    public async Task GreetCommand(CommandContext commandContext, [RemainingText] string name){
        await commandContext.RespondAsync($"Hello there, {name}");
    }
}