using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;

public class EmbedCommand : BaseCommandModule{
    [Command("userinfo")]
    public async Task testEmbed(CommandContext commandContext, DiscordMember member){
        var userId = commandContext.Message.MentionedUsers.First().Id;
        member = await commandContext.Guild.GetMemberAsync(userId);

        DiscordEmbedBuilder discordEmbedBuilder = new DiscordEmbedBuilder();
        discordEmbedBuilder.Title = $"Info for {member.DisplayName}";
        discordEmbedBuilder.AddField("Joined: ", member.JoinedAt.ToString(), false);
        discordEmbedBuilder.AddField("Is the owner?", member.IsOwner.ToString(), false);
        discordEmbedBuilder.AddField("Is bot?", member.IsBot.ToString(), false);

        // var emoji = DiscordEmoji.FromName(commandContext.Client, ":rofl");
        
        await commandContext.RespondAsync(discordEmbedBuilder.Build());
    }
}