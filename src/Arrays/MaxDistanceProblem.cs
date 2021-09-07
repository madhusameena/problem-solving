using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpProblemSolving.Arrays
{
    // https://www.youtube.com/watch?v=SO0bwMziLlU
    // https://www.interviewbit.com/problems/max-distance/
    // https://www.youtube.com/watch?v=Zyhxzg0WLWA
    public class MaxDistanceProblem
	{
        public static void Samples()
        {
            var list = new List<int>() { 1, 10 };
			Console.WriteLine(maximumGap(list));
        }
        public static int maximumGap(List<int> A)
        {
            if (A.Count < 2)
            {
                return 0;
            }
            var leftMin = new int[A.Count];
            leftMin[0] = A[0];
            var rightMax = new int[A.Count];
            rightMax[A.Count - 1] = A[A.Count - 1];
			for (int i = 1; i < A.Count; i++)
			{
                leftMin[i] = Math.Min(leftMin[i - 1], A[i]);
			}
			for (int i = A.Count - 2; i >= 0; i--)
			{
                rightMax[i] = Math.Max(rightMax[i + 1], A[i]);
			}
            int i1 = 0, i2 = 0, diff = 0;
			while (i1 < A.Count && i2 < A.Count)
			{
				if (leftMin[i1] <= rightMax[i2]) // Max exists at i2, so increment i2 and check again
				{
                    diff = Math.Max(diff, i2 - i1);
                    i2++;
				}
				else
				{
                    i1++;
				}
			}
            return diff;
        }
        public int maximumGapMine(List<int> A)
        {
            if (A.Count < 2)
            {
                return 0;
            }
            int i1 = 0, i2 = 1;
            int dist = A[i1] <= A[i2] ? 1 : 0;
            int maxDist = dist;
            for (int i = 2; i < A.Count; i++)
            {
                i2 = i;
                if (A[i2] >= A[i1])
                {
                    dist = i2 - i1;
                }
                else
                {
                    i1++;
                    i2 = i1;
                    i = i2;
                    maxDist = Math.Max(maxDist, dist);
                }
            }
            maxDist = Math.Max(maxDist, dist);
            return maxDist;
        }
    }
}
