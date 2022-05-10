using System.Drawing;
using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;

public class Poll : BaseCommandModule{
    [Command("poll")]
    public async Task poll(CommandContext commandContext, [RemainingText] String text){
        DiscordEmbedBuilder discordEmbedBuilder = new DiscordEmbedBuilder();
        //discordEmbedBuilder.Title = "Sugestija";
        discordEmbedBuilder.Color = DiscordColor.Aquamarine;
        discordEmbedBuilder.AddField("Suggestion", text, false);
        await commandContext.RespondAsync(discordEmbedBuilder.Build());
    }

    
}