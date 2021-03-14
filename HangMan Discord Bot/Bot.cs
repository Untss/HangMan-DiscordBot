using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.EventArgs;
using DSharpPlus.Interactivity;
using DSharpPlus.Interactivity.Enums;
using DSharpPlus.Interactivity.Extensions;
using HangMan_Discord_Bot.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HangMan_Discord_Bot
{
    class Bot
    {

        public DiscordClient Client { get; private set; }
        public InteractivityExtension Interactivity { get; private set;  }
        public CommandsNextExtension Commands { get; private set; }

        public async Task RunAsync()
        {
            var config = new DiscordConfiguration
            {
                Token = "ODE5OTkxMjg2Njg5MDM4MzY3.YEuqZQ.aAplRRYTHkMluhUbVF_BxPYZq7M",
                TokenType = TokenType.Bot,
                AutoReconnect = true,
            };

            Client = new DiscordClient(config);

            Client.UseInteractivity(new InteractivityConfiguration(){
                PollBehaviour = PollBehaviour.KeepEmojis,
                Timeout = TimeSpan.FromSeconds(30)
            });

            Client.Ready += OnClientReady;

            var commandsConfig = new CommandsNextConfiguration()
            {
                StringPrefixes = new string[] {"."},
                EnableDms = false,
                EnableMentionPrefix = true,
            };

            Commands = Client.UseCommandsNext(commandsConfig);

            Commands.RegisterCommands<StartCommand>();
            Commands.RegisterCommands<GuessCommand>();
            Commands.RegisterCommands<GuessWord>();
            Commands.RegisterCommands<Help>();

            await Client.ConnectAsync();

            await Task.Delay(-1);
        }

        private Task OnClientReady(object sender, ReadyEventArgs e)
        {
            return Task.CompletedTask;
        }
    }
}
