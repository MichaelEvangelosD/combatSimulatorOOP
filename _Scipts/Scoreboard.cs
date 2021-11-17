using System;
using System.Collections.Generic;

namespace f5_oop
{
    public class Scoreboard
    {
        static List<string> scores = new List<string>();

        static int rounds = 1;
        public static void CreateEntry(string name, int health, int armor)
        {
            string completedEntry = $"At round {rounds} in {DateTime.Now}:\n" +
                    $"\tPlayer {name} was attacked\n" +
                    $"\tRemaining health: {health}\n" +
                    $"\tRemaining armor: {armor}";

            AddEntry(completedEntry);

            rounds++;
        }

        static void AddEntry(string entry)
        {
            scores.Add(entry);
        }

        public static void PrintScoreboard()
        {
            Utilities.PrintSeparatorLines();
            Console.WriteLine("\t\tSCOREBOARD");
            Utilities.PrintSeparatorLines();

            foreach (string entry in scores)
            {
                Console.WriteLine(entry);
                Utilities.PrintSeparatorLines();
            }
        }
    }
}
