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
            maxSum = Math.Max(sum, maxSum);
            return maxSum;
        }
    }
}
