using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpProblemSolving.DP
{
	// https://leetcode.com/problems/house-robber-ii
	internal class HouseRobberII
	{
        public int Rob(int[] nums)
        {
            if (nums.Length == 1)
            {
                return nums[0];
            }

            if (nums.Length == 2)
            {
                return Math.Max(nums[0], nums[1]);
            }
            // Calculate max value by ignoring first and last and find max value
            int maxIgnoringStart = RobWithIgnore(nums, true);
            int maxIgnoringEnd = RobWithIgnore(nums, false);
            return Math.Max(maxIgnoringStart, maxIgnoringEnd);
        }
        private int RobWithIgnore(int[] nums, bool ignoreFirst)
        {
            int prev = nums[0];
            int length = nums.Length - 1;
            int startIdx = 1;
            if (ignoreFirst)
            {
                prev = nums[1];
                length++;
                startIdx++;
            }
            int prev2 = 0;
            for (int i = startIdx; i < length; i++)
            {
                int pick = nums[i] + prev2;
                int nonPick = prev;
                int max = Math.Max(pick, nonPick);
                prev2 = prev;
                prev = max;
            }
            return prev;
        }
    }
}
