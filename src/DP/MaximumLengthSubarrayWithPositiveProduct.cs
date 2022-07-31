using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpProblemSolving.DP
{
    internal class MaximumLengthSubarrayWithPositiveProduct
    {
        // https://leetcode.com/problems/maximum-length-of-subarray-with-positive-product/
        public int GetMaxLen(int[] nums)
        {
            int negativeVals = 0, firstNegative = -1, zeroIdx = -1, maxSum = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] < 0)
                {
                    negativeVals++;
                    if (firstNegative == -1)
                        firstNegative = i;
                }
                if (nums[i] == 0)
                {
                    negativeVals = 0;
                    firstNegative = -1;
                    zeroIdx = i;
                }
                else
                {
                    if (negativeVals % 2 == 0)
                        maxSum = Math.Max(maxSum, i - zeroIdx); // Total result +ve
                    else
                        maxSum = Math.Max(maxSum, i - firstNegative); // Ignore first -ve idx
                }
            }
            return maxSum;
        }
    }
}
