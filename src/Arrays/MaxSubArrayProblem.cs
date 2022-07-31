using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpProblemSolving.Arrays
{
	// https://leetcode.com/problems/maximum-subarray/
	// https://www.interviewbit.com/problems/max-sum-contiguous-subarray/
	// https://www.youtube.com/watch?v=YxuK6A3SvTs
	public class MaxSubArrayProblem
	{
        public int MaxSubArrayUsingKadaneAlgo(int[] A)
        {
            int sum = A[0], maxSum = A[0];
            for (int i = 1; i < A.Length; i++)
            {
                int num = A[i];
                sum += num;
                if (sum < num)
                {
                    sum = num;
                }
                maxSum = Math.Max(sum, maxSum);
            }
            return maxSum;
        }
        // https://leetcode.com/problems/maximum-sum-circular-subarray/
        public int MaxSubarraySumCircular(int[] nums)
        {
            int currMin = nums[0], currMax = nums[0], max = nums[0], min = nums[0], total = nums[0];
            for (int i = 1; i < nums.Length; i++)
            {
                currMin = Math.Min(currMin + nums[i], nums[i]);
                currMax = Math.Max(currMax + nums[i], nums[i]);
                min = Math.Min(min, currMin);
                max = Math.Max(max, currMax);
                total += nums[i];
            }
            return max > 0 ? Math.Max(max, total - min) : max;
        }
    }
}
