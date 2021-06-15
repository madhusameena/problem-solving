using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace CSharpProblemSolving.Adventofcode_Dec_20
{
    public static class Day10
    {
        private static long Total = 0;
        private static List<Tuple<string, int>> Tuples = new List<Tuple<string, int>>();

        public static void Solve()
        {
            string ipPath = @"D:\MyProjects\CSharp\CSharpProblemSolving\Adventofcode_Dec_20\d10_r.txt";
            var lines = File.ReadLines(ipPath).ToList();
            Console.WriteLine($"Total number of lines = {lines.Count}");
            var newLines = new List<string>();
            var listInt = new List<int>();
            for (int idx = 0; idx < lines.Count; idx++)
            {
                var line = lines[idx];
                // Console.WriteLine($"Idx = {idx}, Line = {line}");
                listInt.Add(int.Parse(line));
            }
            listInt.Add(0);
            listInt.Add(listInt.Max() + 3);

            int oneDiff = 0;
            int ThreeDiff = 0;
          
            listInt = listInt.OrderBy(s => s).ToList();
            for (int idx = 0; idx < listInt.Count; idx++)
            {
                var item1 = listInt[idx];
                for (int j = 1; j < listInt.Count; j ++)
                {
                    var item2 = listInt[j];
                    if (item2 - item1 == 1)
                    {
                        oneDiff++;
                        break;
                    }
                    else if (item2 - item1 == 3)
                    {
                        ThreeDiff++;
                        break;
                    }
                }
            }

            Console.WriteLine($"oneDiff = {oneDiff}, ThreeDiff = {ThreeDiff}");
            Console.WriteLine($"First Prob: {oneDiff * ThreeDiff}");
            long diff = 1;
            List<ulong> diffs = new List<ulong>();
            long countTotal = 0;
            for (int idx = 0; idx < listInt.Count; idx++)
            {
                var item1 = listInt[idx];
                var item = Count(item1, listInt);
                // Console.WriteLine($"Item = {item}");
                diffs.Add((ulong) item);
            }
            List<int> counts = new List<int>();

            for (int idx = listInt.Count - 1; idx >= 0; idx--)
            {
                ulong total = 0;
                var item1 = listInt[idx];
                if (diffs[idx] == 0)
                {
                    continue;
                }
                if (listInt.Contains(item1 + 1))
                {
                    var index = listInt.IndexOf(item1 + 1);
                    total += diffs[index];
                }
                if (listInt.Contains(item1 + 2))
                {
                    var index = listInt.IndexOf(item1 + 2);
                    total += diffs[index];
                }
                if (listInt.Contains(item1 + 3))
                {
                    var index = listInt.IndexOf(item1 + 3);
                    total += diffs[index];
                }

                if (total != 0)
                {
                    diffs[idx] = total;
                }

                if (idx == 0)
                {
                    Console.WriteLine($"Total: {total}, for Index = {idx}, value = {listInt[idx]}");
                }
            }


            Console.WriteLine();
            Console.WriteLine($"countTotal = {countTotal}");
            // Console.WriteLine($"One = {oneDiff}, 3 = {ThreeDiff}");
            // Console.WriteLine($"Total num = {oneDiff * (ThreeDiff)}");
        }

        private static long ProcessData(int num, List<int> nums)
        {
            long data = 1;
            int count = 2;
            
            // if (nums.Contains(num + 1))
            // {
            //     count++;
            // }
            // if (nums.Contains(num + 2))
            // {
            //     count++;
            // }
            // if (nums.Contains(num + 3))
            // {
            //     count++;
            // }

            if (count > 1)
            {
                if (nums.Contains(num + 1))
                {
                    data *= ProcessData(num + 1, nums);
                }
                if (nums.Contains(num + 2))
                {
                    data *= ProcessData(num + 2, nums);
                }
                if (nums.Contains(num + 3))
                {
                    data *= ProcessData(num + 3, nums);
                }   
            }
            else
            {
                data = 0;
            }

            return data;
        }

        private static int Count(int num, List<int> nums)
        {
            int count = 0;
            if (nums.Contains(num + 1))
            {
                count++;
            }
            if (nums.Contains(num + 2))
            {
                count++;
            }
            if (nums.Contains(num + 3))
            {
                count++;
            }

            return count;
        }

    }
}