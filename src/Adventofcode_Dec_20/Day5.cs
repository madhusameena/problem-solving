using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CSharpProblemSolving.Adventofcode_Dec_20
{
    public static class Day5
    {
        public static void Solve()
        {
            string ipPath = @"D:\MyProjects\CSharp\CSharpProblemSolving\Adventofcode_Dec_20\Day4_2.txt";
            var lines = File.ReadLines(ipPath).ToList();
            Console.WriteLine($"Total number of lines = {lines.Count}");
            for (int idx = 0; idx < lines.Count(); idx++)
            {
                var line = lines[idx];
                Console.WriteLine($"Line no: {idx} = {line}");
            }
        }
    }
}