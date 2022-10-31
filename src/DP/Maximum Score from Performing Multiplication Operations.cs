using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpProblemSolving.DP
{
    // https://leetcode.com/problems/maximum-score-from-performing-multiplication-operations/
    internal class Maximum_Score_from_Performing_Multiplication_Operations
    {
        public int MaximumScore(int[] nums, int[] multipliers)
        {
            var dp = new int[1001][];
            for (int i = 0; i < 1001; i++)
            {
                dp[i] = new int[1001];
                Array.Fill(dp[i], int.MinValue);
            }
            return MaximumScore(nums, multipliers, 0, 0, dp);
        }
        public int MaximumScore(int[] nums, int[] multipliers, int i, int left, int[][] dp)
        {
            if (i >= multipliers.Length)
                return 0;
            if (dp[i][left] != int.MinValue)
                return dp[i][left];
            int right = nums.Length - 1 - (i - left);
            int leftSum = nums[left] * multipliers[i] + MaximumScore(nums, multipliers, i + 1, left + 1, dp);
            int rightSum = nums[right] * multipliers[i] + MaximumScore(nums, multipliers, i + 1, left, dp);
            dp[i][left] = Math.Max(leftSum, rightSum);
            return dp[i][left];
        }
    }
}
