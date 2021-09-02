using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpProblemSolving.Graphs
{
	// https://leetcode.com/problems/number-of-islands/
	public class NumberOfIslands
	{
		public static void Samples()
		{
			var grid = new char[][] {
				new [] { '1','1','1','1','0'},
				new [] { '1','1','0','0','0'},
				new [] { '1','1','0','0','0'},
				new [] { '0','0','0','0','0'},
			};
		Console.WriteLine(NumIslands(grid));

			grid = new char[][] {
				new [] { '1','1','0','0','0'},
				new [] { '1','1','0','0','0'},
				new [] { '0','0','1','0','0'},
				new [] { '0','0','0','1','1'},
			};
			Console.WriteLine(NumIslands(grid));

		}
		public static int NumIslands(char[][] grid)
		{
			if (grid.Length < 1)
			{
				return 0;
			}
			int islands = 0;
			int rows = grid.Length;
			int cols = grid[0].Length;
			for (int row = 0; row < rows; row++)
			{
				for (int col = 0; col < cols; col++)
				{
					if (grid[row][col] == '1')
					{
						islands++;
						grid[row][col] = '2'; // Make visited
						MarkIsland(grid, row, col, rows, cols);
					}
				}
			}

			return islands;
		}

		private static void MarkIsland(char[][] grid, int row, int col, int rows, int cols)
		{
			// Check in the same row and col
			int newRow = row - 1;
			if (newRow >= 0 && grid[newRow][col] == '1')
			{
				grid[newRow][col] = '2'; // Make visited
				MarkIsland(grid, newRow, col, rows, cols);
			}
			int newCol = col - 1;
			if (newCol >= 0 && grid[row][newCol] == '1')
			{
				grid[row][newCol] = '2'; // Make visited
				MarkIsland(grid, row, newCol, rows, cols);
			}
			newRow = row + 1;
			if (newRow < rows && grid[newRow][col] == '1')
			{
				grid[newRow][col] = '2'; // Make visited
				MarkIsland(grid, newRow, col, rows, cols);
			}
			newCol = col + 1;
			if (newCol < cols && grid[row][newCol] == '1')
			{
				grid[row][newCol] = '2'; // Make visited
				MarkIsland(grid, row, newCol, rows, cols);
			}
		}
	}
}
