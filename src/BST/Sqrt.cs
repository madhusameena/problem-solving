using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpProblemSolving.BST
{
	// https://leetcode.com/problems/sqrtx/
	// https://www.interviewbit.com/problems/square-root-of-integer/
	public class Sqrt
	{
		public int MySqrt(int x)
		{
			if (x < 2)
			{
				return x;
			}
			int left = 1, right = x, ans = 0;
			while (left <= right)
			{
				int mid = left + (right - left) / 2;
				if (mid <= x / mid)
				{
					ans = mid;
					left = mid + 1;
				}
				else
				{
					right = mid - 1;
				}
			}
			return ans;
		}
	}
}
