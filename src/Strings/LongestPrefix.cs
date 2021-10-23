using System;
using System.Collections.Generic;
using System.Linq;

namespace CSharpProblemSolving.Strings
{
	// https://www.interviewbit.com/problems/longest-common-prefix/
	public class LongestPrefix
	{
		public static void Samples()
		{
			string[] A = {"abcdefgh", "aefghijk", "abcefgh"};
			string[] B = {"abab", "aba", "abacd"};
			string[] C = {"aaaaaaa", "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "aaaaaaaa", "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "aaaaaaaaaaaa", "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa"};
			// Console.WriteLine(isPalindrome(test2));
			Console.WriteLine(longestCommonPrefix(A.ToList()));
			Console.WriteLine(longestCommonPrefix(B.ToList()));
			Console.WriteLine(longestCommonPrefix(C.ToList()));
		}
		public static string longestCommonPrefix(List<string> A)
		{
			if (A.Count == 1)
			{
				return A[0];
			}
			var str = A[0];
			for (var i = 0; i < str.Length;)
			{
				var subStr = str.Substring(0, i + 1);
				int count = 0;
				foreach (var s in A)
				{
					if (!s.StartsWith(subStr))
					{
						break;
					}

					count++;
				}

				if (count == A.Count)
				{
					i++;
				}
				else
				{
					return str.Substring(0, i);
				}
			}

			return str;
		}
		public static string longestCommonPrefixFromSln(List<string> A) {
			var ans = A[0];
			for(int i = 1; i < A.Count; i++){
				int end;
				int n = Math.Min(ans.Length, A[i].Length);
				for(end = 0; end < n; end++){
					if(A[i][end] != ans[end]) break;
				}
				ans = ans.Substring(0, end);
			}
			return ans;
		}
	}
}