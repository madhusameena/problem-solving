using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpProblemSolving.DP
{
    // https://leetcode.com/problems/combination-sum-iv/
    internal class CombinationSumIV
    {
        public int CombinationSum4(int[] nums, int target)
        {
            var dp = new int[target + 1];
            Array.Fill(dp, -1);
            return CombinationSum4(nums, target, dp);
        }
        private int CombinationSum4(int[] nums, int target, int[] dp)
        {
            // Base case
            if (target == 0)
                return 1;

            if (dp[target] != -1)
                return dp[target];
            dp[target] = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] <= target)
                {
                    dp[target] += CombinationSum4(nums, target - nums[i], dp);
                }
            }
            return dp[target];
        }
    }
}
