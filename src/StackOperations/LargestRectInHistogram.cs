using System;
using System.Collections.Generic;

namespace CSharpProblemSolving.StackOperations
{
	// https://www.interviewbit.com/old/problems/largest-rectangle-in-histogram/
	public static class LargestRectInHistogram
	{
		public static void Samples()
		{
			Console.WriteLine(largestRectangleArea(new List<int>() { 2, 1, 5, 6, 2, 3 }));
		}
		// https://www.youtube.com/watch?v=vcv3REtIvEo
		public static int largestRectangleArea(List<int> A)
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
				while (stack.Count > 0 && A[stack.Peek()] > A[i])
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