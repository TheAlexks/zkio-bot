using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;

public class HelpCommand : BaseCommandModule{
    [Command("list")]
    public async Task helpCommand(CommandContext commandContext){
        DiscordEmbedBuilder discordEmbedBuilder = new DiscordEmbedBuilder();
        discordEmbedBuilder.Title = "Sve komande";

        discordEmbedBuilder.AddField("Prefiks", "?", false);

        discordEmbedBuilder.AddField("ping", "Pong!", false);

        discordEmbedBuilder.AddField("poll", "Salje embed sa tesktom koji je naveden u komandi", false);

        discordEmbedBuilder.AddField("userinfo", "Salje embed sa podacima o memberu", false);

        await commandContext.RespondAsync(discordEmbedBuilder.Build());
    }
}