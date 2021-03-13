using HangMan_Discord_Bot.Commands;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace HangMan_Discord_Bot.Game
{
    class Game
    {
        public static string word;
        public static List<String> words = new List<String>(File.ReadAllLines("Words.txt"));
        public static List<String> guessedChars = new List<String>();
        public static int wrongCounter = 0;
        public static Boolean isPlaying = false;

        public static void setupGame()
        {
            Random rnd = new Random();
            int index = rnd.Next(words.Count);
            word = words[index];
            isPlaying = true;
        }

        public static void GuessWord(string s)
        {
            if (word.Contains(s))
            {
                guessedChars.Add(s);
            }
            else
            {
                wrongCounter++;
            }
        }

        public static void resetGame()
        {
            isPlaying = false;
            word = null;
            wrongCounter = 0;
            guessedChars.Clear();
        }
    }
}
