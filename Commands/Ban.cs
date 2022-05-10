using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using DSharpPlus.Exceptions;

public class Ban : BaseCommandModule{
    [Command("ban")]
    [RequireUserPermissions(Permissions.BanMembers)]
    [Description("Banuje membera sa servera.")]
    public async Task ban(CommandContext commandContext, DiscordMember member, [RemainingText] string reason = ""){
        
        var userId = commandContext.Message.MentionedUsers.First().Id;
        member = await commandContext.Guild.GetMemberAsync(userId);

        // ulong userId = member.Id;
        
        DiscordGuild guild;

        guild = commandContext.Guild;

        await guild.BanMemberAsync(member);
        await commandContext.RespondAsync("Мајмун је толико пијан да је попио бан.");

    }
}
