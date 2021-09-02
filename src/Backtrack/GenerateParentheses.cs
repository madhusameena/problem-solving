using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpProblemSolving.Backtrack
{
	// https://leetcode.com/problems/generate-parentheses
	// https://www.youtube.com/watch?v=qBbZ3tS0McI
	public class GenerateParentheses
	{
		public static void Samples()
		{
			var test = GenerateParenthesis(3);
			foreach (var item in test)
			{
				Console.Write($"{item}\t");
			}
			Console.WriteLine();
		}
		public static IList<string> GenerateParenthesis(int n)
		{
			var list = new List<string>();
			GenerateParenthesisRecursive(list, 0, 0, n, string.Empty);
			return list;
		}

		private static void GenerateParenthesisRecursive(List<string> list, int left, int right, int max, string str)
		{
			if (left == right && left == max)
			{
				list.Add(str);
				return;
			}
			if (left < max)
			{
				GenerateParenthesisRecursive(list, left + 1, right, max, str + "(");
			}
			if (right < left)
			{
				GenerateParenthesisRecursive(list, left, right + 1, max, str + ")");
			}
		}
	}
}
