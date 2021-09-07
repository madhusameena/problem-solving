using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpProblemSolving.DP
{
	// https://leetcode.com/problems/longest-increasing-path-in-a-matrix/
	// https://www.interviewbit.com/problems/increasing-path-in-matrix/
	public class IncreasingPathInMatrix
	{
		//public int LongestIncreasingPath(int[][] matrix)
		//{

		//}

		public static void Samples()
		{
			var list = new List<List<int>>();
			list.Add(new List<int>() { 1, 2, 3, 4 });
			list.Add(new List<int>() { 2, 2, 3, 4 });
			list.Add(new List<int>() { 3, 2, 3, 4 });
			list.Add(new List<int>() { 4, 5, 6, 7 });
			var item = new IncreasingPathInMatrix();
			Console.WriteLine(item.solve(list));

			list = new List<List<int>>();
			list.Add(new List<int>() { 5, 2 });
			list.Add(new List<int>() { 3, 4 });
			item = new IncreasingPathInMatrix();
			//Console.WriteLine(item.solve(list));
		}
		public int solve(List<List<int>> A)
		{
			var rows = A.Count;
			if (rows < 1)
			{
				return 0;
			}
			var cols = A[0].Count;
			
			var dp = new int[rows, cols];
			int row = 0, col = 1;
			for (row = 0; row < rows; row++)
			{
				for (col = 0; col < cols; col++)
				{
					dp[row, col] = -1;
				}
			}

			dp[0, 0] = 1;
			// Fill first row;
			row = 0;
			for (col = 1; col < cols; col++)
			{
				if (A[row][col] > A[row][col - 1] && dp[row, col -1] != -1)
				{
					dp[row, col] = 1 + dp[row, col - 1];
				}
			}
			col = 0;
			// Fill first col
			for (row = 1; row < rows; row++)
			{
				if (A[row][col] > A[row - 1][col] && dp[row - 1, col] != -1)
				{
					dp[row, col] = 1 + dp[row - 1, col];
				}
			}
			// fill complete data
			for (row = 1; row < rows; row++)
			{
				for (col = 1; col < cols; col++)
				{
					if (A[row][col] > A[row][col - 1] && dp[row, col - 1] != -1)
					{
						dp[row, col] = 1 + dp[row, col - 1];
					}
					if (A[row][col] > A[row - 1][col] && dp[row - 1, col] != -1)
					{
						dp[row, col] = 1 + dp[row - 1, col];
					}
				}
			}
			return dp[rows - 1, cols - 1];
		}
		public int solve__(List<List<int>> A)
		{
			var rows = A.Count;
			if (rows < 1)
			{
				return 0;
			}
			var cols = A[0].Count;
			if (cols > 1 && rows > 1 &&
				A[0][0] >= A[1][0] &&
				A[0][0] >= A[0][1])
			{
				return -1;
			}
			var dp = new int[rows, cols];
			for (int row = 0; row < rows; row++)
			{
				for (int col = 0; col < cols; col++)
				{
					dp[row, col] = -1;
				}
			}
			//dp[0, 0] = 1;
			dp[rows - 1, cols - 1] = 1;
			Dps(A, dp, 0, 0, rows, cols);
			//if (rows > 1)
			//{
			//	Dps(A, dp, 1, 0, rows, cols);
			//}
			//if (cols > 1)
			//{
			//	Dps(A, dp, 0, 1, rows, cols);
			//}
			return dp[0, 0];
			if (dp[rows - 1, cols - 1] == 1)
			{
				int row = rows - 1, col = cols - 1;
				int right = -1, bottom = -1;
				if (row > 0 &&A[row][col] > A[row - 1][col])
				{
					right = 1 + dp[row - 1, col];
				}
				if (col > 0 &&A[row][col] > A[row][col - 1])
				{
					bottom = 1 + dp[row, col - 1];
				}
				return Math.Max(right, bottom);
			}
			return -1;
		}

		private int Dps(List<List<int>> A, int[,] dp, int row, int col, int rows, int cols)
		{
			if (dp[row, col] != -1)
			{
				return dp[row, col];
			}
			int right = 0, bottom = 0;
			if (row < rows - 1 && A[row + 1][col] > A[row][col])
			{
				right = 1 + Dps(A, dp, row + 1, col, rows, cols);
			}
			if (col < cols - 1 && A[row][col + 1] > A[row][col])
			{
				bottom = 1 + Dps(A, dp, row, col + 1, rows, cols);
			}
			
			dp[row, col] = Math.Max(right, bottom);
			return dp[row, col];
		}
	}
}
