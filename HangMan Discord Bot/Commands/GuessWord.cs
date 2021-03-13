using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HangMan_Discord_Bot.Commands
{
    public class GuessWord : BaseCommandModule
    {
        [Command("Guessword")]
        public async Task guessWord(CommandContext ctx, string word)
        {
            if (Game.Game.isPlaying)
            {
                if (!(Game.Game.wrongCounter >= 6))
                {
                    if (Game.Game.word == word)
                    {
                        //win
                        var builder1 = new DiscordEmbedBuilder()
                        {
                            Title = "You won!",
                            Color = DiscordColor.CornflowerBlue,
                            Description = "Goodjob, " + ctx.User.Username,
                        };

                        Game.Game.resetGame();

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

                        Game.Game.resetGame();

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

                    Game.Game.resetGame();

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
