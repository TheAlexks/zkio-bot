using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;

public class Nick : BaseCommandModule{
    [Command("nick")]
    [RequireUserPermissions(Permissions.ManageNicknames)]
    public async Task ChangeNick(CommandContext commandContext, DiscordMember member, [RemainingText] string nick){
        var userId = commandContext.Message.MentionedUsers.First().Id;
        member = await commandContext.Guild.GetMemberAsync(userId);

        if(nick.Equals(member.Nickname)){
            await commandContext.RespondAsync("Исто је име као и пре.");
        } else{
            await member.ModifyAsync(p => p.Nickname = nick);
        }
    }
}