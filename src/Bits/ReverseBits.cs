using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpProblemSolving.Bits
{
	// https://leetcode.com/problems/reverse-bits/
	// https://www.interviewbit.com/problems/reverse-bits/
	public class ReverseBits
	{
		public static void Samples()
		{
			Console.WriteLine(solve(3));
		}
		public static uint reverseBits(uint n)
		{
			uint result = 0;
			for (int i = 0; i < 32; i++)
			{
				if ((n & (1 << i)) != 0)
				{
					result |= (1u << (31 - i));
					//var hx = Convert.ToString(result, 2);
				}
			}
			return result;
		}
		public static long solve(long n)
		{
			uint result = 0;
			for (int i = 0; i < 32; i++)
			{
				if ((n & (1 << i)) != 0)
				{
					result |= (1u << (31 - i));
					var hx = Convert.ToString(result, 2);
				}
			}
			return result;
		}
	}
}
