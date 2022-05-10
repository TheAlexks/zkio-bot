using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;

public class UserInfo : BaseCommandModule{
    [Command("userinfo")]
    [Description("Salje embed za userinfo")]
    public async Task testEmbed(CommandContext commandContext, DiscordMember member){
        var userId = commandContext.Message.MentionedUsers.First().Id;
        member = await commandContext.Guild.GetMemberAsync(userId);

        DiscordEmbedBuilder discordEmbedBuilder = new DiscordEmbedBuilder();
        discordEmbedBuilder.Title = $"Информације за {member.DisplayName}";
        discordEmbedBuilder.AddField("Постао члан: ", member.JoinedAt.ToString(), false);
        discordEmbedBuilder.AddField("Да ли је власник?", member.IsOwner.ToString(), false);
        discordEmbedBuilder.AddField("Да ли је бот?", member.IsBot.ToString(), false);
        discordEmbedBuilder.ImageUrl = member.AvatarUrl;
        await commandContext.RespondAsync(discordEmbedBuilder.Build());
    }
}