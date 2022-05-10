using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;

public class DmMember : BaseCommandModule{
    [Command("dm")]
    [RequireUserPermissions(DSharpPlus.Permissions.ManageChannels)]
    public async Task dm(CommandContext commandContext, DiscordMember member, [RemainingText] String message){
        var userId = commandContext.Message.MentionedUsers.First().Id;
        member = await commandContext.Guild.GetMemberAsync(userId);

        await member.SendMessageAsync(message);        
    }
}