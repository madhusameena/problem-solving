using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpProblemSolving.BST
{
	// https://www.interviewbit.com/problems/matrix-median/
	public class MatrixMedian
	{
		public static void Samples()
		{
			var data = new MatrixMedian();
			var list = new List<List<int>>();
			list.Add(new List<int>() { 1, 3, 5 });
			list.Add(new List<int>() { 2, 6, 9 });
			list.Add(new List<int>() { 3, 6, 9 });
			Console.WriteLine(data.findMedian(list));
		}
		public int findMedian(List<List<int>> A)
		{
			var rows = A.Count;
			if (rows < 1)
			{
				return -1;
			}
			int cols = A[0].Count;
			int left = int.MaxValue, right = int.MinValue;
			foreach (var list in A) 
			{
				left = Math.Min(left, list[0]);
				right = Math.Max(right, list[list.Count - 1]);
			}
			int desired = rows * cols / 2;
			while (left <= right)
			{
				int mid = left + (right - left) / 2;
				int totalLessNumbers = 0;
				for (int row = 0; row < rows; row++)
				{
					totalLessNumbers += GetLessNumbers(mid, A[row]);
				}
				if (totalLessNumbers <= desired)
				{
					left = mid + 1;
				}
				else
				{
					right = mid - 1;
				}
			}
			return left;
		}

		private int GetLessNumbers(int val, List<int> data)
		{
			int left = 0, right = data.Count - 1;
			while (left <= right)
			{
				var mid = left + (right - left) / 2;
				if (data[mid] <= val)
				{
					left = mid + 1;
				}
				else
				{
					right = mid - 1;
				}
			}
			return left;
		}
	}
}
