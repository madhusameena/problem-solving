using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpProblemSolving.DP
{
    internal class BestSightseeingPair
    {
        // https://leetcode.com/problems/best-sightseeing-pair/
        public int MaxScoreSightseeingPair(int[] values)
        {
            int maxSum = 0, maxSoFar = values[0];
            for (int i = 1; i < values.Length; i++)
            {
                maxSum = Math.Max(maxSum, maxSoFar + values[i] - i);
                maxSoFar = Math.Max(maxSoFar, values[i] + i);
            }
            return maxSum;
        }
    }
}
