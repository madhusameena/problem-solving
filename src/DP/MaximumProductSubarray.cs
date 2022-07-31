using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpProblemSolving.DP
{
    internal class MaximumProductSubarray
    {
        // https://leetcode.com/problems/maximum-product-subarray/
        public int MaxProduct(int[] nums)
        {
            int maxSoFar = nums[0], minSoFar = nums[0], max = nums[0];
            for (int i = 1; i < nums.Length; i++)
            {
                if (nums[i] < 0)
                    (maxSoFar, minSoFar) = (minSoFar, maxSoFar);
                maxSoFar = Math.Max(maxSoFar * nums[i], nums[i]);
                minSoFar = Math.Min(minSoFar * nums[i], nums[i]);
                max = Math.Max(max, maxSoFar);
            }
            return max;
        }
    }
}
