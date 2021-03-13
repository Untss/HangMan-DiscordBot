using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HangMan_Discord_Bot.Commands
{
    public class Help : BaseCommandModule
    {
        [Command("HelpGame")]
        public async Task help(CommandContext ctx)
        {
            var builder = new DiscordEmbedBuilder()
            {
                Title = "List Of Commands",
                Color = DiscordColor.CornflowerBlue,
                Description = "THis is a list of commands to play hangman!"
            };

            builder.AddField(".start", "Starts a game!", false);
            builder.AddField(".guess", ".guess <char> guesses a character", false);
            builder.AddField(".guessword", ".guessword <word> guesses the entire word", false);

            await ctx.Channel.SendMessageAsync(builder).ConfigureAwait(false);
        }

    }
}
