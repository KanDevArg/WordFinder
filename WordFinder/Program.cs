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
                "abcdcczzyy",
                "fgwiohzztu",
                "chillizzyy",
                "pqnsdltuyy",
                "uvdxyluzyy"
            };

            var wordFinder = new WordFinder(matrix);

            var wordsToFind = new List<string> {"cold", "chill", "wind", "snow", "tu"};

            var foundWords =  wordFinder.Find(wordsToFind);

            foreach (var foundWord in foundWords) {
                Console.WriteLine(foundWord);
            }
        }
    }
}