using System;

namespace HangMan_Discord_Bot
{
    class Program
    {   
        static void Main(string[] args)
        {
            var bot = new Bot();
            bot.RunAsync().GetAwaiter().GetResult();
        }
    }
}
