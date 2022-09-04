using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpProblemSolving.StackOperations
{
    // https://leetcode.com/problems/backspace-string-compare/
    internal class Backspace_String_Compare
    {
        public bool BackspaceCompare(string s, string t)
        {
            var stack = new Stack<char>();
            var sb = new StringBuilder();
            var str1 = GetString(s, stack, sb);
            Console.WriteLine(str1);
            stack.Clear();
            sb.Clear();
            var str2 = GetString(t, stack, sb);
            Console.WriteLine(str2);
            return str1 == str2;
        }
        string GetString(string s, Stack<char> stack, StringBuilder sb)
        {
            foreach (var ch in s)
            {
                if (ch == '#' && stack.Count > 0)
                    stack.Pop();
                else if (ch != '#')
                    stack.Push(ch);
            }
            while (stack.Count > 0)
            {
                sb.Append(stack.Pop());
            }
            var str = sb.ToString();
            return str;
        }
    }
}
