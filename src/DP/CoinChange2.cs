using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpProblemSolving.DP
{
    // https://leetcode.com/problems/coin-change-2/
    internal class CoinChange2
    {
        public int Change(int amount, int[] coins)
        {
            // Console.WriteLine($"{coins.Length}, {amount}");
            var dp = new int[coins.Length, amount + 1];
            for (int i = 0; i <= amount; i++)
            {
                dp[0, i] = i % coins[0] == 0 ? 1 : 0;
            }
            for (int i = 1; i < coins.Length; i++)
            {
                for (int j = 0; j <= amount; j++)
                {
                    int noTake = dp[i - 1, j];
                    int take = 0;
                    if (coins[i] <= j)
                    {
                        take = dp[i, j - coins[i]];
                    }
                    dp[i, j] = take + noTake;
                }
            }
            return dp[coins.Length - 1, amount];

        }
    }
}
