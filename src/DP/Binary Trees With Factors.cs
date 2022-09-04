using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpProblemSolving.DP
{
    internal class Binary_Trees_With_Factors
    {
        // https://leetcode.com/problems/binary-trees-with-factors/
        public int NumFactoredBinaryTrees(int[] arr)
        {
            const long MOD = (long)(1E9 + 7);
            var dp = new long[arr.Length];
            Array.Fill(dp, 1);
            Array.Sort(arr);
            var hash = new Dictionary<int, int>();

            for (int i = 0; i < arr.Length; i++)
            {
                hash.Add(arr[i], i);
                for (int j = 0; j < i; j++)
                {
                    if (arr[i] % arr[j] != 0)
                        continue;
                    int second = arr[i] / arr[j];
                    if (hash.ContainsKey(second))
                    {
                        dp[i] += (dp[j] * dp[hash[second]]);
                        dp[i] %= MOD;
                    }
                }
            }

            return (int)(dp.Sum() % MOD);
        }
    }
}
