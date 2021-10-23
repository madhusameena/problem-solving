using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpProblemSolving.DP
{
	// TODO Complete it
	public class MinimumWindowSubstring
	{
		// https://www.interviewbit.com/problems/window-string/
		// https://leetcode.com/problems/minimum-window-substring
		public string MinWindow(string s, string t)
		{
			var sb = new StringBuilder();
			Dictionary<char, int> hashActual = new Dictionary<char, int>();
			Dictionary<char, int> hashNow = new Dictionary<char, int>();
			foreach (var ch in t)
			{
				if (hashActual.ContainsKey(ch))
				{
					hashActual[ch]++;
				}
				else
				{
					hashActual.Add(ch, 1);
				}
			}
			int i = 0, j = 0;
			while (i < s.Length && j < s.Length)
			{

			}
			return null;
		}
	}
}
