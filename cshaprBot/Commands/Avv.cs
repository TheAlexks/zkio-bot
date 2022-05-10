using System.Runtime.InteropServices;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;

public class Avv : BaseCommandModule{
    [Command("avv")]
    public async Task avv(CommandContext commandContext, DiscordMember member){
        var userId = commandContext.Message.MentionedUsers.First().Id;
        member = await commandContext.Guild.GetMemberAsync(userId);

        DiscordEmbedBuilder discordEmbedBuilder = new DiscordEmbedBuilder();
        discordEmbedBuilder.ImageUrl = member.AvatarUrl;
        await commandContext.RespondAsync(discordEmbedBuilder.Build());
    }
}