using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpProblemSolving.Graphs
{
	public class RottingOranges
	{
		public int OrangesRotting(int[][] grid)
		{
			int n = grid.Length, m = 0;
			if (n == 0)
			{
				return 0;
			}

			m = grid[0].Length;
			if (m == 0)
			{
				return 0;
			}
			Queue<(int, int, int)> queue = new Queue<(int, int, int)>();
			int oneCount = 0;
			for (var i = 0; i < n; i++)
			{
				for (int j = 0; j < m; j++)
				{
					if (grid[i][j] == 2)
					{
						queue.Enqueue((0, i, j));
					}

					if (grid[i][j] == 1)
					{
						oneCount++;
					}
				}
			}

			if (queue.Count == 0)
			{
				if (oneCount == 0)
				{
					return 0;
				}
				return -1;
			}

			return ProcessData(queue, grid, m, n);

		}
		private int ProcessData(Queue<(int, int, int)> queue, int[][] grid, int m, int n)
		{
			int days = 0;
			while (queue.Count > 0)
			{
				var item = queue.Dequeue();
				days = item.Item1;
				int i = item.Item2, j = item.Item3;
				if (i - 1 >= 0)
				{
					ValidateAndProcess(grid, queue, i - 1, j, days);
				}

				if (i + 1 < n)
				{
					ValidateAndProcess(grid, queue, i + 1, j, days);
				}

				if (j - 1 >= 0)
				{
					ValidateAndProcess(grid, queue, i, j - 1, days);
				}

				if (j + 1 < m)
				{
					ValidateAndProcess(grid, queue, i, j + 1, days);
				}
			}

			// Find num of 1s -> if not 0 return -1, else return days
			for (var i = 0; i < n; i++)
			{
				for (int j = 0; j < m; j++)
				{
					if (grid[i][j] == 1)
					{
						return -1;
					}
				}
			}

			return days;
		}

		private void ValidateAndProcess(int[][] grid, Queue<(int, int, int)> queue, int i, int j, int days)
		{
			if (grid[i][j] == 1)
			{
				queue.Enqueue((days + 1, i, j));
				grid[i][j] = 2;
			}
		}
	}
}
