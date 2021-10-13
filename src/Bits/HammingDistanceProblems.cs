using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpProblemSolving.Arrays
{
	// https://www.interviewbit.com/problems/sum-of-pairwise-hamming-distance/
	// https://leetcode.com/problems/total-hamming-distance/
	// https://www.youtube.com/watch?v=L_fIn5TM3mM
	public class HammingDistanceProblems
	{
		public int TotalHammingDistance(int[] nums)
		{
			// We count pairs by comparing number of 1s(n) and 0s(m) at the same index -> multiply n with m will give number of pairs with different bits
			int sum = 0;
			for (int i = 0; i < 32; i++) // 32 bit int
			{
				int n = 0, m = 0;
				foreach (var num in nums)
				{
					// Check bit set at each index for give num
					if (BitSet(num, i))
					{
						n++;
					}
				}
				m = nums.Length - n;
				sum += (n * m);// count num of bits
			}
			return sum;
		}
		private bool BitSet(int num, int index)
		{
			return (num & (1 << index)) != 0;
		}
		// https://leetcode.com/problems/hamming-distance/
		public int HammingDistance(int x, int y)
		{
			int sum = 0;
			for (int i = 0; i < 32; i++) // 32 bit int
			{
				int n = 0, m = 0;
				if (BitSet(x, i))
				{
					n++;
				}
				if (BitSet(y, i))
				{
					n++;
				}
				
				m = 2 - n;
				sum += (n * m);// count num of bits
			}
			return sum;
		}
		// https://www.youtube.com/watch?v=I475waWiTK4
		public int HammingDistanceUsingXor(int x, int y)
		{
			var diffBits = x ^ y;
			// Find number of 1s in diffBits
			// Lets use Kernighan's algo (instead of checking every bit - check right most significant bit (rbs))
			// We can find rbs using n & -n ; -n = ~n + 1
			int count = 0;
			while (diffBits > 0)
			{
				int rsb = diffBits & -diffBits;
				diffBits -= rsb;
				count++;
			}
			return count;
		}
	}
}
