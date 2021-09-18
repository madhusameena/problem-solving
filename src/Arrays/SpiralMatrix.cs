using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpProblemSolving.Arrays
{
	// https://leetcode.com/explore/challenge/card/september-leetcoding-challenge-2021/638/week-3-september-15th-september-21st/3977/
	public class SpiralMatrix
	{
		public static void Samples()
		{
			var matrix = new int[3][];
			matrix[0] = new int[] { 1, 2, 3, 4 };
			matrix[1] = new int[] { 5, 6, 7, 8 };
			matrix[2] = new int[] { 9, 10, 11, 12 };
			var list = SpiralOrder(matrix);
			foreach (var item in list)
			{
				Console.Write($"{item}\t");
			}
		}
		public static IList<int> SpiralOrder(int[][] matrix)
		{
			int rows = matrix.Length;
			int cols = matrix[0].Length;
			var list = new List<int>(rows * cols);
			var visited = new bool[rows, cols];
			list.Add(matrix[0][0]);
			visited[0, 0] = true;
			ProcessData(matrix, list, true, true, 0, 0, rows, cols, visited);

			return list;
		}

		private static void ProcessData(int[][] matrix, List<int> list, bool horizontal, bool increasing, int startX, int startY, int rows, int cols, bool[,] visited)
		{
			if (horizontal)
			{
				if (increasing)
				{
					for (int i = startY + 1; i < cols; i++)
					{
						if (visited[startX, i])
						{
							ProcessData(matrix, list, false, true, startX, i, rows, cols , visited);
							return;
						}
						list.Add(matrix[startX][i]);
						visited[startX, i] = true;
					}
					ProcessData(matrix, list, false, true, startX, cols - 1, rows, cols, visited);
					return;
				}
				else
				{
					for (int i = startY - 1; i >= 0; i--)
					{
						if (visited[startX, i])
						{
							ProcessData(matrix, list, false, false, startX, i, rows, cols, visited);
							return;
						}
						list.Add(matrix[startX][i]);
						visited[startX, i] = true;
					}
					ProcessData(matrix, list, false, false, startX, 0, rows, cols, visited);
					return;
				}
			}
			else
			{
				if (increasing)
				{
					for (int i = startX + 1; i < rows; i++)
					{
						if (visited[i, startY])
						{
							ProcessData(matrix, list, true, false, i, startY, rows, cols, visited);
							return;
						}
						list.Add(matrix[i][startY]);
						visited[i, startY] = true;
					}
					ProcessData(matrix, list, true, false, rows - 1, startY, rows, cols, visited);
					return;
				}
				else
				{
					for (int i = startX - 1; i >= 0; i--)
					{
						if (visited[i, startY])
						{
							ProcessData(matrix, list, true, true, i, startY, rows, cols, visited);
							return;
						}
						list.Add(matrix[i][startY]);
						visited[i, startY] = true;
					}
					ProcessData(matrix, list, true, true, 0, startY, 0, cols, visited);
					return;
				}
			}
		}
	}
}
