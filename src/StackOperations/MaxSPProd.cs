using System;
using System.Collections.Generic;

namespace CSharpProblemSolving.StackOperations
{
	// https://www.interviewbit.com/problems/maxspprod/
	public static class MaxSPProd
	{
		public static void Samples()
		{
			Console.WriteLine(maxSpecialProductSol(new List<int>() {1, 4, 3, 4}));
			Console.WriteLine(maxSpecialProductSol(new List<int>() {10, 7, 100}));
		}
		
		
		public static int maxSpecialProduct(List<int> A)
		{
			var leftList = new int[A.Count];
			var rightList = new int[A.Count];
			Stack<int> stack = new Stack<int>();
			Stack<int> indexStack = new Stack<int>();
			for (var i = 0; i < A.Count; i++)
			{
				if (stack.Count == 0)
				{
					leftList[i] = 0;
				}
				else
				{
					while (stack.Count > 0 && stack.Peek() <= A[i])
					{
						stack.Pop();
						indexStack.Pop();
					}

					if (indexStack.Count == 0)
					{
						leftList[i] = 0;
					}
					else
					{
						leftList[i] = indexStack.Peek();
					}
				}
				stack.Push(A[i]);
				indexStack.Push(i);
			}
			stack.Clear();
			indexStack.Clear();
			
			for (var i = A.Count - 1; i >= 0; i--)
			{
				if (stack.Count == 0)
				{
					rightList[i] = 0;
				}
				else
				{
					while (stack.Count > 0 && stack.Peek() <= A[i])
					{
						stack.Pop();
						indexStack.Pop();
					}

					if (indexStack.Count == 0)
					{
						rightList[i] = 0;
					}
					else
					{
						rightList[i] = indexStack.Peek();
					}
				}
				stack.Push(A[i]);
				indexStack.Push(i);
			}

			ulong max = ulong.MinValue;
			for (var idx = 0; idx < leftList.Length; idx++)
			{
				ulong mul = (ulong)leftList[idx] * (ulong)rightList[idx];
				max = Math.Max(max, mul);
			}

			return (int) (max % 1000000007);
		}

		// Instead of two stack maintain one stact for index only
		public static int maxSpecialProductSol(List<int> A)
		{
			var leftList = new int[A.Count];
			var rightList = new int[A.Count];
			Stack<int> indexStack = new Stack<int>();
			for (var i = 0; i < A.Count; i++)
			{
				while (indexStack.Count > 0 && A[indexStack.Peek()] <= A[i])
				{
					indexStack.Pop();
				}

				if (indexStack.Count == 0)
				{
					leftList[i] = 0;
				}
				else
				{
					leftList[i] = indexStack.Peek();
				}
				indexStack.Push(i);
			}
			indexStack.Clear();
			
			for (var i = A.Count - 1; i >= 0; i--)
			{
				while (indexStack.Count > 0 && A[indexStack.Peek()] <= A[i])
				{
					indexStack.Pop();
				}

				if (indexStack.Count == 0)
				{
					rightList[i] = 0;
				}
				else
				{
					rightList[i] = indexStack.Peek();
				}
				indexStack.Push(i);
			}

			ulong max = ulong.MinValue;
			for (var idx = 0; idx < leftList.Length; idx++)
			{
				ulong mul = (ulong)leftList[idx] * (ulong)rightList[idx];
				max = Math.Max(max, mul);
			}

			return (int) (max % 1000000007);
		}
	}
}