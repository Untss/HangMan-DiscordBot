using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using DSharpPlus.Interactivity.Extensions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HangMan_Discord_Bot.Commands
{
    public class GuessCommand : BaseCommandModule
    {
        [Command("Guess")]
        public async Task Guess(CommandContext ctx, string guess)
        {
            if (Game.Game.isPlaying)
            {
                if (!(Game.Game.wrongCounter >= 6))
                {
                    if(Game.Game.word.Length == Game.Game.guessedChars.Count + 1)
                    {
                        var builder = new DiscordEmbedBuilder()
                        {
                            Title = "You won!",
                            Color = DiscordColor.CornflowerBlue,
                            Description = "Goodjob, " + ctx.User.Username,
                        };

                        Game.Game.resetGame();

                        await ctx.Channel.SendMessageAsync(builder).ConfigureAwait(false);
                    }
                    else
                    {
                        Console.Write("test\n");
                        Game.Game.GuessWord(guess);
                        Console.Write("test1\n");
                        var builder = new DiscordEmbedBuilder()
                        {
                            Title = "Hangman Game",
                            Color = DiscordColor.CornflowerBlue,
                            Description = "use .guess <char> to guess a char!"
                        };

                        string txt = "";

                        char[] charWords = Game.Game.word.ToCharArray();

                        for (int i = 0; i < Game.Game.word.Length; i++)
                        {
                            if (Game.Game.guessedChars.Contains(charWords[i].ToString()))
                            {
                                txt = txt + charWords[i] + " ";
                            }
                            else
                            {
                                txt = txt + "_ ";
                            }
                        }

                        builder.AddField("Tries Left", $"{7 - Game.Game.wrongCounter}", false);
                        builder.AddField("Guessed Chars", $"```{txt}```", true);

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
