using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using DSharpPlus.Interactivity.Extensions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using static DSharpPlus.Entities.DiscordEmbedBuilder;

namespace HangMan_Discord_Bot.Commands
{
    public class GuessCommand : BaseCommandModule
    {
        [Command("Guess")]
        public async Task Guess(CommandContext ctx, string guess)
        {
            Console.WriteLine("Command ran!");

            string word1;
            if (Game.Game.word.TryGetValue(ctx.Guild, out word1))
            {
                word1 = word1;
            }

            List<String> guessedChars;
            if (Game.Game.guessedChars.TryGetValue(ctx.Guild, out guessedChars))
            {
                guessedChars = guessedChars;
            }

            Boolean value;
            if (Game.Game.playing.TryGetValue(ctx.Guild, out value))
            {
                value = value;
            }
            if (value)
            {
                int value1;
                if (Game.Game.wrongGuessCounter.TryGetValue(ctx.Guild, out value1))
                {
                    value1 = value1;
                }

                if (!(value1 >= 7))
                {
                    Console.WriteLine(word1);
                    Game.Game.GuessChar(ctx.Guild, guess);
                    Console.Write("test1");

                    EmbedFooter footer = new EmbedFooter();

                    footer.Text = "Developed by Julian#5916";

                    var builder = new DiscordEmbedBuilder()
                    {
                        Title = "Hangman Game",
                        Color = DiscordColor.CornflowerBlue,
                        Description = "use .guess <char> to guess a char!",
                        Footer = footer
                    };

                    string txt = "";

                    char[] charWords = word1.ToCharArray();

                    for (int i = 0; i < word1.Length; i++)
                    {
                        if (guessedChars.Contains(charWords[i].ToString()))
                        {
                            txt = txt + charWords[i].ToString() + " ";
                        }
                        else
                        {
                            txt = txt + "_ ";
                        }
                    }

                    Console.WriteLine("test123");

                    int wrongCount;
                    if (Game.Game.wrongGuessCounter.TryGetValue(ctx.Guild, out wrongCount))
                    {
                        wrongCount = wrongCount;
                    }

                    builder.AddField("Tries Left", $"{7 - wrongCount}", false);
                    builder.AddField("Guessed Chars", $"```{txt}```", true);

                    await ctx.Channel.SendMessageAsync(builder).ConfigureAwait(false);

                    if (word1.Length == guessedChars.Count)
                    {
                        var builder1 = new DiscordEmbedBuilder()
                        {
                            Title = "You won!",
                            Color = DiscordColor.CornflowerBlue,
                            Description = "Goodjob, " + ctx.User.Username,
                        };

                        Game.Game.resetGame(ctx.Guild);

                        await ctx.Channel.SendMessageAsync(builder1).ConfigureAwait(false);
                    }

                }
                else
                {
                    var builder = new DiscordEmbedBuilder()
                    {
                        Title = "Game Over!",
                        Color = DiscordColor.CornflowerBlue,
                        Description = "U lost the game, the word was: " + word1,
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
