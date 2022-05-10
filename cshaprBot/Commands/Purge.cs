using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;

public class Purge : BaseCommandModule{
    [Command("purge")]
    [RequireUserPermissions(Permissions.ManageMessages)]
    public async Task purge(CommandContext commandContext, int limit){
        var channel = commandContext.Channel;
        
        var messages = await channel.GetMessagesAsync(limit + 1);
        await channel.DeleteMessagesAsync(messages);

        await commandContext.RespondAsync($"Обрисах {limit} порука.");
    }   
}