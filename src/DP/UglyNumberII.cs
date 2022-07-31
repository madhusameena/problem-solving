using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpProblemSolving.DP
{
    internal class UglyNumberII
    {
        // https://leetcode.com/problems/ugly-number-ii/
        public int NthUglyNumber(int n)
        {
            if (n < 2)
            {
                return n;
            }
            int twoIdx = 0, threeIdx = 0, fiveIdx = 0;
            var dp = new int[n];
            dp[0] = 1;
            for (int i = 1; i < n; i++)
            {
                dp[i] = Math.Min(dp[twoIdx] * 2, Math.Min(dp[threeIdx] * 3, dp[fiveIdx] * 5));
                if (dp[i] == dp[twoIdx] * 2)
                {
                    twoIdx++;
                }
                if (dp[i] == dp[threeIdx] * 3)
                {
                    threeIdx++;
                }
                if (dp[i] == dp[fiveIdx] * 5)
                {
                    fiveIdx++;
                }
            }
            return dp[n - 1];
        }
    }
}
