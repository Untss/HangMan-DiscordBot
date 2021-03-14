using DSharpPlus.Entities;
using HangMan_Discord_Bot.Commands;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace HangMan_Discord_Bot.Game
{
    class Game
    {
        public static List<String> words = new List<String>(File.ReadAllLines("Words.txt"));

        public static Dictionary<DiscordGuild, string> word = new Dictionary<DiscordGuild, string>();
        public static Dictionary<DiscordGuild, List<string>> guessedChars = new Dictionary<DiscordGuild, List<string>>();
        public static Dictionary<DiscordGuild, int> wrongGuessCounter = new Dictionary<DiscordGuild, int>();
        public static Dictionary<DiscordGuild, Boolean> playing = new Dictionary<DiscordGuild, Boolean>();

        public static void setupGame(DiscordGuild g)
        {
            Random rnd = new Random();
            int index = rnd.Next(words.Count);
            word.Add(g, words[index]);
        }

        public static void GuessChar(DiscordGuild g, string s)
        {
            string word1;
            List<String> chars;
            if (guessedChars.TryGetValue(g, out chars))
            {
                chars = chars;
            }

            if (word.TryGetValue(g, out word1))
            {
                if (word1.Contains(s))
                {
                    chars.Add(s);
                    guessedChars[g] = chars;
                }
                else
                {
                    int value;
                    if (wrongGuessCounter.TryGetValue(g, out value))
                    {
                        wrongGuessCounter[g] = value + 1;               
                    }
                }
            }
        }

        public static void resetGame(DiscordGuild g)
        {
            playing.Remove(g);
            word.Clear();
            wrongGuessCounter.Remove(g);
            guessedChars.Clear();
        }
    }
}
