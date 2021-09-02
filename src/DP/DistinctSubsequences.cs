using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpProblemSolving.DP
{
	// https://leetcode.com/problems/distinct-subsequences/https://leetcode.com/problems/distinct-subsequences/
	// https://www.interviewbit.com/problems/distinct-subsequences/
	public class DistinctSubsequences
	{
		public static void Samples()
		{
			Console.WriteLine(NumDistinct("rabbbit", "rabbit"));
			Console.WriteLine(NumDistinct("", "rabbit"));
			Console.WriteLine(NumDistinct("rabbbit", ""));
			Console.WriteLine(NumDistinct("", ""));
		}
		// https://www.youtube.com/watch?v=-RDzMJ33nx8
		public static int NumDistinct(string s, string t)
		{
			var dpArray = new Dictionary<Tuple<int, int>, int>();
			return Dfs(dpArray, s, t, 0, 0);
		}
		private static int Dfs(Dictionary<Tuple<int, int>, int> dpArray, string s, string t, int sStart, int tStart)
		{
			// Base cases
			if (tStart == t.Length)
			{
				return 1; // only one substring that is making it empty
			}
			if (sStart == s.Length)
			{
				// Cannot match with anything
				return 0;
			}

			var tuple = Tuple.Create<int, int>(sStart, tStart);
			if (dpArray.ContainsKey(tuple))
			{
				return dpArray[(tuple)];
			}
			int result;
			if (s[sStart] == t[tStart])// matching
			{
				// check both values, 
				result = Dfs(dpArray, s, t, sStart + 1, tStart + 1) +
					Dfs(dpArray, s, t, sStart + 1, tStart);
			}
			else
			{
				result = Dfs(dpArray, s, t, sStart + 1, tStart);
			}
			dpArray.Add(tuple, result);
			return result;
		}
	}
}
