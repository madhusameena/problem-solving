using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpProblemSolving.Bits
{
	// https://leetcode.com/problems/single-number/
	// https://www.interviewbit.com/problems/single-number/
	public class SingleNumberProblem
	{
		public static int SingleNumber(int[] nums)
		{
			var result = nums[0];
			for (int i = 1; i < nums.Length; i++)
			{
				result ^= nums[i]; // Xor returns 1 -> if bits are diff, else 0, useful to eliminate duplicates
			}
			return result;
		}
	}
}
