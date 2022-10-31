using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpProblemSolving.Graphs
{
    // https://leetcode.com/problems/number-of-closed-islands/
    internal class Number_of_Closed_Islands
    {
        public int ClosedIsland(int[][] grid)
        {
            int m = grid.Length, n = grid[0].Length, count = 0;
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (grid[i][j] == 0 && Dfs(i, j, grid, m, n))
                    {
                        count++;
                    }
                }
            }
            return count;
        }
        bool Dfs(int row, int col, int[][] grid, int m, int n)
        {
            if (row < 0 || row > m - 1 || col < 0 || col > n - 1) // 0s at border - cannot consider them
                return false;
            if (grid[row][col] == 1)
                return true;
            grid[row][col] = 1; // Mark visited
            var d1 = Dfs(row - 1, col, grid, m, n);
            var d2 = Dfs(row + 1, col, grid, m, n);
            var d3 = Dfs(row, col - 1, grid, m, n);
            var d4 = Dfs(row, col + 1, grid, m, n);
            return d1 && d2 && d3 && d4;
        }
    }
}
