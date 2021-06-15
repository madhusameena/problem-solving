using System.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpProblemSolving.CodeJam_2020
{
    public static class Vestigium
    {
        private static string s_fileName = "D:\\MyProjects\\CSharp\\CSharpProblemSolving\\CodeJam_2020\\Inputs\\Vestigium.txt";
        public static void Solve()
        {
            int lineIdx = 0;
            // var lines = File.ReadLines(s_fileName).ToList();
            int numOfSquares = int.Parse(Console.ReadLine());
            lineIdx++;
            for (int idx = 0; idx < numOfSquares; idx++)
            {
                int sqSize = int.Parse(Console.ReadLine());
                lineIdx++;
                var vals = new Dictionary<(int, int), int>();
                for (int sqIdx = 0; sqIdx < sqSize; sqIdx++)
                {
                    var line = Console.ReadLine();
                    lineIdx++;
                    var nums = line.Split(" ");
                    for (int numIdx = 0; numIdx < nums.Length; numIdx++)
                    {
                        int num = int.Parse(nums[numIdx]);
                        vals.Add((sqIdx, numIdx), num);
                    }
                }

                int sum = 0;
                int rowDuplicates = 0;
                int colDuplicates = 0;

                for (int diagIdx = 0; diagIdx < sqSize; diagIdx++)
                {
                    sum += vals[(diagIdx, diagIdx)];
                    var rowUniq = vals.Where(item => item.Key.Item1 == diagIdx).Select(item => item.Value).Distinct().Count();
                    rowDuplicates += rowUniq == sqSize ? 0 : 1;
                    
                    var colUniq = vals.Where(item => item.Key.Item2 == diagIdx).Select(item => item.Value).Distinct().Count();
                    colDuplicates += colUniq == sqSize ? 0 : 1;
                }

                Console.WriteLine($"Case #{idx + 1}: {sum} {rowDuplicates} {colDuplicates}");
            }
        }
    }
}