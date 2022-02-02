using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpProblemSolving.DP
{
	// https://leetcode.com/problems/climbing-stairs/
	internal class ClimbStairsProblem
	{
		public int ClimbStairs(int n)
		{
			var dp = new int[n];
			for (int i = 0; i < n; i++)
			{
				dp[i] = -1;
			}
			return ClimbStairsRecursive(n, dp);
		}

		private int ClimbStairsRecursive(int n, int[] dp)
		{
			if (n < 3)
			{
				return n;
			}
			if (dp[n - 1] != -1)
			{
				return dp[n - 1];
			}
			dp[n - 1] = ClimbStairsRecursive(n - 1, dp) + ClimbStairsRecursive(n - 2, dp);
			return dp[n - 1];
		}
	}
}
