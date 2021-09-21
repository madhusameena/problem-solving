using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpProblemSolving.DP
{
	// https://www.interviewbit.com/problems/longest-valid-parentheses/
	// https://leetcode.com/problems/longest-valid-parentheses/
	public class LongestValidParenthesesProblem
	{
        public static void Samples()
        {
			Console.WriteLine(LongestValidParenthesesUsingStack("())((())")); // 4
			Console.WriteLine(LongestValidParenthesesUsingStack("(()(()")); // 2
			Console.WriteLine(LongestValidParenthesesUsingStack("(()(()))")); // 2
        }
        public static int LongestValidParenthesesUsingStack(string s)
        {
            Stack<int> stack = new Stack<int>();
            stack.Push(-1);// To make sure dont keep stack empty
            int maxLen = 0;
			for (int idx = 0; idx < s.Length; idx++)
            {
				char ch = s[idx];
				if (ch == '(')
                {
                    stack.Push(idx);
                }
                else
                {
                    stack.Pop();
                    if (stack.Count == 0)
                    {
                        stack.Push(idx);
                    }
                    else // Combination
                    {
                        maxLen = Math.Max(maxLen, idx - stack.Peek());
                    }
                }
            }
            return maxLen;
        }
    }
}
