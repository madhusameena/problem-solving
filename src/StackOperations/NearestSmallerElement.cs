using System;
using System.Collections.Generic;

namespace CSharpProblemSolving.StackOperations
{
	public static class NearestSmallerElement
	{
		public static void Samples()
		{
			var list = new List<int>() {34, 35, 27, 42, 5, 28, 39, 20, 28};
			var op = prevSmaller(list);
			foreach (var i in op)
			{
				Console.Write($"{i}  ");
			}

			Console.WriteLine();
			
			list = new List<int>() {39, 27, 11, 4, 24, 32, 32, 1};
			op = prevSmaller(list);
			foreach (var i in op)
			{
				Console.Write($"{i}  ");
			}
		}

		public static List<int> prevSmaller(List<int> A)
		{
			List<int> op = new List<int>();
			Stack<int> stack = new Stack<int>();
			foreach (var i in A)
			{
				while (stack.Count > 0 && stack.Peek() >= i)
				{
					stack.Pop();
				}

				if (stack.Count == 0)
				{
					op.Add(-1);
				}
				else
				{
					op.Add(stack.Peek());
				}
				stack.Push(i);
			}

			return op;
		}
	}
}