using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpProblemSolving.DP
{
	// https://leetcode.com/problems/partition-equal-subset-sum/
	internal class PartitionEqualSubsetSum
	{
        public static void Samples()
        {
            var obj = new PartitionEqualSubsetSum();
            //Console.WriteLine(obj.CanPartition(new int[] { 1, 2, 5 })); // False
            //Console.WriteLine(obj.CanPartition(new int[] { 14, 9, 8, 4, 3, 2 })); // True
            //Console.WriteLine(obj.CanPartition(new int[] { 2, 2, 3, 5 })); // False
            Console.WriteLine(obj.SubarraySum(new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 1 }, 0));
        }
        public bool CanPartition(int[] nums)
        {
            int totalSum = 0;
            foreach (int num in nums)
                totalSum += num;
            if (totalSum % 2 != 0)
                return false;
			var test = SubarraySumMemo(nums, totalSum / 2);
			Console.WriteLine($"From memo: {test}");
			test = SubarraySumDp(nums, totalSum / 2);
			Console.WriteLine($"From Dp: {test}");
            return test;
        }
        public int SubarraySum(int[] nums, int k)
        {
            Dictionary<int, int> preSumDict = new Dictionary<int, int>();
            int sum = 0, count = 0;
            preSumDict.Add(0, 1); // 0 sum one time - to detect if first val is k
            for (int i = 0; i < nums.Length; i++)
            {
                sum += nums[i];
                var leftSum = sum - k;
                if (preSumDict.ContainsKey(leftSum))
                {
                    count += preSumDict[leftSum];
                }
                if (preSumDict.ContainsKey(sum))
                {
                    preSumDict[sum]++;
                }
                else
                {
                    preSumDict.Add(sum, 1);
                }
            }
            return count;
        }

        private bool SubarraySumTakeNNoTake(int[] nums, int k)
        {
            int n = nums.Length;
            bool[] prev = new bool[k + 1], curr = new bool[k + 1]; // target goes from 0 to k
            prev[0] = curr[0] = true; // target = 0, true
            if (nums[0] <= k)
                prev[nums[0]] = true; // First element, if value == target
            for (int i = 1; i < n; i++)
            {
                for (int target = 1; target <= k; target++)
                {
                    bool notTake = prev[target];
                    bool take = false;
                    if (target >= nums[i])
                        take = prev[target - nums[i]];
                    curr[target] = take || notTake;
                }
                prev = curr;
            }
            return prev[k];
        }
        private bool SubarraySumDp(int[] nums, int k)
        {
            int n = nums.Length;
            var dp = new bool[n, k + 1];
            for (int i = 0; i < n; i++)
                dp[i, 0] = true;
			if (nums[0] <= k)
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
            return dp[n - 1, k];
        }
        private bool SubarraySumMemo(int[] nums, int k)
        {
            int n = nums.Length;
            bool[] prev = new bool[k + 1], curr = new bool[k + 1];
            prev[0] = curr[0] = true;
            if (nums[0] <= k)
            {
                prev[nums[0]] = true;
            }

            for (int i = 1; i < n; i++)
            {
                for (int target = 1; target <= k; target++)
                {
                    bool notTake = prev[target];
                    bool take = false;
                    if (nums[i] <= target)
                    {
                        take = prev[target - nums[i]];
                    }
                    curr[target] = take || notTake;
                }
                prev = curr;
            }
            return prev[k];
        }
    }
}
