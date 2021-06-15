using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace CSharpProblemSolving.Adventofcode_Dec_20
{
    public class Day15
    {
            private static long Total = 0;
            private static List<Tuple<string, string>> Tuples = new List<Tuple<string, string>>();
            private static List<string> List = new List<string>();
            private static string ipPath = @"D:\MyProjects\CSharp\CSharpProblemSolving\Adventofcode_Dec_20\Day15.txt";
            static Dictionary<int, long> MemValues = new Dictionary<int, long>();

            public static void Solve1()
            {
                List<int> busNumbers = new List<int>();
                var lines = File.ReadLines(ipPath).ToList();
                long timeStamp;
                List<int> ips = new List<int>();
                List<Tuple<int, int, int>> tuples = new List<Tuple<int, int, int>>();
                Dictionary<int, Tuple<int, int>> tupleDict = new Dictionary<int, Tuple<int, int>>();
                for (var index = 0; index < lines.Count; index++)
                {
                    var line = lines[index];
                    var nums = line.Split(",");
                    for (var idx = 0; idx < nums.Length; idx++)
                    {
                        var num = nums[idx];
                        ips.Add(int.Parse(num));
                        tupleDict.Add(int.Parse(num), new Tuple<int, int>(idx + 1, 0));
                    }
                }

                int turn = ips.Count;
                int lastNum = ips[ips.Count - 1];
                Stopwatch sw = Stopwatch.StartNew();

                while (turn < 2020)
                {
                    // for (int idx = 0; idx < ips.Count; idx++)
                    {
                        turn++;
                        if (!tupleDict.Keys.Contains(lastNum))
                        {
                            lastNum = 0;
                        }
                        else
                        {
                            var tuple = tupleDict[lastNum];
                            if (tuple.Item1 > 0 && tuple.Item2 > 0)
                            {
                                // tuple = new Tuple<int, int>(tuple.Item2, turn);
                                lastNum = tuple.Item2 - tuple.Item1;
                                if (tupleDict.Keys.Contains(lastNum))
                                {
                                    var tuple1 = tupleDict[lastNum];
                                    if (tuple1.Item1 > 0 && tuple1.Item2 > 0)
                                    {
                                        tuple = new Tuple<int, int>(tuple1.Item2, turn);
                                        tupleDict[lastNum] = tuple;
                                    }
                                    else if (tuple1.Item1 > 0 && tuple1.Item2 == 0)
                                    {
                                        tuple = new Tuple<int, int>(tuple1.Item1, turn);
                                        tupleDict[lastNum] = tuple;   
                                    }
                                }
                                else
                                {
                                    tupleDict.Add(lastNum, new Tuple<int, int>(turn, 0));
                                }
                            }
                            else if (tuple.Item1 > 0 && tuple.Item2 == 0)
                            {
                                lastNum = 0;
                                if (tupleDict.Keys.Contains(lastNum))
                                {
                                    var tuple1 = tupleDict[lastNum];
                                    if (tuple1.Item1 > 0 && tuple1.Item2 > 0)
                                    {
                                        tuple = new Tuple<int, int>(tuple1.Item2, turn);
                                        tupleDict[lastNum] = tuple;
                                    }
                                    else if (tuple1.Item1 > 0 && tuple1.Item2 == 0)
                                    {
                                        tuple = new Tuple<int, int>(tuple1.Item1, turn);
                                        tupleDict[lastNum] = tuple;   
                                    }
                                }
                                else
                                {
                                    tupleDict.Add(lastNum, new Tuple<int, int>(turn, 0));
                                }
                            }
                        }
                    }

                    // Console.WriteLine($"Last num = {lastNum}, count = {turn}");
                }
                sw.Stop();
                Console.WriteLine($"Last num = {lastNum}, count = {turn}, Time taken = {sw.Elapsed}");

                // Console.WriteLine($"1 Ans = {Total}");
            }

             public static void Solve2()
            {
                List<int> busNumbers = new List<int>();
                var lines = File.ReadLines(ipPath).ToList();
                long timeStamp;
                List<int> ips = new List<int>();
                List<Tuple<int, int, int>> tuples = new List<Tuple<int, int, int>>();
                Dictionary<int, Tuple<int, int>> tupleDict = new Dictionary<int, Tuple<int, int>>();
                for (var index = 0; index < lines.Count; index++)
                {
                    var line = lines[index];
                    var nums = line.Split(",");
                    for (var idx = 0; idx < nums.Length; idx++)
                    {
                        var num = nums[idx];
                        ips.Add(int.Parse(num));
                        tupleDict.Add(int.Parse(num), new Tuple<int, int>(idx + 1, 0));
                    }
                }

                int turn = ips.Count;
                int lastNum = ips[ips.Count - 1];
                Stopwatch sw = Stopwatch.StartNew();

                while (turn < 30000000)
                {
                    // for (int idx = 0; idx < ips.Count; idx++)
                    {
                        turn++;
                        if (!tupleDict.Keys.Contains(lastNum))
                        {
                            lastNum = 0;
                        }
                        else
                        {
                            var tuple = tupleDict[lastNum];
                            if (tuple.Item1 > 0 && tuple.Item2 > 0)
                            {
                                // tuple = new Tuple<int, int>(tuple.Item2, turn);
                                lastNum = tuple.Item2 - tuple.Item1;
                                if (tupleDict.Keys.Contains(lastNum))
                                {
                                    var tuple1 = tupleDict[lastNum];
                                    if (tuple1.Item1 > 0 && tuple1.Item2 > 0)
                                    {
                                        tuple = new Tuple<int, int>(tuple1.Item2, turn);
                                        tupleDict[lastNum] = tuple;
                                    }
                                    else if (tuple1.Item1 > 0 && tuple1.Item2 == 0)
                                    {
                                        tuple = new Tuple<int, int>(tuple1.Item1, turn);
                                        tupleDict[lastNum] = tuple;   
                                    }
                                }
                                else
                                {
                                    tupleDict.Add(lastNum, new Tuple<int, int>(turn, 0));
                                }
                            }
                            else if (tuple.Item1 > 0 && tuple.Item2 == 0)
                            {
                                lastNum = 0;
                                if (tupleDict.Keys.Contains(lastNum))
                                {
                                    var tuple1 = tupleDict[lastNum];
                                    if (tuple1.Item1 > 0 && tuple1.Item2 > 0)
                                    {
                                        tuple = new Tuple<int, int>(tuple1.Item2, turn);
                                        tupleDict[lastNum] = tuple;
                                    }
                                    else if (tuple1.Item1 > 0 && tuple1.Item2 == 0)
                                    {
                                        tuple = new Tuple<int, int>(tuple1.Item1, turn);
                                        tupleDict[lastNum] = tuple;   
                                    }
                                }
                                else
                                {
                                    tupleDict.Add(lastNum, new Tuple<int, int>(turn, 0));
                                }
                            }
                        }
                    }

                    // Console.WriteLine($"Last num = {lastNum}, count = {turn}");
                }
                sw.Stop();
                Console.WriteLine($"Last num = {lastNum}, count = {turn}, Time taken = {sw.Elapsed}");

                // Console.WriteLine($"1 Ans = {Total}");
            }
    }
}