using System.Linq;
using System.Runtime.InteropServices;
using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using DSharpPlus.EventArgs;
using DSharpPlus.Exceptions;
using Emzi0767.Utilities;

public class Kick : BaseCommandModule{
    [Command("kick")]
    [RequireUserPermissions(Permissions.KickMembers)]

    public async Task kick(CommandContext commandContext, DiscordMember member, [RemainingText] String reason = ""){
        var userId = commandContext.Message.MentionedUsers.First().Id;
        member = await commandContext.Guild.GetMemberAsync(userId);

        DiscordGuild guild;
        
        guild = member.Guild;
        
        try{
            await guild.GetMemberAsync(userId);
            await member.RemoveAsync();
            await commandContext.RespondAsync($"{member.Mention} кикован.");
        } catch(NotFoundException e){
            Console.WriteLine($"Мембер није у серверу. {e}");
        }
        

    }
}