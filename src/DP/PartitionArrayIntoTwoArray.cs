using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpProblemSolving.DP
{
    // https://leetcode.com/problems/partition-array-into-two-arrays-to-minimize-sum-difference/
    internal class PartitionArrayIntoTwoArray
	{
        public static void Samples()
        {
            var obj = new PartitionArrayIntoTwoArray();
            Console.WriteLine(obj.MinimumDifference(new int[] { -36, 36 })); // 72
			Console.WriteLine(obj.MinimumDifference(new int[] { 2, -1, 0, 4, -2, -9 })); // 0
            //Console.WriteLine(obj.MinimumDifference(new int[] { 2, 2, 3, 5 })); // False
		}
        public int MinimumDifference(int[] nums)
        {
			if (nums.Length % 2 != 0)
			{
                return 0;
			}
            var dp = new Dictionary<string, int>();
            return MinimumDifferenceDp(nums, 0, 0, 0, 0, 0, dp);
        }
        public int MinimumDifferenceDp(int[] nums, int sum1, int sum2, int count1, int count2, int index, Dictionary<string, int> dp)
        {
            // Base case 1
            if (count1 == nums.Length / 2 && count2 == count1)
            {
                return Math.Abs(sum1 - sum2);
            }
            // Base case 2 - If we reach beyond the count
            if (index >= nums.Length)
            {
                return 999999999;// some high value - not max to avoid int overflow;
            }
            var key = $"{sum1}${sum2}${count1}${count2}${index}";
			// Check in dp
			if (dp.ContainsKey(key))
			{
                return dp[key];
			}
            // Push current element to one element
            int takeOne = MinimumDifferenceDp(nums, sum1 + nums[index], sum2, count1 + 1, count2, index + 1, dp);
            // Push current element to second element
            int takeTwo = MinimumDifferenceDp(nums, sum1, sum2 + nums[index], count1, count2 + 1, index + 1, dp);
            dp[key] = Math.Min(takeOne, takeTwo);
            return dp[key];
        }
        private int SubarraySumDp(int[] nums, int k)
        {
            int n = nums.Length;
            var dp = new bool[n, k + 1];
            for (int i = 0; i < n; i++)
                dp[i, 0] = true;
            if (nums[0] <= k && nums[0] >= 0)
            {
                dp[0, nums[0]] = true;
            }

            for (int i = 1; i < n; i++)
            {
                for (int target = 1; target <= k; target++)
                {
                    bool notTake = dp[i - 1, target];
                    bool take = false;
                    if (nums[i] <= target)
                    {
                        take = dp[i - 1, target - nums[i]];
                    }
                    dp[i, target] = take || notTake;
                }
            }
            int min = int.MaxValue;
            for (int i = 0; i <= k / 2; i++)
            {
                if (dp[n - 1, i])
                {
                    min = Math.Min(min, Math.Abs((k - i) - i));
                }
            }
            return min;
        }
    }
}
