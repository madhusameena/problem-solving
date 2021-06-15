using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace CSharpProblemSolving.Adventofcode_Dec_20
{
    public class Day16
    {
            private static long Total = 1;
            private static string ipPath = @"D:\MyProjects\CSharp\CSharpProblemSolving\Adventofcode_Dec_20\Day16.txt";

            public static void Solve1()
            {
                List<int> busNumbers = new List<int>();
                var lines = File.ReadLines(ipPath).ToList();
                List<Tuple<int, int>> tuples = new List<Tuple<int, int>>();
                for (int i = 0; i < 20; i++)
                {
                    var line = lines[i];
                    var idx = line.IndexOf(": ") + 2;
                    var newLine = line.Substring(idx);
                    var nums2 = newLine.Split(" or ");
                    foreach (var s in nums2)
                    {
                        var nums = s.Split("-");
                        int num1 = int.Parse(nums[0]);
                        int num2 = int.Parse(nums[1]);
                        tuples.Add(new Tuple<int, int>(num1, num2));
                    }
                }


                List<int> removingIndces = new List<int>();
                for (var index = 25; index < lines.Count; index++)
                {
                    var line = lines[index];
                    
                    var nums = line.Split(",");
                    foreach (var numString in nums)
                    {
                        var num = int.Parse(numString);
                        bool exists = false;
                        for (var tupleIdx = 0; tupleIdx < tuples.Count; tupleIdx++)
                        {
                            var tuple = tuples[tupleIdx];
                            if (num >= tuple.Item1 && num <= tuple.Item2)
                            {
                                exists = true;
                                break;
                            }
                        }

                        if (!exists)
                        {
                            // if (!removingIndces.Exists(index))
                            if (!removingIndces.Contains(index))
                            {
                                removingIndces.Add(index);
                            }
                            break;
                        }
                    }
                }
                

                List<Tuple<int, List<int>>> totalList = new List<Tuple<int, List<int>>>();
                for (int deptIdx = 0; deptIdx < 20; deptIdx++)
                {
                    List<int> deptList = new List<int>();
                    var tpl1 = tuples[deptIdx * 2];
                    var tpl2 = tuples[(deptIdx * 2) + 1];
                    for (int colIdx = 0; colIdx < 20; colIdx++)
                    {
                        int validCount = 0;
                        for (var index = 25; index < lines.Count; index++)
                        {
                            if (removingIndces.Contains(index))
                            {
                                continue;
                            }
                            var line = lines[index];
                    
                            var nums = line.Split(",");
                            var num = int.Parse(nums[colIdx]);
                            if ((num >= tpl1.Item1 && num <= tpl1.Item2) ||
                                (num >= tpl2.Item1 && num <= tpl2.Item2))
                            {
                                // Valid
                                validCount++;
                            }
                        }

                        if (validCount == lines.Count - 25 - removingIndces.Count)
                        {
                            Console.WriteLine($"Valid Combo, deptIdx = {deptIdx}, colIdx == {colIdx}");
                            deptList.Add(colIdx);
                        }
                        else
                        {
                            // colIdx--;
                        }
                    }
                    totalList.Add(new Tuple<int, List<int>>(deptIdx, deptList));
                    
                }

                List<int> finalList = new List<int>();
                for (int i = 0; i < 20; i++)
                {
                    finalList.Add(-1);   
                }

                List<int> prevIdxs = new List<int>();
                int prevIdx = 0;
                for (int idx = 0; idx < 20; idx++)
                {
                    var tuple = totalList[idx];
                    for (; prevIdx < tuple.Item2.Count; prevIdx++)
                    {
                        var item = tuple.Item2[prevIdx];
                        if (!finalList.Contains(item))
                        {
                            finalList[idx] = item;
                            prevIdxs.Add(prevIdx);
                            prevIdx = 0;
                            break;
                        }
                    }

                    if (finalList[idx] == -1)
                    {
                        while (true)
                        {
                            idx--;
                            var count = totalList[idx].Item2.Count;
                            var lastIdx = prevIdxs[idx];
                            prevIdx = lastIdx + 1;
                            finalList[idx] = -1;
                            prevIdxs.RemoveAt(idx);
                            if (prevIdx < count)
                            {
                                break;
                            }
                        }

                        idx--;
                    }
                    
                }

                Console.WriteLine();
                for (var index = 0; index < finalList.Count; index++)
                {
                    var final = finalList[index];
                    Console.WriteLine($"{index} - {final},");
                }

                var ipLine = lines[22];
                List<int> ipLines = new List<int>();
                var strIps = ipLine.Split(",");
                foreach (var str in strIps)
                {
                    ipLines.Add(int.Parse(str));
                }

                long result = 1;

                for (int idx = 0; idx < 6; idx++)
                {
                    var index = finalList[idx];
                    Console.WriteLine($"value for dep{idx} - index {index} is {ipLines[index]}");
                    result *= ipLines[index];
                }
                Console.WriteLine();

                Console.WriteLine($"1 Ans = {result}");
            }       

            public static void Solve2()
            {
                List<long> busNumbers = new List<long>();
                var lines = File.ReadLines(ipPath).ToList();
                Console.WriteLine($"Total number of lines = {lines.Count}");
                for (var index = 0; index < lines.Count; index++)
                {
                    var line = lines[index];
                }

                Console.WriteLine($"2 Ans = {0}");
            }
    }
}