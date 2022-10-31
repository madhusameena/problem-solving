using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpProblemSolving.StackOperations
{
	// https://www.interviewbit.com/problems/reverse-string/
	public class ReverseStringStack
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
        // https://leetcode.com/problems/reverse-words-in-a-string-iii
        public string ReverseWords(string s)
        {
            var stack = new Stack<char>();
            var sb = new StringBuilder();
            foreach (var ch in s)
            {
                if (ch != ' ')
                    stack.Push(ch);
                else if (stack.Count > 0)
                {
                    while (stack.Count > 0)
                    {
                        sb.Append(stack.Pop());
                    }
                    sb.Append(ch);
                }
                else
                {
                    sb.Append(ch);
                }
            }
            while (stack.Count > 0)
            {
                sb.Append(stack.Pop());
            }
            return sb.ToString();
        }
    }
}