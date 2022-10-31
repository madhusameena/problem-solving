using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpProblemSolving.DP
{
    // https://leetcode.com/problems/number-of-dice-rolls-with-target-sum/
    internal class Number_of_Dice_Rolls_With_Target_Sum
    {
        public int NumRollsToTarget(int n, int k, int target)
        {
            var dp = new int[31, 1001];
            for (int i = 0; i < 31; i++)
            {
                for (int j = 0; j < 1001; j++)
                {
                    dp[i, j] = -1;
                }
            }
            return NumRollsToTarget(n, k, target, dp);
        }
        int NumRollsToTarget(int n, int k, int target, int[,] dp)
        {
            if (n < 1 || target < 1)
                return 0;
            if (n == 1)
            {
                return target > 0 && target <= k ? 1 : 0;
            }
            if (dp[n, target] != -1)
                return dp[n, target];
            bool add = true;
            long sum = 0;
            for (int i = 1; i <= k; i++)
            {
                int val = NumRollsToTarget(n - 1, k, target - i, dp);
                sum += (val % 1000000007);
            }
            dp[n, target] = (int)(sum % 1000000007);
            return dp[n, target];
        }
    }
}
