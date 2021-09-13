using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpProblemSolving.StackOperations
{
	// https://www.interviewbit.com/problems/minimum-parantheses/
	// https://leetcode.com/problems/minimum-add-to-make-parentheses-valid/
	public class MinimumParantheses
	{
		public int solve(string A)
		{
			Stack<char> stack = new Stack<char>();
			foreach (var ch in A)
			{
				if (ch == ')' && stack.Count > 0 && stack.Peek() == '(')
				{
					stack.Pop();
				}
				else
				{
					stack.Push(ch);
				}
			}
			return stack.Count;
		}
	}
}
