using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpProblemSolving.Graphs
{
    // https://leetcode.com/problems/max-area-of-island/
    internal class Max_Area_of_Island
    {
        public int MaxAreaOfIsland(int[][] grid)
        {
            int m = grid.Length, n = grid[0].Length, maxArea = 0;

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (grid[i][j] == 1)
                    {
                        int currArea = 0;
                        Dfs(i, j, grid, m, n, ref currArea);
                        maxArea = Math.Max(maxArea, currArea);
                    }
                }
            }
            return maxArea;
        }
        void Dfs(int row, int col, int[][] grid, int m, int n, ref int len)
        {
            if (row < 0 || row >= m || col < 0 || col >= n ||
               grid[row][col] != 1)
                return;
            len++;
            grid[row][col] = 2;
            Dfs(row - 1, col, grid, m, n, ref len);
            Dfs(row + 1, col, grid, m, n, ref len);
            Dfs(row, col - 1, grid, m, n, ref len);
            Dfs(row, col + 1, grid, m, n, ref len);
        }
    }
}
