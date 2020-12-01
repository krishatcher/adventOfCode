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
            var file = File.OpenText(args[0]);
            var jsonString = file.ReadToEnd();
            var expRptList = JsonConvert.DeserializeObject<List<int>>(jsonString);
            var finalResult = 0;

            foreach (var expense in expRptList)
            {
                foreach (var expRptItem in expRptList.Where(expRptItem => expRptItem != expense).Where(expRptItem => expRptItem + expense == 2020))
                {
                    finalResult = expRptItem * expense;
                    break;
                }

                if (finalResult != 0) break;
            }

            Console.WriteLine("Result: " + finalResult);
            file.Dispose();
        }
    }
}
