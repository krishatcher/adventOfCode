using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode._2020.Day01
{
    public static class RandomTools
    {
        // The Random object this method uses.
        private static Random _rand;

        // Return num_items random values.
        public static IEnumerable<int> PickRandom(List<int> values, int numValues)
        {
            // Create the Random object if it doesn't exist.
            _rand ??= new Random();

            // Don't exceed the array's length.
            if (numValues >= values.Count)
                numValues = values.Count - 1;

            // Make an array of indexes 0 through values.Length - 1.
            var indexes = Enumerable.Range(0, values.Count).ToArray();

            // Build the return list.
            var results = new List<int>();

            // Randomize the first num_values indexes.
            for (var i = 0; i < numValues; i++)
            {
                // Pick a random entry between i and values.Length - 1.
                var j = _rand.Next(i, values.Count);

                // Swap the values.
                var temp = indexes[i];
                indexes[i] = indexes[j];
                indexes[j] = temp;

                // Save the ith value.
                results.Add(values[indexes[i]]);
            }

            // Return the selected items.
            return results;
        }
    }
}
