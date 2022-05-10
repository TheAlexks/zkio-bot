using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;

public class Mute : BaseCommandModule{
    [Command("mute")]
    [RequireUserPermissions(Permissions.MuteMembers)]
    public async Task mute(CommandContext commandContext, DiscordMember member, [RemainingText] String reason = ""){
        var userId = commandContext.Message.MentionedUsers.First().Id;
        member = await commandContext.Guild.GetMemberAsync(userId);
        DiscordRole role;
        role = commandContext.Guild.GetRole(968223298183909426);

        if(member.Roles.Contains(role)){
            await commandContext.RespondAsync("Bona, vis da je covek vec mjutovan?");
        } else{
            await member.GrantRoleAsync(role, reason);
            await commandContext.RespondAsync("Ovaj ne mere vise da prica.");
        }

       
    }
}