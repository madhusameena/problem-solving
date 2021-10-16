using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpProblemSolving.DP
{
	// https://leetcode.com/problems/maximal-square/
	// https://www.youtube.com/watch?v=RElcqtFYTm0
	public class MaxSquare
	{
		public static void Samples()
		{
			var list = new char[2][]
				{
					new char[2] { '0', '1'},
					new char[2] { '1', '0'}
				};
			Console.WriteLine(MaximalSquare(list));
		}
		public static int MaximalSquare(char[][] A)
		{
			int rows = A.Length;
			if (rows < 1)
			{
				return 0;
			}
			int cols = A[0].Length;
			if (cols < 1)
			{
				return 0;
			}
			rows++;
			cols++;
			var matrix = new int[rows, cols];
			int row = 0, col = 0;
			int maxNumber = 0;
			// Make border as 0
			for (col = 0; col < cols; col++)
			{
				matrix[row, col] = 0;
			}
			col = 0;
			for (row = 0; row < rows; row++)
			{
				matrix[row, col] = 0;
			}
			for (row = 1; row < rows; row++)
			{
				for (col = 1; col < cols; col++)
				{
					if (A[row - 1][col - 1] == '0')
					{
						matrix[row, col] = 0;
					}
					else
					{
						int val = 1 + Math.Min(Math.Min(matrix[row - 1, col], matrix[row, col - 1]), matrix[row - 1, col - 1]);

						maxNumber = Math.Max(val, maxNumber);
						matrix[row, col] = val;
					}
				}
			}
			return maxNumber * maxNumber;
		}
	}
}
