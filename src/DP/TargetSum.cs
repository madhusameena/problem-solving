using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpProblemSolving.DP
{
	// https://leetcode.com/problems/target-sum/
	internal class TargetSum
	{
        public static void Samples()
        {
            var obj = new TargetSum();
			//Console.WriteLine(obj.FindTargetSumWays(new int[] { 1, 0, 0 }, 1));
			//Console.WriteLine(obj.FindTargetSumWays(new int[] { 1000 }, -1000));
			Console.WriteLine(obj.FindTargetSumWays(new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 1 }, 1));
        }
		public int FindTargetSumWays(int[] nums, int target)
		{
            // This is another flavor of CountPartitions
            return CountPartitions(nums, target);

        }
        public static int CountPartitions(int[] nums, int k)
        {
            if (nums.Length == 1)
            {
                if (Math.Abs(nums[0]) == Math.Abs(k))
                    return 1;
                return 0;
            }
            int totalSum = 0;
            foreach (var num in nums)
            {
                totalSum += num;
            }
            // s1 + s2 = totalSum, s1 - s2 = k => s1 = (totalSum - k) / 2;
            if ((totalSum - k) % 2 != 0)
            {
                return 0;
            }
            var s1 = (totalSum - k) / 2;
            return SubArraySumWithK.SubarraySumPickAndNotPickConsider0(nums, s1);
		}
    }
}
