using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;

public class Unmute : BaseCommandModule{
    [Command("unmute")]
    [RequireUserPermissions(Permissions.MuteMembers)]
    public async Task unmute(CommandContext commandContext, DiscordMember member, [RemainingText] String reason = ""){
        var userId = commandContext.Message.MentionedUsers.First().Id;
        member = await commandContext.Guild.GetMemberAsync(userId);
        DiscordRole role;
        role = commandContext.Guild.GetRole(968223298183909426);
        
        if(member.Roles.Contains(role)){
            await member.RevokeRoleAsync(role, reason);
            await commandContext.RespondAsync("Ваљда му маца вратила језик.");
        } else{
            await commandContext.RespondAsync("Ало бона, куш умјутат неког ко може да прича.");

        }

        

       
    }
}