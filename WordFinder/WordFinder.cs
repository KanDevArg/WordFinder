using System;
using System.Collections.Generic;
using System.Linq;

namespace WordFinder
{
    public class WordFinder
    {
        private  IEnumerable<string> _matrix;
        public WordFinder(IEnumerable<string> matrix) {
            _matrix = matrix;
            AddColumnStreams(matrix); // add columnStreams into already existent rowStreams
        }

        private void AddColumnStreams(IEnumerable<string> matrix)
        {
            var columnStreams = new string[] { };
            Array.Resize(ref columnStreams, matrix.First().Length);

            foreach (var rowStream in matrix) {
                var streamCharArray = rowStream.ToCharArray();
                for (var i = 0; i < rowStream.Length; i++) {
                    columnStreams[i] += streamCharArray[i];
                }
            }

            var newMatrix = matrix.ToList();
            newMatrix.AddRange(columnStreams);

            _matrix = newMatrix;
        }

        public IEnumerable<string> Find(IEnumerable<string> words)
        {
            var dict = 
                words.ToDictionary(w => w, w => 0);
            
            foreach (var word in words) {
                foreach (var stream in _matrix)
                {
                    if (stream.Replace(word, "").Length != stream.Length  ) {
                        dict[word]++;
                    }
                }
            }


            foreach (var kv in dict)
            {
                Console.WriteLine($"{kv.Key} => occurrences: {kv.Value}");
            }
            
            return dict.OrderByDescending(key => key.Value)
                .Where(kv=> kv.Value >0)
                .Take(10)
                .Select(kv=> kv.Key).ToList();
        }
    }
}