using System;
using System.Collections.Generic;
using System.Linq;

namespace CSharpProblemSolving.StackOperations
{
	// https://www.interviewbit.com/problems/redundant-braces/
	public static class RedundantBraces
	{
		public static void Samples()
		{
			Console.WriteLine("---------------------------");
			Console.Write(braces("(a + b)"));
			Console.Write(braces("a + b"));
			Console.Write(braces("((a + b))"));
			Console.Write(braces("(a + (a + b))"));
			Console.Write(braces("(a + (a + b))"));
			Console.Write(braces("((a + (a + b))"));
			Console.WriteLine("\n---------------------------");
			Console.Write(bracesSol("(a + b)"));
			Console.Write(bracesSol("a + b"));
			Console.Write(bracesSol("((a + b))"));
			Console.Write(bracesSol("(a + (a + b))"));
			Console.Write(bracesSol("(a + (a + b))"));
			Console.Write(bracesSol("((a + (a + b))"));
			Console.WriteLine("\n---------------------------");
		}

		public static int bracesSol(string A)
		{
			Stack<char> stack = new Stack<char>();
			foreach (var ch in A)
			{
				if (ch == ')')
				{
					if (stack.Count == 0 || stack.Peek() == '(')
					{
						return 1;
					}

					char t = stack.Peek();
					while (t == '+' || t == '-' || t == '*' || t == '/')
					{
						stack.Pop();
						t = stack.Peek();
					}

					if (stack.Peek() != '(')
					{
						return 1;
					}
					stack.Pop(); // ( will be removed
				}

				if (ch == '(' || ch == '+' || ch == '-' || ch == '*' || ch == '/')
				{
					stack.Push(ch);
				}
			}

			while (stack.Count > 0)
			{
				if (stack.Pop() == '(')
				{
					return 1;
				}
			}

			return 0;
		}

		public static int braces(string A)
		{
			List<char> list = new List<char>();
			foreach (var t in A)
			{
				if (t == '(' || t == ')'|| t == '+' || t == '-' || t == '*' || t == '/')
				{
					list.Add(t);
				}
			}

			int fwdCount = list.Count(s => s == '(');
			int bckCount = list.Count(s => s == ')');
			
			if (fwdCount != bckCount)
			{
				return 1;
			}
			int chCount = list.Count - fwdCount - bckCount;
			if (fwdCount > chCount)
			{
				return 1;
			}
			for (var idx = list.Count - 1; idx >= 0; idx--)
			{
				if (list[idx] == ')')
				{
					if (idx == 0 || list[idx - 1] == '(')
					{
						return 1;
					}
				}
			}

			return 0;
		}
	}
}