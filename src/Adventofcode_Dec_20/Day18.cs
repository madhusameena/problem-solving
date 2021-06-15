using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.VisualBasic.CompilerServices;

namespace CSharpProblemSolving.Adventofcode_Dec_20
{
    public class Day18
    {
        private static long Total = 1;
        private static string ipPath = @"D:\MyProjects\CSharp\CSharpProblemSolving\Adventofcode_Dec_20\Day18_M.txt";

        public static void Solve1()
        {
	        var lines = File.ReadLines(ipPath).ToList();
	        long totalCount = 0;
	        foreach (var line in lines)
	        {
		        var newLine = line.Replace(" ", "");
		        for (int idx = 0; idx < newLine.Length; idx++)
		        {
			        var ch = newLine[idx];
			        if (ch == '+' || ch == '*')
			        {
				        if (newLine[idx - 1] == '(' ||
				            newLine[idx - 1] == ')')
				        {
					        // Calc left
				        }
			        }
		        }
	        }

	        Console.WriteLine($"First ans: {totalCount}");
        }
        public static void Solve2()
		{
			var lines = File.ReadLines(ipPath).ToList();
			
		}
    }
}