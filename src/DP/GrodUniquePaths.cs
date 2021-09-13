using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpProblemSolving.DP
{
	// https://leetcode.com/problems/unique-paths/
	// https://www.interviewbit.com/problems/grid-unique-paths/
	public class GrodUniquePaths
	{
		public int UniquePaths(int m, int n)
		{
			var dpArray = new int[m, n];
			// Fill first row with all 1s coz we can finish the fist row in one way only,
			// Similarly for first column
			for (int col = 0; col < n; col++)
			{
				dpArray[0, col] = 1;
			}
			for (int row = 0; row < m; row++)
			{
				dpArray[row, 0] = 1;
			}
			// For remaining value add top and left values - as we can reach the item from top or left (i.e. robot can move either right or bottom)
			for (int row = 1; row < m; row++)
			{
				for (int col = 1; col < n; col++)
				{
					dpArray[row, col] = dpArray[row - 1, col] + dpArray[row, col - 1];
				}
			}
			return dpArray[m - 1, n - 1];
		}
	}
}
