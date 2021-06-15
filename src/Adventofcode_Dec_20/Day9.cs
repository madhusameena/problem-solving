using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.WebSockets;
using System.Text;

namespace CSharpProblemSolving.Adventofcode_Dec_20
{
    public static class Day9
    {
        private static long Total = 0;
        static List<List<bool>>dp = new List<List<bool>>();
        public static void Solve()
        {
            string ipPath = @"D:\MyProjects\CSharp\CSharpProblemSolving\Adventofcode_Dec_20\Day9.txt";
            var lines = File.ReadLines(ipPath).ToList();
            Console.WriteLine($"Total number of lines = {lines.Count}");
            var newLines = new List<string>();
            var list = new List<long>();
            for (int idx = 0; idx < lines.Count(); idx++)
            {
                var line = lines[idx];
                list.Add(long.Parse(line));
            }

            long num = 0;
            for (int idx = 25; idx < list.Count; idx++)
            {
                num = list[idx];
                var newList = new List<long>();
                var maxNum = num - 1;
                var minNum = maxNum - 25;
                for (long i = minNum + 1; i <= maxNum; i++)
                {
                    newList.Add(i);
                }
                
                if (!ProcessData(list.GetRange(idx - 25, 25), num))
                {
                    Console.WriteLine($"First ans NUMBER = {num}");
                    break;
                    // return;
                }
            
            }
            var idx1 = list.IndexOf(num);
            long sum = 0;
            List<long> req = new List<long>();
            for (int i = 0; i < idx1; i++)
            {
                for (int j = i; j < idx1; ++j)
                {
                    sum += list[j];
                    if (sum == num)
                    {
                        Console.WriteLine($"i = {i}, j= {j}");
                        var req1 = list.GetRange(i, (j - i));
                        Console.WriteLine($"2nd Sum = {req1.Min() + req1.Max()}");
                        break;
                    }
                    else if (sum > num)
                    {
                        sum = 0;
                        break;
                    }
                }
            }

        }

       
        private static bool ProcessData(List<long> list, long num)
        {
            var data = Mad.MadHelper.GetPermutations(list, 2);
            int count = 0;
            long x1 = 0;
            long x2 = 0;
            foreach (var varData in data)
            {
                for (int idx = 0; idx < list.Count; idx++)
                {
                    for (int idx1 = 1; idx1 < list.Count; idx1++)
                    {
                        if (list[idx] + list[idx1] == num)
                        {
                            // Console.WriteLine($"newData[0] = {newData[0]}, newData[1] = {newData[1]}");
                            if (count != 1)
                            {
                                // if ((x1 == newData[0] && 
                                //     x2 == newData[1])||
                                //     (x1 == newData[1] && 
                                //      x2 == newData[0]))
                                // {
                                //     continue;
                                // }
                            }

                            x1 = list[idx];
                            x2 = list[idx1];
                            if (count == 1)
                            {
                                return true;
                            }
                            count++;
                        }
                        
                    }
                }
                // var newData = varData.ToList();
                // if (newData.Count != 2)
                // {
                //     throw new InvalidDataException("Not right");
                // }
                //
                // if (newData[0] + newData[1] == num)
                // {
                //     Console.WriteLine($"newData[0] = {newData[0]}, newData[1] = {newData[1]}");
                //     if (count != 1)
                //     {
                //         // if ((x1 == newData[0] && 
                //         //     x2 == newData[1])||
                //         //     (x1 == newData[1] && 
                //         //      x2 == newData[0]))
                //         // {
                //         //     continue;
                //         // }
                //     }
                //
                //     x1 = newData[0];
                //     x2 = newData[1];
                //     if (count == 1)
                //     {
                //         return true;
                //     }
                //     count++;
                // }
            }
            return false;
        }
        static void printSubsetsRec(long[] arr, int i, long sum, List<long> p) 
        { 
            // If we reached end and sum is non-zero. We print 
            // p[] only if arr[0] is equal to sun OR dp[0][sum] 
            // is true. 
            if (i == 0 && sum != 0 && dp[0][(int) sum]) 
            { 
                // p.push_back(arr[i]);
                p.Add(arr[i]);
                display(p); 
                return; 
            } 
  
            // If sum becomes 0 
            if (i == 0 && sum == 0) 
            { 
                display(p); 
                return; 
            } 
  
            // If given sum can be achieved after ignoring 
            // current element. 
            if (dp[i-1][(int) sum]) 
            { 
                // Create a new vector to store path 
                List<long> b = p;
                printSubsetsRec(arr, i-1, sum, b); 
            } 
  
            // If given sum can be achieved after considering 
            // current element. 
            if (sum >= arr[i] && dp[i-1][(int) (sum-arr[i])]) 
            { 
                p.Add(arr[i]);
                printSubsetsRec(arr, i-1, sum-arr[i], p); 
            } 
        } 
  
// Prints all subsets of arr[0..n-1] with sum 0. 
        static void printAllSubsets(long[] arr, int n, long sum) 
        { 
            if (n == 0 || sum < 0) 
                return; 
  
            // Sum 0 can always be achieved with 0 elements 
            dp = new List<List<bool>>(); 
            for (int i=0; i<n; ++i) 
            { 
                dp[i] = new List<bool>(); 
                dp[i][0] = true; 
            } 
  
            // Sum arr[0] can be achieved with single element 
            if (arr[0] <= sum) 
                dp[0][(int) arr[0]] = true; 
  
            // Fill rest of the entries in dp[][] 
            for (int i = 1; i < n; ++i) 
            for (int j = 0; j < sum + 1; ++j) 
                dp[i][j] = (arr[i] <= j) ? dp[i-1][j] || 
                                           dp[i-1][(int) (j-arr[i])] 
                    : dp[i - 1][j]; 
            if (dp[n-1][(int) sum] == false) 
            {
                Console.WriteLine("There are no subsets with sum %d\n", sum); 
                return; 
            } 
  
            // Now recursively traverse dp[][] to find all 
            // paths from dp[n-1][sum] 
            List<long> p = new List<long>();
            printSubsetsRec(arr, n-1, sum, p); 
        } 
        static void display(List<long> v) 
        { 
            for (int i = 0; i < v.Count; ++i)
                Console.WriteLine(v[i]);
            
        } 
    }
}