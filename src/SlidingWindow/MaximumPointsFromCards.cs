using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpProblemSolving.SlidingWindow
{
    // https://leetcode.com/problems/maximum-points-you-can-obtain-from-cards/
    internal class MaximumPointsFromCards
    {
        public int MaxScore(int[] cardPoints, int k)
        {
            int n = cardPoints.Length;
            int remLen = cardPoints.Length - k;
            if (remLen == 0)
            {
                return cardPoints.Sum();
            }
            // Find window min sum with n - k num of elements no need in circular array - as max is circular, min should not
            // be circular way
            int minSum = int.MaxValue, sum = 0, i = 0, j = 0;
            k = n - k;
            for (; j < cardPoints.Length; j++)
            {
                sum += cardPoints[j % n];
                if (j - i + 1 > k)
                {
                    sum -= cardPoints[i % n];
                    i++;
                }
                if (j - i + 1 == k)
                {
                    minSum = Math.Min(minSum, sum);
                }
            }
            return cardPoints.Sum() - minSum;
        }
    }
}
