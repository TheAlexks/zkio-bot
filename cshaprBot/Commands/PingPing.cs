using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;

public class PingPing : BaseCommandModule{
    [Command("pingPing")]
    [RequireUserPermissions(DSharpPlus.Permissions.Administrator)]
    public async Task pingPing(CommandContext commandContext, DiscordMember member, int amount){
        
        var userId = commandContext.Message.MentionedUsers.First().Id;
        member = await commandContext.Guild.GetMemberAsync(userId);

        for(int i = 0; i < amount; i++){
            await commandContext.RespondAsync(member.Mention);
        }
    }
}