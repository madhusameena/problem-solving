using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpProblemSolving.DP
{
	// https://www.interviewbit.com/problems/max-rectangle-in-binary-matrix/
	public class LargestRectangleInterviewBit
	{
		public int maximalRectangle(List<List<int>> A)
		{
			int rows = A.Count;
			if (rows < 1)
			{
				return 0;
			}
			int cols = A[0].Count;
			if (cols < 1)
			{
				return 0;
			}
			int maxArea = 0;
			// Construct Histograms
			var rectangleAreas = new List<List<int>>(rows);
			for (int row = 0; row < rows; row++)
			{
				var newRow = new List<int>(cols);
				for (int col = 0; col < cols; col++)
				{
					if (row == 0)
					{
						newRow.Add(A[row][col]);
					}
					else
					{
						if (A[row][col] == 0)
						{
							newRow.Add(0);
						}
						else
						{
							newRow.Add(1 + rectangleAreas[row - 1][col]);
						}
					}
				}
				rectangleAreas.Add(newRow);
			}
			for (int row = 0; row < rows; row++)
			{
				var item = rectangleAreas[row];
				maxArea = Math.Max(maxArea, largestRectangleArea(item));
			}

			return maxArea;
		}
		// https://leetcode.com/problems/largest-rectangle-in-histogram/
		public int largestRectangleArea(List<int> A)
		{
			Stack<int> stack = new Stack<int>();
			int[] leftList = new int[A.Count];
			int[] rightList = new int[A.Count];
			for (var idx = 0; idx < A.Count; idx++)
			{
				// Pop elements till we find element which is less then the actual one, if we add 1 we will get left max val for the current element
				while (stack.Count > 0 && A[stack.Peek()] >= A[idx])
				{
					stack.Pop();
				}
				if (stack.Count == 0)
				{
					leftList[idx] = 0;
				}
				else
				{
					leftList[idx] = stack.Peek() + 1;
				}
				stack.Push(idx);
			}
			stack.Clear();
			for (var i = A.Count - 1; i >= 0; i--)
			{
				// Pop elements till we find element which is less then the actual one, if we remove 1 we will get right max val for the current element
				while (stack.Count > 0 && A[stack.Peek()] >= A[i])
				{
					stack.Pop();
				}

				if (stack.Count == 0)
				{
					rightList[i] = A.Count - 1;
				}
				else
				{
					rightList[i] = stack.Peek() - 1;
				}
				stack.Push(i);
			}

			int max = int.MinValue;
			for (var idx = 0; idx < leftList.Length; idx++)
			{
				int area = A[idx] * (rightList[idx] - leftList[idx] + 1);
				max = Math.Max(max, area);
			}

			return max;
		}
	}
}
