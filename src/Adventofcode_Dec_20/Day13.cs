using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CSharpProblemSolving.Adventofcode_Dec_20
{
    public class Day13
    {
            private static long Total = 0;
            private static List<Tuple<string, string>> Tuples = new List<Tuple<string, string>>();
            private static List<string> List = new List<string>();
            private static string ipPath = @"D:\MyProjects\CSharp\CSharpProblemSolving\Adventofcode_Dec_20\d13_ram.txt";


            public static void Solve1()
            {
                List<int> busNumbers = new List<int>();
                var lines = File.ReadLines(ipPath).ToList();
                long timeStamp;
                Console.WriteLine($"Total number of lines = {lines.Count}");
                timeStamp = long.Parse(lines[0]);
                var newLines = lines[1].Split(",");
                for (var index = 0; index < newLines.Length; index++)
                {
                    var line = newLines[index];
                    if (line == "x")
                    {
                        continue;
                    }

                    busNumbers.Add(int.Parse(line));
                }
                List<long> newBus = new List<long>();

                foreach (var busNumber in busNumbers)
                {
                    int num = (int) (((timeStamp ) / busNumber));
                    // Console.WriteLine(num);
                    long test = busNumber * (num + 1);
                    newBus.Add(test);
                }

                foreach (var minTime in newBus)
                {
                    Console.WriteLine($"Mintime = {minTime}");
                }

                var idx = newBus.IndexOf(newBus.Min());
                
                var diff = newBus.Min() - timeStamp;
                var ans = diff * busNumbers[idx];
                Console.WriteLine($"Total = {newBus.Min()}, timestamp = {timeStamp}, diff = {diff}, ans = {ans}, bus num: {busNumbers[idx]}");
            }
            public static void Solve2()
            {
                List<long> busNumbers = new List<long>();
                var lines = File.ReadLines(ipPath).ToList();
                Console.WriteLine($"Total number of lines = {lines.Count}");
                var newLines = lines[1].Split(",");
                List<Tuple<int, int>> BusWithDiff = new List<Tuple<int, int>>();
                int xCOunt = 0;
                for (var index = 0; index < newLines.Length; index++)
                {
                    var line = newLines[index];
                    if (line == "x")
                    {
                        xCOunt++;
                        continue;
                    }

                    BusWithDiff.Add(new Tuple<int, int>(int.Parse(line), xCOunt));
                    xCOunt++;
                    busNumbers.Add(long.Parse(line));
                }

                var newBuses = new List<long>();
                for (int idx = 0; idx < BusWithDiff.Count; idx++)
                {
                    var diff = BusWithDiff[idx];
                    newBuses.Add((long) (diff.Item1 - diff.Item2));
                }
                // var lcm = MadHelper.LcmOfArrayElements(busNumbers.ToArray());
                // Console.WriteLine($"MAD = {lcm}");

                bool doNotBreak = true;
                ulong timeStamp;
                // long num = lcm / busNumbers[0];
                // var max = busNumbers.Max();
                // var maxIndex = busNumbers.IndexOf(max);
                
                var max = busNumbers[0];
                var maxIndex = 0;
                
                var min = busNumbers.Min();
                var minIndex = busNumbers.IndexOf(min);
                long multipleOfTs = max;
                long tempRepeat = 0;
                var timeDiffs = new List<long>();
                for (int idx = 1; idx < BusWithDiff.Count; idx++)
                {
                    // if (idx == maxIndex)
                    // {
                    //     continue;
                    // }

                    doNotBreak = true;
                    multipleOfTs =  max;
                    tempRepeat = 0;
                    while (doNotBreak)
                    {
                        var diff = BusWithDiff[idx];
                        var diffTotal =  BusWithDiff[idx].Item2;
                        if ((multipleOfTs - (long) diffTotal) % (long) diff.Item1 == 0)
                        {
                            doNotBreak = false;
                            var item = multipleOfTs;
                            Console.WriteLine($"Value for idx: {idx}, item = {item}");
                            timeDiffs.Add(item);
                            break;
                        }
                        multipleOfTs += (long) max;
                        tempRepeat++;
                        // Console.WriteLine($"Repeating in min max for idx = {idx} = {tempRepeat}, timestamp = {multipleOfTs}");
                    }
                    
                }

                var test = Mad.MadHelper.LcmOfArrayElements(timeDiffs.ToArray());
                Console.WriteLine($"LCM = {test}");
                Console.WriteLine($"Ans = {test - BusWithDiff[maxIndex].Item2}");
                // while (doNotBreak)
                // {
                //     var diff = BusWithDiff[minIndex];
                //     var diffTotal = BusWithDiff[maxIndex].Item2 - BusWithDiff[minIndex].Item2;
                //     if ((multipleOfTs - (ulong) diffTotal) % (ulong) diff.Item1 == 0)
                //     {
                //         doNotBreak = false;
                //         break;
                //     }
                //     multipleOfTs += (ulong) max;
                //     tempRepeat++;
                //     Console.WriteLine($"Repeating in min max = {tempRepeat}, timestamp = {multipleOfTs}");
                // }
                var maxDiff = BusWithDiff.Max(s => s.Item2);
                var ch = Mad.MadHelper.ChineesFindMinX(busNumbers.ToArray(), BusWithDiff.Select(s => maxDiff - s.Item2).ToArray(), busNumbers.Count);
                Console.WriteLine($"CHinees = {ch}, ans = {ch - maxDiff}");
                Console.WriteLine($"multipleOfTs = {multipleOfTs}");
                // timeStamp =  multipleOfTs;
                // int repeat = 0;
                doNotBreak = true;
                // while (doNotBreak)
                // {
                //     int count = 0;
                //     for (int idx = 0; idx < BusWithDiff.Count; idx++)
                //     {
                //         if (idx == maxIndex)
                //         {
                //             continue;
                //         }
                //         var diff = BusWithDiff[idx];
                //         var diffTotal = BusWithDiff[maxIndex].Item2 - BusWithDiff[idx].Item2;
                //         if ((timeStamp - (ulong) diffTotal) % (ulong) diff.Item1 != 0)
                //         {
                //             timeStamp += (ulong) multipleOfTs;
                //             break;
                //         }
                //         if (idx == BusWithDiff.Count - 2)
                //         {
                //             doNotBreak = false;
                //         }
                //     }
                //
                //     repeat++;
                //     Console.WriteLine($"Repeating = {repeat}, timestamp = {timeStamp}");
                // }

                // var ans = timeStamp - (ulong) BusWithDiff[maxIndex].Item2;
                
                // Console.WriteLine($"Ans = {ans}");
            }
    }
}