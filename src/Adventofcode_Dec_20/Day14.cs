using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace CSharpProblemSolving.Adventofcode_Dec_20
{
    public class Day14
    {
            private static long Total = 0;
            private static List<Tuple<string, string>> Tuples = new List<Tuple<string, string>>();
            private static List<string> List = new List<string>();
            private static string ipPath = @"D:\MyProjects\CSharp\CSharpProblemSolving\Adventofcode_Dec_20\Day14.txt";
            static Dictionary<int, long> MemValues = new Dictionary<int, long>();


            public static void Solve2()
            {
                List<int> busNumbers = new List<int>();
                var lines = File.ReadLines(ipPath).ToList();
                Dictionary<long, long> dictValues = new Dictionary<long, long>();
                Console.WriteLine($"Total number of lines = {lines.Count}");
                List<Tuple<int, int>> GivenVlaues = new List<Tuple<int, int>>();
                string maskStr = "mask = ";
                string mask = "";
                for (var index = 0; index < lines.Count; index++)
                {
                    var line = lines[index];
                    if (index != 0 && line.Contains(maskStr))
                    {
                        ProcessData(mask, GivenVlaues, dictValues);
                        var idx = line.IndexOf(maskStr) + maskStr.Length;
                        mask = line.Substring(idx);
                        GivenVlaues.Clear();
                    }
                    else if (index == 0)
                    {
                        var idx = line.IndexOf(maskStr) + maskStr.Length;
                        mask = line.Substring(idx);
                    }
                    else
                    {
                        var test = line.Split(" = ");
                        string memStr = "mem[";
                        var idx1 = test[0].IndexOf(memStr) + memStr.Length;
                        var idx2 = test[0].IndexOf("]");
                        var left = int.Parse(test[0].Substring(idx1, idx2 - idx1));
                        var right = int.Parse(test[1]);
                        // Console.WriteLine($"left = {left}, right = {right}");
                        GivenVlaues.Add(new Tuple<int, int>(left, right));
                    }
                    if (index == lines.Count - 1)
                    {
                        ProcessData(mask, GivenVlaues, dictValues);
                        break;
                    }
                }


                long len = 0;
                foreach (var dictValue in dictValues)
                {
                    len += dictValue.Value;
                }

                Console.WriteLine($"2 Ans = {len}");
            }

            private static void ProcessData(string mask, List<Tuple<int, int>> givenVlaues,
                Dictionary<long, long> dictValues)
            {
                foreach (var givenValue in givenVlaues)
                {
                    int val = givenValue.Item1;
                    var test = Convert.ToString(val, 2);
                    int left = mask.Length - test.Length;
                    string str = new string('0', left);
                    var address = str + test;
                    // var test = val.ToString("";
                    // Console.WriteLine($"v = {address}");
                    // Console.WriteLine($"m = {mask}");
                    var newMask = new char[address.Length];
                    for (var index = 0; index < newMask.Length; index++)
                    {
                        var c = address[index];
                        newMask[index] = c;
                    }

                    List<int> indexes = new List<int>();
                    for (int idx = address.Length - 1; idx >= 0; idx--)
                    {
                        var mask1 = mask[idx];
                        var val1 = address[idx];
                        if (mask1 == 'X' || val1 == 'X')
                        {
                            newMask[idx] = 'X';
                            indexes.Add(idx);
                        }
                        else if (mask1 == '1' || val1 == '1')
                        {
                            newMask[idx] = '1';
                        }
                        else
                        {
                            newMask[idx] = '0';
                        }
                    }

                    var list = GetStr(0, indexes, newMask);
                    List<string> combinationValues = new List<string>();
                    foreach (var item in list)
                    {
                        StringBuilder str1 = new StringBuilder();
                        foreach (var c in item)
                        {
                            str1.Append(c.ToString());
                        }
                        combinationValues.Add(str1.ToString());
                        // Console.WriteLine(str1.ToString());
                    }

                    List<long> intVals = new List<long>();
                    foreach (var combinationValue in combinationValues)
                    {
                        var longVal = Convert.ToInt64(combinationValue, 2);
                        if (dictValues.Keys.Contains(longVal))
                        {
                            dictValues[longVal] = givenValue.Item2;
                        }
                        else
                        {
                            dictValues.Add(longVal, givenValue.Item2);
                        }
                    }
                }
            }

            private static List<long> GetIntVals(string mask, List<string> combinationValues)
            {
                List<long> ansList = new List<long>();
                foreach (var combinationValue in combinationValues)
                {
                    char[] ans = new char[combinationValue.Length];
                    for (int idx = 0; idx < combinationValue.Length; idx++)
                    {
                        if (mask[idx] == 'X')
                        {
                            ans[idx] = combinationValue[idx];
                        }
                        else if (mask[idx] == '0' && combinationValue[idx] == '0')
                        {
                            ans[idx] = '0';
                        }
                        else if (mask[idx] == '1' && combinationValue[idx] == '1')
                        {
                            ans[idx] = '1';
                        }
                        else if (mask[idx] == '1' && combinationValue[idx] == '0')
                        {
                            ans[idx] = '1';
                        }
                        else
                        {
                            ans[idx] = '0';
                        }
                    }
                    StringBuilder str1 = new StringBuilder();
                    foreach (var c in ans)
                    {
                        str1.Append(c.ToString());
                    }

                    var test = Convert.ToInt64(str1.ToString(), 2);
                    // Console.WriteLine($"Int = {test}");
                    ansList.Add(test);
                    
                }
                return ansList;
            }

            private static List<char[]> GetStr(int idx, List<int> indexes, char[] arr)
            {
                var list = new List<char[]>();
                char[] testArray1 = new Char[arr.Length];
                char[] testArray2 = new Char[arr.Length];
                testArray1 = new Char[arr.Length];
                for (var index = 0; index < arr.Length; index++)
                {
                    var c = arr[index];
                    testArray1[index] = c;
                    if (index == indexes[idx])
                    {
                        testArray1[index] = '0';
                    }
                }
                list.Add(testArray1);
                for (var index = 0; index < arr.Length; index++)
                {
                    var c = arr[index];
                    testArray2[index] = c;
                    if (index == indexes[idx])
                    {
                        testArray2[index] = '1';
                    }
                }
                list.Add(testArray2);
                if (idx == indexes.Count - 1)
                {
                    return list;
                }
                else
                {
                    list.Clear();
                    var nextIdx = idx + 1;
                    list.AddRange(GetStr(nextIdx, indexes, testArray1));   
                    list.AddRange(GetStr(nextIdx, indexes, testArray2));   
                }
                return list;
            }

            public static void Solve1()
            {
                List<long> busNumbers = new List<long>();
                var lines = File.ReadLines(ipPath).ToList();
                Console.WriteLine($"Total number of lines = {lines.Count}");
                string maskStr = "mask = ";
                string mask = "";
                var dictValues = new Dictionary<int, long>();
                for (var index = 0; index < lines.Count; index++)
                {
                    var line = lines[index];
                    if (line.Contains(maskStr))
                    {
                        var idx = line.IndexOf(maskStr) + maskStr.Length;
                        mask = line.Substring(idx);
                    }
                    else
                    {
                        var test = line.Split(" = ");
                        string memStr = "mem[";
                        var idx1 = test[0].IndexOf(memStr) + memStr.Length;
                        var idx2 = test[0].IndexOf("]");
                        var left = int.Parse(test[0].Substring(idx1, idx2 - idx1));
                        var right = int.Parse(test[1]);
                        int val = right;
                        var dec = Convert.ToString(val, 2);
                        int rem = mask.Length - dec.Length;
                        string str = new string('0', rem);
                        var address = str + dec;
                        // Console.WriteLine($"left = {left}, right = {right}, address = {address}");
                        
                        long ans = GetIntVals(mask, new List<string>() { address})[0];
                        
                        if (dictValues.Keys.Contains(left))
                        {
                            dictValues[left] = ans;
                        }
                        else
                        {
                            dictValues.Add(left, ans);
                        }
                    }
                }

                long ans1 = 0;
                foreach (var value in dictValues)
                {
                    ans1 += value.Value;
                }

                Console.WriteLine($"1 Ans = {ans1}");
            }
    }
}