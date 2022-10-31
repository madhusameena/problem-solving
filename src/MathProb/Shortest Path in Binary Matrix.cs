using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpProblemSolving.MathProb
{
    // https://leetcode.com/problems/shortest-path-in-binary-matrix/
    internal class Shortest_Path_in_Binary_Matrix
    {
        private List<(int, int)> _dirs = new List<(int, int)>(8)
    {
        (-1, -1),
        (-1, 0),
        (-1, 1),
        (0, -1),
        (0, 1),
        (1, -1),
        (1, 0),
        (1, 1)
    };

        public int ShortestPathBinaryMatrix(int[][] grid)
        {
            int m = grid.Length;
            if (grid[0][0] != 0 || grid[m - 1][m - 1] != 0)
                return -1;
            var queue = new Queue<(int, int, int)>();
            queue.Enqueue((0, 0, 0));
            grid[0][0] = -1; // Visited
            return Search(grid, queue);
        }
        int Search(int[][] grid, Queue<(int, int, int)> queue)
        {
            while (queue.Count > 0)
            {
                // Console.WriteLine($"Queue count = {queue.Count}");
                var item = queue.Dequeue();
                if (item.Item2 == grid.Length - 1 && item.Item1 == grid.Length - 1)
                    return 1 + item.Item3;
                foreach (var dir in _dirs)
                {
                    int x = item.Item1 + dir.Item1, y = item.Item2 + dir.Item2;
                    if (x >= 0 && y >= 0 && x < grid.Length && y < grid.Length && grid[x][y] == 0)
                    {
                        queue.Enqueue((x, y, item.Item3 + 1));
                        grid[x][y] = -1;
                    }
                }
            }
            return -1;
        }
    }
}
