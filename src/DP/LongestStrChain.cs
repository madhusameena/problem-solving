using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpProblemSolving.DP
{
    // https://leetcode.com/problems/longest-string-chain/submissions/
    internal class LongestStrChain
    {
        public int LongestStrChainProb(string[] words)
        {
            Array.Sort(words, (item1, item2) => item1.Length.CompareTo(item2.Length));
            var n = words.Length;
            // Console.WriteLine($"Len: {n}");
            var dp = new int[n];
            var max = 1;
            for (int i = 0; i < n; i++)
            {
                dp[i] = 1;
                for (int j = 0; j < i; j++)
                {
                    if (CheckPossibility(words[i], words[j]) &&
                       1 + dp[j] > dp[i])
                    {
                        dp[i] = 1 + dp[j];
                    }
                }
                max = Math.Max(dp[i], max);
            }
            return max;
        }
        private bool CheckPossibility(string one, string two)
        {
            if (one.Length - two.Length != 1)
            {
                // Console.WriteLine($"one = {one}, two = {two}, ans: {false}");
                return false;
            }

            int first = 0, second = 0;
            while (first < one.Length)
            {
                if (second < two.Length && one[first] == two[second])
                {
                    first++;
                    second++;
                }
                else
                {
                    first++;
                }
            }
            var res = (first == one.Length && second == two.Length);
            // Console.WriteLine($"one = {one}, two = {two}, ans: {res}");
            return res;
        }
    }
}
