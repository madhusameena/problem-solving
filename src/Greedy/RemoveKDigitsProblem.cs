using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpProblemSolving.Greedy
{
    // https://leetcode.com/problems/remove-k-digits/
    public class RemoveKDigitsProblem
	{
        public static void Samples()
        {
			Console.WriteLine(RemoveKdigits("1234567890", 9));
        }
        public static string RemoveKdigits(string num, int k)
        {
            Stack<char> stack = new Stack<char>();
            foreach (char ch in num)
            {
                while (stack.Count > 0 && k > 0 && stack.Peek() > ch)
                {
                    stack.Pop();
                    k--;
                }
                if (ch == '0' && stack.Count == 0)
                {
                    continue;
                }
                else
                {
                    stack.Push(ch);
                }
            }
            while (k > 0 && stack.Count > 0)
            {
                stack.Pop();
                k--;
            }
            if (stack.Count == 0)
            {
                return "0";
            }
            StringBuilder sb = new StringBuilder();
            while (stack.Count > 0)
            {
                sb.Append(stack.Pop());
            }
            var str = sb.ToString();
            return new string(str.Reverse().ToArray());
        }
    }
}
