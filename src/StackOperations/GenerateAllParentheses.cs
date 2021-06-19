using System;
using System.Collections.Generic;

namespace CSharpProblemSolving.StackOperations
{
	// https://www.interviewbit.com/problems/generate-all-parentheses/
	public static class GenerateAllParentheses
	{
		public static void Samples()
		{
			string test = "({[]})";
			Console.WriteLine(isValid(test));
			
			test = "()[]{}";
			Console.WriteLine(isValid(test));
			
			test = "(){";
			Console.WriteLine(isValid(test));
			test = "])";
			Console.WriteLine(isValid(test));
		}

		public static int isValid(string A)
		{
			Stack<char> stack = new Stack<char>();
			for (var idx = 0; idx < A.Length; idx++)
			{
				char ch = A[idx];
				if (ch == '(' || ch == '[' || ch == '{')
				{
					stack.Push(ch);
					continue;
				}
				if (ch == ')' || ch == ']' || ch == '}')
				{
					if (stack.Count == 0)
					{
						return 0;
					}
				}
				if (ch == '}')
				{
					char pop = stack.Pop();
					if (pop != '{')
					{
						return 0;
					}
				}
				else if (ch == ']')
				{
					var pop = stack.Pop();
					if (pop != '[')
					{
						return 0;
					}
				}
				else if (ch == ')')
				{
					var pop = stack.Pop();
					if (pop != '(')
					{
						return 0;
					}
				}
				else
				{
					return 0;
				}
			}

			return stack.Count == 0 ? 1 : 0;
		}
	}
}