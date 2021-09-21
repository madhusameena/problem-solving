using System;
using System.Collections.Generic;

namespace CSharpProblemSolving.StackOperations
{
	// https://www.interviewbit.com/problems/balanced-parantheses/
	public static class BalancedParantheses
	{
		public static void Samples()
		{
			Console.WriteLine(solve("(()())"));
			Console.WriteLine(solve("(()"));
			Console.WriteLine(solve("(())"));
		}
		public static int solve(string A)
		{
			if (string.IsNullOrEmpty(A))
			{
				return 0;
			}
			Stack<char> stack = new Stack<char>(A.Length);
			int frontCount = 0, backCount = 0;
			
			for (var idx = 0; idx < A.Length; idx++)
			{
				if (A[idx] == ')')
				{
					if (stack.Count == 0)
					{
						return 0;
					}

					if (stack.Pop() != '(')
					{
						return 0;
					}

					backCount++;
				}
				else
				{
					stack.Push(A[idx]);
					frontCount++;
				}
			}

			if (stack.Count > 0)
			{
				return 0;
			}

			return frontCount == backCount ? 1 : 0;
		}
		// https://leetcode.com/problems/valid-parentheses
		public static bool IsValidComb(string s)
		{
			Stack<char> stack = new Stack<char>();
			foreach (var ch in s)
			{
				if (ch == '{' ||
				   ch == '[' ||
				   ch == '(')
				{
					stack.Push(ch);
				}
				else if (stack.Count > 0)
				{
					if (ch == '}')
					{
						if (stack.Peek() != '{')
						{
							return false;
						}
						stack.Pop();
					}
					else if (ch == ']')
					{
						if (stack.Peek() != '[')
						{
							return false;
						}
						stack.Pop();
					}
					else if (ch == ')')
					{
						if (stack.Peek() != '(')
						{
							return false;
						}
						stack.Pop();
					}
				}
				else
				{
					return false;
				}
			}
			return stack.Count == 0;

		}
		// https://www.interviewbit.com/problems/balanced-parantheses/
		public static int BalancedParantheses_IB(string s)
		{
			Stack<char> stack = new Stack<char>();
			foreach (var ch in s)
			{
				if (ch == '(')
				{
					stack.Push(ch);
				}
				else if (stack.Count > 0)
				{
					if (ch == ')' && stack.Peek() == '(')
					{
						stack.Pop();
					}
					else
					{
						stack.Push(ch);
					}
				}
				else
				{
					stack.Push(ch);
				}
			}
			return stack.Count == 0 ? 1 : 0;

		}
	}
}