using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpProblemSolving.Graphs
{
	// https://leetcode.com/problems/surrounded-regions/
	// https://www.interviewbit.com/problems/capture-regions-on-board/
	public class SurroundedRegions
	{
		// https://www.youtube.com/watch?v=0ZJViJEdtEc
		public void Solve(char[][] board)
		{
			// Mark boundary and its region 0s as 1 (to make they are visited)
			int rows = board.Length;
			if (rows < 1)
			{
				return;
			}
			int cols = board[0].Length;
			if (cols < 1)
			{
				return;
			}
			int row = 0, col = 0;
			for (col = 0; col < cols; col++)
			{
				if (board[row][col] == 'O')
				{
					Dfs(board, row, col, rows, cols);
				}
			}
			row = rows - 1;
			for (col = 0; col < cols; col++)
			{
				if (board[row][col] == 'O')
				{
					Dfs(board, row, col, rows, cols);
				}
			}
			col = 0;
			for (row = 0; row < rows; row++)
			{
				if (board[row][col] == 'O')
				{
					Dfs(board, row, col, rows, cols);
				}
			}
			col = cols - 1;
			for (row = 0; row < rows; row++)
			{
				if (board[row][col] == 'O')
				{
					Dfs(board, row, col, rows, cols);
				}
			}
			// Mark them

			for (row = 0; row < rows; row++)
			{
				for (col = 0; col < cols; col++)
				{
					if (board[row][col] == '1')
					{
						board[row][col] = 'O';// boarder Os
					}
					else if (board[row][col] == 'O')
					{
						board[row][col] = 'X';
					}
				}
			}
		}

		private void Dfs(char[][] board, int row, int col, int rows, int cols)
		{
			board[row][col] = '1';// visited
			int newRow = row - 1;
			if (newRow > 0 && board[newRow][col] == 'O')
			{
				Dfs(board, newRow, col, rows, cols);
			}
			newRow = row + 1;
			if (newRow < rows && board[newRow][col] == 'O')
			{
				Dfs(board, newRow, col, rows, cols);
			}

			int newCol = col - 1;
			if (newCol > 0 && board[row][newCol] == 'O')
			{
				Dfs(board, row, newCol, rows, cols);
			}
			newCol = col + 1;
			if (newCol < cols && board[row][newCol] == 'O')
			{
				Dfs(board, row, newCol, rows, cols);
			}
		}
	}
}
