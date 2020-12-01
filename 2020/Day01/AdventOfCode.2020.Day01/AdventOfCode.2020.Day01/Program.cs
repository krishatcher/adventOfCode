using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace AdventOfCode._2020.Day01
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var expRptFile = File.OpenText(args[0]);
            var expRptList = JsonConvert.DeserializeObject<List<int>>(expRptFile.ReadToEnd());
            var finalResult = 0;

            var numberOfExpenses = 2;
            if (args[1] != null) numberOfExpenses = Convert.ToInt32(args[1]);

            while (finalResult == 0)
            {
                var items = RandomTools.PickRandom(expRptList, numberOfExpenses).ToArray();
                if (items.Sum() != 2020) continue;

                var output = 1;
                items.ToList().ForEach(x => { output *= x; });

                finalResult = output;
            }

            Console.WriteLine("Result: " + finalResult);
            expRptFile.Dispose();
        }
    }
}
