using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpProblemSolving.DP
{
	// https://leetcode.com/problems/unique-paths-ii/
	internal class GridUniquePathsII
	{
		public int UniquePathsWithObstacles(int[][] obstacleGrid)
		{
			int m = obstacleGrid.Length;
			int n = obstacleGrid[0].Length;
			var prev = new int[n];
			for (int i = 0; i < m; i++)
			{
				var curr = new int[n];
				for (int j = 0; j < n; j++)
				{
					if (obstacleGrid[i][j] == 1)
					{
						curr[j] = 0;
					}
					else if (i == 0 && j == 0)
					{
						curr[i] = 1;
					}
					else
					{
						int top = 0, left = 0;
						if (i > 0)
						{
							top = prev[j];
						}
						if (j > 0)
						{
							left = curr[j - 1];
						}
						curr[j] = top + left;
					}
				}
				prev = curr;
			}
			return prev[n - 1];
		}
	}
}
