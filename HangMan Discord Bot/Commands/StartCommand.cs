using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using static DSharpPlus.Entities.DiscordEmbedBuilder;

namespace HangMan_Discord_Bot.Commands
{
    public class StartCommand : BaseCommandModule
    {

        [Command("start")]
        public async Task start(CommandContext ctx)
        {
            Game.Game.setupGame(ctx.Guild);
            Game.Game.playing.Add(ctx.Guild, true);
            Game.Game.wrongGuessCounter.Add(ctx.Guild, 0);
            Game.Game.guessedChars.Add(ctx.Guild, new List<String>());

            DiscordEmbed embed = new DiscordEmbedBuilder();

            EmbedFooter footer = new EmbedFooter();

            footer.Text = "Developed by Julian#5916";

            var builder = new DiscordEmbedBuilder()
            {
                Title = "New Game!",
                Color = DiscordColor.CornflowerBlue,    
                Description = "use .guess <char> to guess a char!",
                Footer = footer,
            };

            string txt = "";

            string word1;
            if (Game.Game.word.TryGetValue(ctx.Guild, out word1))
            {
                word1 = word1;
            }

            for (int i = 0; i < word1.Length; i++)
            {
                txt = txt + "_ ";
            }

            int value;
            if(Game.Game.wrongGuessCounter.TryGetValue(ctx.Guild, out value))
            {
                value = value;
            }

            builder.AddField("Tries Left", $"{7 - value}", false);
            builder.AddField("Guessed Chars", $"```{txt}```", false);

            await ctx.Channel.SendMessageAsync(builder);
        }


    }
}
