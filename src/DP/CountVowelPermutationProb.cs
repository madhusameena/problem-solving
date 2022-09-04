using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpProblemSolving.DP
{
    // https://leetcode.com/problems/count-vowels-permutation/
    internal class CountVowelPermutationProb
    {
        public int CountVowelPermutation(int n)
        {
            const long MOD = (long)1E9 + 7;
            var dp = new long[5][];
            for (int i = 0; i < 5; i++)
            {
                dp[i] = new long[n + 1];
                dp[i][1] = 1;
            }
            for (int i = 2; i < n + 1; i++)
            {
                dp[0][i] = dp[1][i - 1];
                dp[1][i] = (dp[0][i - 1] + dp[2][i - 1]) % MOD;
                dp[2][i] = (dp[0][i - 1] + dp[1][i - 1] + dp[3][i - 1] + dp[4][i - 1]) % MOD;
                dp[3][i] = (dp[2][i - 1] + dp[4][i - 1]) % MOD;
                dp[4][i] = dp[0][i - 1];
            }
            long sum = 0;
            for (int i = 0; i < 5; i++)
            {
                sum = (sum + dp[i][n]) % MOD;
            }
            return (int)sum;
        }
    }
}
