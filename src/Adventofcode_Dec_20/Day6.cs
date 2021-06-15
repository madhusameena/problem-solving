using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace CSharpProblemSolving.Adventofcode_Dec_20
{
    public static class Day6
    {
        private static long Total = 0;
        public static void Solve()
        {
            string ipPath = @"D:\MyProjects\CSharp\CSharpProblemSolving\Adventofcode_Dec_20\Day6_N_2.txt";
            var lines = File.ReadLines(ipPath).ToList();
            Console.WriteLine($"Total number of lines = {lines.Count}");
            var newLines = new List<string>();
            for (int idx = 0; idx < lines.Count(); idx++)
            {
                var line = lines[idx];
                 // Console.WriteLine($"Line no: {idx} = {line}");
                if (string.IsNullOrEmpty(line) || idx == lines.Count - 1)
                {
                    ProcessData(newLines);
                    newLines.Clear();
                }
                else
                {
                    newLines.Add(line);
                }
                // if (!string.IsNullOrEmpty(line))
                // {
	               //  var result = new String(line.Distinct().ToArray());
	               //  Console.WriteLine($"result = {result}, Count = {result.Length}");
	               //  Total += result.Length;
                //
                // }
            }

            Console.WriteLine($"Total Count= {Total}");
        }

        private static void ProcessData(List<string> newLines)
        {
            Total += Mad.MadHelper.CommonCharactersForAllStrings(newLines.ToArray(), newLines.Count);
        }
         
    }
}