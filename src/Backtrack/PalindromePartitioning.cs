using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpProblemSolving.Backtrack
{
	// https://leetcode.com/problems/palindrome-partitioning/
	public class PalindromePartitioning
	{
		public static void Samples()
		{
			var obj = new PalindromePartitioning();
			var results = obj.Partition("aab");
			Console.WriteLine(results.Count);
			foreach (var result in results)
			{
				foreach (var item in result)
				{
					Console.Write($"{item}\t");
				}
				Console.WriteLine();
			}
		}
		public IList<IList<string>> Partition(string s)
		{
			var result = new List<IList<string>>();
			if (string.IsNullOrEmpty(s))
			{
				return result;
			}
			if (s.Length == 1)
			{
				result.Add(new List<string>() { s });
				return result;
			}
			var list = new List<string>();
			Dfs(s, 0, result, list);

			return result;
		}

		private void Dfs(string s, int i, List<IList<string>> result, List<string> list)
		{
			if (i == s.Length)
			{
				result.Add(new List<string>(list));
				return;
			}
			for (int j = i; j < s.Length; j++)
			{
				if (IsPalindrome(s, i, j))
				{
					list.Add(s.Substring(i, (j - i) + 1));
					Dfs(s, j + 1, result, list);
					list.RemoveAt(list.Count - 1);
				}
				
			}
		}

		private bool IsPalindrome(string s, int left, int right)
		{
			if (left > right)
			{
				return false;
			}
			while (left < right)
			{
				if (s[left] != s[right])
				{
					return false;
				}
				left++;
				right--;
			}
			return true;
		}
	}
}
