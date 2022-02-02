using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpProblemSolving.DP
{
    // https://leetcode.com/problems/house-robber/
    // https://www.youtube.com/watch?v=GrMBfJNk_NY&list=PLgUwDviBIf0qUlt5H_kiKYaNSqJ81PMMY&index=6
    public class HouseRobber
	{
        public int Rob(int[] nums)
        {
            if (nums == null || nums.Length == 0)
            {
                return 0;
            }
            if (nums.Length < 2)
                return nums[0];
            int prev = nums[0], prev2 = 0;
            for (int i = 1; i < nums.Length; i++)
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
