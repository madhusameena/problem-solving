using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpProblemSolving.StackOperations
{
    // https://leetcode.com/problems/decode-string/
    internal class Decode_String
    {
        public static void Samples()
        {
            var obj = new Decode_String();
            Console.WriteLine(obj.DecodeString("3[a]2[bc]"));
        }
        public string DecodeString(string s)
        {
            var sb = new StringBuilder();
            var stack = new Stack<string>();
            foreach (var ch in s)
            {
                if (ch == ']')
                {
                    var testSb = new StringBuilder();
                    while (stack.Peek() != "[")
                    {
                        testSb.Append(stack.Pop());
                    }
                    stack.Pop(); // Remove [
                    var test = new string (testSb.ToString().Reverse().ToArray());
                    int num = int.Parse(stack.Pop());
                    for (int i = 0; i < num; i++)
                    {
                        sb.Append(test);
                    }
                    var str = sb.ToString();
                    sb.Clear();
                    stack.Push(str);
                }
                else
                {
                    stack.Push(ch.ToString());
                }
            }
            var list = new List<string>();
            while (stack.Count > 0)
            {
                list.Add(stack.Pop());
            }
            list.Reverse();
            return stack.Pop();
        }
    }
}
