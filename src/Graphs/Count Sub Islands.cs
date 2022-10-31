using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpProblemSolving.Graphs
{
    // https://leetcode.com/problems/count-sub-islands/
    internal class Count_Sub_Islands
    {
        public int CountSubIslands(int[][] grid1, int[][] grid2)
        {
            int m = grid2.Length, n = grid2[0].Length, count = 0;
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (grid2[i][j] == 1 && grid1[i][j] == 0) // Mark all unmatched islands to visited
                    {
                        Dfs(i, j, grid2, m, n);
                    }
                }
            }
            // Now count the islands
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (grid2[i][j] == 1)
                    {
                        Dfs(i, j, grid2, m, n);
                        count++;
                    }
                }
            }

            return count;
        }
        void Dfs(int i, int j, int[][] grid, int m, int n)
        {
            if (i < 0 || j < 0 || i > m - 1 || j > n - 1 || // Border cases
                grid[i][j] == 0)  // Already visited
            {
                return;
            }
            grid[i][j] = 0; // Mark visited
            Dfs(i - 1, j, grid, m, n);
            Dfs(i + 1, j, grid, m, n);
            Dfs(i, j - 1, grid, m, n);
            Dfs(i, j + 1, grid, m, n);
        }
    }
}
