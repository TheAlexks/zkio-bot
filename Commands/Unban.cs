using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;

public class Unban : BaseCommandModule{
    [Command("unban")]
    [RequireUserPermissions(Permissions.BanMembers)]
    [Description("Unbanuje membera.")]
    public async Task unban(CommandContext commandContext,  DiscordUser user, [RemainingText] string reason = ""){

        var userId = user.Id;
        
        DiscordGuild guild;

        guild = commandContext.Guild;
        
        DiscordBan ban = await guild.GetBanAsync(userId);

        if(ban.User.Id.Equals(userId)){
            await user.UnbanAsync(guild);
            await commandContext.RespondAsync("Member unbanovan.");
        } else{
            await commandContext.RespondAsync("Member nije banovan");
        }

    }
}