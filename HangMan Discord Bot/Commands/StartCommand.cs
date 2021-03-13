using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HangMan_Discord_Bot.Commands
{
    public class StartCommand : BaseCommandModule
    {

        [Command("start")]
        public async Task start(CommandContext ctx)
        {
            Game.Game.setupGame();
            DiscordEmbed embed = new DiscordEmbedBuilder();

            var builder = new DiscordEmbedBuilder()
            {
                Title = "New Game!",
                Color = DiscordColor.CornflowerBlue,    
                Description = "use .guess <char> to guess a char!"
            };

            string txt = "";

            for(int i = 0; i < Game.Game.word.Length; i++)
            {
                txt = txt + "_ ";
            }

            builder.AddField("Tries Left", $"{7 - Game.Game.wrongCounter}", false);
            builder.AddField("Guessed Chars", $"```{txt}```", false);

            await ctx.Channel.SendMessageAsync(builder);
        }


    }
}
