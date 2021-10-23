using System.Collections.Generic;

namespace CSharpProblemSolving.Bits
{
	// https://www.interviewbit.com/problems/different-bits-sum-pairwise/
	// https://leetcode.com/discuss/interview-question/algorithms/125145/sum-of-count-of-different-bits
	// https://www.youtube.com/watch?v=L_fIn5TM3mM
	public class DifferentBitsSumPairwise
	{
		public int cntBits(List<int> A)
		{
			int result = 0;
			for (int i = 0; i < 32; i++) // 32 bit
			{
				int oneCount = 0, zeroCount;
				foreach (var item in A)
				{
					if ((item & 1 << i) != 0)
					{
						oneCount++;
					}
				}
				zeroCount = A.Count - oneCount;
				result += (oneCount * zeroCount * 2);
			}
			return result;
		}
	}
}
