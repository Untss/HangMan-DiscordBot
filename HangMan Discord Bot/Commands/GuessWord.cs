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
    public class GuessWord : BaseCommandModule
    {
        [Command("Guessword")]
        public async Task guessWord(CommandContext ctx, string word)
        {

            string word1;
            if (Game.Game.word.TryGetValue(ctx.Guild, out word1))
            {
                word1 = word1;
            }

            int value;
            if (Game.Game.wrongGuessCounter.TryGetValue(ctx.Guild, out value))
            {
                value = value;
            }

            Boolean value1;
            if (Game.Game.playing.TryGetValue(ctx.Guild, out value1))
            {
                value1 = value1;
            }

            if (value1)
            {
                if (!(value >= 6))
                {
                    if (word1 == word)
                    {
                        //win
                        EmbedFooter footer = new EmbedFooter();

                        footer.Text = "Developed by Julian#5916";

                        var builder1 = new DiscordEmbedBuilder()
                        {
                            Title = "You won!",
                            Color = DiscordColor.CornflowerBlue,
                            Description = "Goodjob, " + ctx.User.Username,
                            Footer = footer
                        };

                        Game.Game.resetGame(ctx.Guild);

                        await ctx.Channel.SendMessageAsync(builder1).ConfigureAwait(false);
                    }
                    else
                    {
                        //lose
                        var builder = new DiscordEmbedBuilder()
                        {
                            Title = "Game Over!",
                            Color = DiscordColor.CornflowerBlue,
                            Description = "U lost the game, the word was: " + Game.Game.word,
                        };

                        Game.Game.resetGame(ctx.Guild);

                        await ctx.Channel.SendMessageAsync(builder).ConfigureAwait(false);
                    }
                }
                else
                {
                    var builder = new DiscordEmbedBuilder()
                    {
                        Title = "Game Over!",
                        Color = DiscordColor.CornflowerBlue,
                        Description = "U lost the game, the word was: " + Game.Game.word,
                    };

                    Game.Game.resetGame(ctx.Guild);

                    await ctx.Channel.SendMessageAsync(builder).ConfigureAwait(false);
                }
            }
            else
            {
                var builder = new DiscordEmbedBuilder()
                {
                    Title = "Start a game first with .start",
                    Color = DiscordColor.CornflowerBlue,
                    Description = ":)"
                };

                await ctx.Channel.SendMessageAsync(builder).ConfigureAwait(false);
            }
        }


    }
}
