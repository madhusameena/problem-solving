using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpProblemSolving.DP
{
    internal class Largest_Divisible_Subset
    {
        public static void Samples()
        {
            var obj = new Largest_Divisible_Subset();
            var list = obj.LargestDivisibleSubset(new int[] { 1, 2, 3 });
        }
        // https://leetcode.com/problems/largest-divisible-subset/
        public IList<int> LargestDivisibleSubset(int[] nums)
        {
            if (nums.Length == 1)
                return nums;
            var parents = new int[nums.Length];
            var ans = new List<int>();
            var dp = new int[nums.Length];
            Array.Sort(nums);
            int max = int.MinValue, lastIdx = -1;
            for (int i = 0; i < nums.Length; i++)
            {
                parents[i] = i;
                for (int j = 0; j < i; j++)
                {
                    if (nums[i] % nums[j] == 0 &&
                       dp[i] < 1 + dp[j])
                    {
                        dp[i] = 1 + dp[j];
                        parents[i] = j;
                    }
                    if (dp[i] > max)
                    {
                        max = dp[i];
                        lastIdx = i;
                    }
                }
            }
            ans.Add(nums[lastIdx]);
            while (parents[lastIdx] != lastIdx)
            {
                lastIdx = parents[lastIdx];
                ans.Add(nums[lastIdx]);
            }
            ans.Reverse();
            return ans;
        }
    }
}
