using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpProblemSolving.DP
{
    // https://leetcode.com/problems/minimum-path-sum/
    // https://www.interviewbit.com/problems/min-sum-path-in-matrix/
    public class MinimumPathSum
	{
        public int MinPathSum(int[][] grid)
        {
            int m = grid.Length, n = grid[0].Length;
            var dp = new int[m, n];
            int sum = 0;
            for (int i = 0; i < m; i++)
            {
                sum += grid[i][0];
                dp[i, 0] = sum;
            }
            sum = 0;
            for (int i = 0; i < n; i++)
            {
                sum += grid[0][i];
                dp[0, i] = sum;
            }
            for (int i = 1; i < m; i++)
            {
                for (int j = 1; j < n; j++)
                {
                    dp[i, j] = Math.Min(dp[i - 1, j], dp[i, j - 1]) + grid[i][j];
                }
            }
            return dp[m - 1, n - 1];
        }
    }
}
