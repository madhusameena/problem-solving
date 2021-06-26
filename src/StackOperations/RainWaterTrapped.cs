using System;
using System.Collections.Generic;

namespace CSharpProblemSolving.StackOperations
{
	public static class RainWaterTrapped
	{
		public static void Samples()
		{
			Console.WriteLine(trapTwoPointers(new List<int>{ 0, 1, 0, 2, 1, 0, 1, 3, 2, 1, 2, 1 }));
			Console.WriteLine(trapTwoPointers(new List<int>{ 1, 2 }));
		}

		// https://www.youtube.com/watch?v=EdR3V5DBgyo
		// When we get current is larger than stack.peek
		// 1.	Pop element, 2 will be removed, save A[pop] in dipVal, which is 0
		// 2.	Now check water for this,
		//		a.	dist = right – left - 1, right = current, left = stack.peek
		// 		b.	Find min of left and right => Math.Min(A[stack.peek], A[current])
		//		c.	Water = dist * (min – dip)

		public static int trapStack(List<int> A)
		{
			if (A.Count < 3)
			{
				return 0;
			}
			Stack<int> stackIndexes = new Stack<int>();
			int water = 0;
			for (var i = 0; i < A.Count; i++)
			{
				int num = A[i];
				while (stackIndexes.Count > 0 && num > A[stackIndexes.Peek()])
				{
					int dipIndex = stackIndexes.Pop();
					if (stackIndexes.Count == 0)
					{
						break;
					}
					int dist = i - stackIndexes.Peek() - 1;
					int min = Math.Min(A[stackIndexes.Peek()], A[i]);
					water += (dist * (min - A[dipIndex]));
				}
				stackIndexes.Push(i);
			}

			return water;
		}

		// https://www.youtube.com/watch?v=C8UjlJZsHBw
		public static int trapTwoPointers(List<int> A)
		{
			if (A.Count < 3)
			{
				return 0;
			}

			int water = 0;
			int leftIdx = 1, rightIdx = A.Count - 2;
			int leftMax = A[0], rightMax = A[^1];
			while (leftIdx <= rightIdx)
			{
				if (leftMax < rightMax)
				{
					// Fill left side
					if (leftMax > A[leftIdx])
					{
						water += (leftMax - A[leftIdx]);
					}
					else
					{
						leftMax = A[leftIdx];
					}
					leftIdx++;
				}
				else
				{
					// Fill right side
					if (rightMax > A[rightIdx])
					{
						water += rightMax - A[rightIdx];
					}
					else
					{
						rightMax = A[rightIdx];
					}
					rightIdx--;
				}
			}

			return water;
		}
	}
}