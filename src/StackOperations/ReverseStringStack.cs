using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpProblemSolving.StackOperations
{
	// https://www.interviewbit.com/problems/reverse-string/
	public static class ReverseStringStack
	{
		public static void Samples()
		{
			var str = "NewMadhu";
			Console.WriteLine(reverseString(str));
			
			str = "T";
			Console.WriteLine(reverseString(str));
		}

		public static string reverseString(string A)
		{
			if (string.IsNullOrEmpty(A) || A.Length == 1)
			{
				return A;
			}
			var stack = new Stack<char>(A.Length);
			for (var i = 0; i < A.Length; i++)
			{
				stack.Push(A[i]);
			}

			var sb = new StringBuilder(A.Length);
			while (stack.Count != 0)
			{
				sb.Append(stack.Pop());
			}

			return sb.ToString();
		}
	}
}