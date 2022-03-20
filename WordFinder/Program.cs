using System;
using System.Collections.Generic;

namespace WordFinder
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            var matrix = new List<string>
            {
                "abcdcczzyyzzsnowz",
                "fgwiohzztunsnsnow",
                "chillizzyyonoztut",
                "pqnsdltuyysowzuzt",
                "uvdxyluzyyzwzzbc1"
            };

            var wordFinder = new WordFinder(matrix);

            var wordsToFind = new List<string> {"cold", "chill", "wind", "snow", "tu", "al", "bc", "dd1", "dd2", "tt1", "tt2", "yyt", "wwe"};

            var foundWords =  wordFinder.Find(wordsToFind);

            Console.WriteLine("\nTop 10 words found");
            foreach (var foundWord in foundWords) {
                Console.WriteLine(foundWord);
            }
        }
    }
}