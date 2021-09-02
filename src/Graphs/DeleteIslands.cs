using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpProblemSolving.Graphs
{
	// https://leetcode.com/discuss/interview-question/354563/google-phone-screen-delete-islands
	public class DeleteIslands
	{
		public static void Samples()
		{
			var grid = new char[][] {
					new [] { '0','0','0','1','1','1'},
					new [] { '0','0','0','1','1','1'},
					new [] { '1','1','1','1','1','1'},
					new [] { '1','1','1','1','1','1'},
					new [] { '1','1','1','1','1','1'},
			};
			DelIslands(grid);
			PrintGrid(grid);

		}

		private static void PrintGrid(char[][] grid)
		{
			int rows = grid.Length;
			int cols = grid[0].Length;
			for (int row = 0; row < rows; row++)
			{
				for (int col = 0; col < cols; col++)
				{
					Console.Write($"{grid[row][col]}\t");
				}
				Console.WriteLine();
			}
		}

		public static void DelIslands(char[][] grid)
		{
			if (grid.Length < 1)
			{
				return;
			}
			int rows = grid.Length;
			int cols = grid[0].Length;
			HashSet<(int, int)> islandsToMark = new HashSet<(int, int)>();
			bool[,] visited = new bool[rows, cols];
			for (int row = 0; row < rows; row++)
			{
				for (int col = 0; col < cols; col++)
				{
					visited[row, col] = false;
				}
			}

			for (int row = 0; row < rows; row++)
			{
				for (int col = 0; col < cols; col++)
				{
					if (grid[row][col] == '1' && !visited[row, col])
					{
						visited[row, col] = true; // Make visited
						DelIslands(grid, visited, islandsToMark, row, col, rows, cols);
					}
				}
			}
			foreach (var item in islandsToMark)
			{
				grid[item.Item1][item.Item2] = '0';
			}
		}
		private static void DelIslands(char[][] grid, bool[,] visited, HashSet<(int, int)> islandsToMark, int row, int col, int rows, int cols)
		{
			// Check all sides
			if (row - 1 >= 0 &&
				col - 1 >= 0 &&
				row + 1 < rows &&
				col + 1 < cols &&
				grid[row - 1][col] == '1' &&
				grid[row + 1][col] == '1' &&
				grid[row][col - 1] == '1' &&
				grid[row][col + 1] == '1'
				)
			{
				islandsToMark.Add((row, col));
			}

			// Check in the same row and col
			int newRow = row - 1;
			if (newRow >= 0 && grid[newRow][col] == '1' && !visited[newRow, col])
			{
				visited[newRow, col] = true; // Make visited
				DelIslands(grid, visited, islandsToMark, newRow, col, rows, cols);
			}
			int newCol = col - 1;
			if (newCol >= 0 && grid[row][newCol] == '1' && !visited[row, newCol])
			{
				visited[row, newCol] = true; // Make visited
				DelIslands(grid, visited, islandsToMark, row, newCol, rows, cols);
			}
			newRow = row + 1;
			if (newRow < rows && grid[newRow][col] == '1' && !visited[newRow, col])
			{
				visited[newRow, col] = true; // Make visited
				DelIslands(grid, visited, islandsToMark, newRow, col, rows, cols);
			}
			newCol = col + 1;
			if (newCol < cols && grid[row][newCol] == '1' && !visited[row, newCol])
			{
				visited[row, newCol] = true; // Make visited
				DelIslands(grid, visited, islandsToMark, row, newCol, rows, cols);
			}
		}
	}
}
