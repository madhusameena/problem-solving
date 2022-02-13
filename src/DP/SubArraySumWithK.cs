using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpProblemSolving.DP
{
    // https://leetcode.com/problems/subarray-sum-equals-k/submissions/
    // https://www.youtube.com/watch?app=desktop&v=HbbYPQc-Oo4
    public class SubArraySumWithK
	{
        public static void Samples()
        {
			Console.WriteLine(SubarraySumPickAndNotPick(new int[] { 1, -1, 0}, 0));
			Console.WriteLine(SubarraySumPickAndNotPick(new int[] { 1, 1, 1 }, 2));
        }
        // https://www.youtube.com/watch?v=20v8zSo2v18
        public static int SubarraySumSol2(int[] nums, int k)
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
        public static int SubarraySumPickAndNotPick(int[] nums, int k)
        {
            int n = nums.Length;
            int[] prev = new int[k + 1], curr = new int[k + 1];
            prev[0] = curr[0] = 1; // when sum == 0, return one count;
            if (nums[0] <= k && nums[0] >= 0)
            {
                prev[nums[0]] = 1;
            }
            for (int i = 1; i < n; i++)
            {
                for (int j = 0; j <= k; j++)
                {
                    int notPick = prev[j];
                    int pick = 0;
                    if (nums[i] <= j)
                    {
                        pick = prev[j - nums[i]];
                    }
                    curr[j] = pick + notPick;
                }
                prev = curr;
            }
            return prev[k];
        }
        public static int SubarraySumPickAndNotPickConsider0(int[] nums, int k)
        {
            int n = nums.Length;
            int[] prev = new int[k + 1], curr = new int[k + 1];
			if (nums[0] == 0)
			{
                prev[0] = 2; // Two ways, can include or not include
			}
			else
			{
                prev[0] = 1;
			}
            if (nums[0] <= k && nums[0] >= 0)
            {
                prev[nums[0]] = 1;
            }
            for (int i = 1; i < n; i++)
            {
                for (int j = 0; j <= k; j++)
                {
                    int notPick = prev[j];
                    int pick = 0;
                    if (nums[i] <= j)
                    {
                        pick = prev[j - nums[i]];
                    }
                    curr[j] = pick + notPick;
                }
                prev = curr;
            }
            return prev[k];
        }
        // https://www.codingninjas.com/codestudio/problems/partitions-with-given-difference_3751628
        public static int CountPartitions(int[] nums, int k)
        {
            int totalSum = 0;
            foreach (var num in nums)
            {
                totalSum += num;
            }
            // s1 + s2 = totalSum, s1 - s2 = k => s1 = (totalSum - k) / 2;
            var s1 = (totalSum - k) / 2;
            if ((totalSum - k) % 2 != 0)
			{
                return 0;
			}
            return SubarraySumSol2(nums, s1);
            // Or return SubarraySumPickAndNotPick(nums, s1);
        }
        public static int SubarraySum(int[] nums, int k)
        {
            Dictionary<int, int> preSumDict = new Dictionary<int, int>();
            var list = new List<string>();
            int sum = 0, count = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                sum += nums[i];
                if (sum == k)
                {
                    count++;
                }
                if (preSumDict.ContainsKey(sum - k))
                {
                    count += preSumDict[sum - k];
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
    }
}
