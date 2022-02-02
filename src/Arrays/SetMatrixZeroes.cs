using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpProblemSolving.Arrays
{
	// https://leetcode.com/problems/set-matrix-zeroes/
	internal class SetMatrixZeroes
	{
		public static void Samples()
		{

		}
		public void SetZeroes(int[][] matrix)
		{
			var hashX = new HashSet<int>();
			var hashY = new HashSet<int>();

			for (int i = 0; i < matrix.Length; i++)
			{
				for (int j = 0; j < matrix[i].Length; j++)
				{
					if (matrix[i][j] == 0)
					{
						hashX.Add(i);
						hashY.Add(j);
					}
				}
			}

			for (int i = 0; i < matrix.Length; i++)
			{
				for (int j = 0; j < matrix[i].Length; j++)
				{
					if ((hashX.Contains(i) || hashY.Contains(j)) &&
						matrix[i][j] != 0)
					{
						matrix[i][j] = 0;
					}
				}
			}
		}
		// https://www.youtube.com/watch?v=M65xBewcqcI&list=PLgUwDviBIf0rPG3Ictpu74YWBQ1CaBkm2&index=8&ab_channel=takeUforward
		public void SetZeroesWithNoExtraSpace(int[][] matrix)
		{
			bool isCol = false;
			for (int row = 0; row < matrix.Length; row++)
			{
				if (matrix[row][0] == 0)
				{
					isCol = true;
				}
				for (int col = 1; col < matrix[row].Length; col++)
				{
					if (matrix[row][col] == 0)
					{
						matrix[row][0] = matrix[0][col] = 0;
					}
				}
			}
			for (int row = matrix.Length - 1; row >= 0; row--)
			{
				for (int col = matrix[0].Length - 1; col >= 1; col--)
				{
					if (matrix[row][0] == 0 || matrix[0][col] == 0)
					{
						matrix[row][col] = 0;
					}
				}
				if (isCol)
				{
					matrix[row][0] = 0;
				}
			}
		}
	}
}
