using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpProblemSolving.DP
{
    // https://leetcode.com/problems/find-eventual-safe-states/
    internal class _01_Matrix
    {
        public int[][] UpdateMatrix(int[][] mat)
        {
            int m = mat.Length, n = mat[0].Length;
            var dp = new int[m][];
            // Default val of 99999
            for (int i = 0; i < m; i++)
            {
                dp[i] = new int[n];
                for (int j = 0; j < n; j++)
                {
                    dp[i][j] = 99999;
                }
            }

            // 1st iteration, top - bottom, left - right
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (mat[i][j] == 1)
                    {
                        if (i > 0)
                        {
                            dp[i][j] = Math.Min(dp[i][j], 1 + dp[i - 1][j]);
                        }
                        if (j > 0)
                        {
                            dp[i][j] = Math.Min(dp[i][j], 1 + dp[i][j - 1]);
                        }
                    }
                    else
                        dp[i][j] = 0;
                }
            }

            // 2nd iteration, buttom - up, right - left
            for (int i = m - 1; i >= 0; i--)
            {
                for (int j = n - 1; j >= 0; j--)
                {
                    if (mat[i][j] == 1)
                    {
                        if (i + 1 < m)
                        {
                            dp[i][j] = Math.Min(dp[i][j], 1 + dp[i + 1][j]);
                        }
                        if (j + 1 < n)
                        {
                            dp[i][j] = Math.Min(dp[i][j], 1 + dp[i][j + 1]);
                        }
                    }
                    else
                        dp[i][j] = 0;
                }
            }
            return dp;
        }
    }
}
