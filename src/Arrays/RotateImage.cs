using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpProblemSolving.Arrays
{
	public class RotateImage
	{
		public static void Samples()
		{
			var image = new RotateImage();
			var matrix = new int[4][];
			matrix[0] = new int[4] { 5, 1, 9, 11 };
			matrix[1] = new int[4] { 2, 4, 8, 10 };
			matrix[2] = new int[4] { 13, 3, 6, 7 };
			matrix[3] = new int[4] { 15, 14, 12, 16 };
			image.Rotate(matrix);
			PrintMatrix(matrix);
		}

		private static void PrintMatrix(int[][] matrix)
		{
			var rows = matrix.Length;
			var cols = matrix[0].Length;
			for (int row = 0; row < rows; row++)
			{
				for (int col = 0; col < cols; col++)
				{
					Console.Write($"{matrix[row][col]}\t");
				}
				Console.WriteLine();
			}
		}

		public void Rotate(int[][] matrix)
		{
			var rows = matrix.Length;
			if (rows < 1)
			{
				return;
			}
			var cols = matrix[0].Length;
			if (cols < 1)
			{
				return;
			}
			var originalMatrix = new int[matrix.Length][];
			for (int row = 0; row < rows; row++)
			{
				originalMatrix[row] = new int[cols];
				for (int col = 0; col < cols; col++)
				{
					originalMatrix[row][col] = matrix[row][col];
				}
			}
			// Rotate
			for (int row = 0; row < rows; row++)
			{
				for (int col = 0; col < cols; col++)
				{
					matrix[col][rows - row - 1] = originalMatrix[row][col];
				}
			}
		}
	}
}
