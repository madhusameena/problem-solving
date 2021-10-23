using System;

namespace CSharpProblemSolving.Strings
{
	// https://www.interviewbit.com/problems/implement-strstr/
	public class ImplementStrStr
	{
		public static void Samples()
		{
			Console.WriteLine(strStr("NsfdfAb", "Ab"));
			Console.WriteLine(strStr("bbaabbbbbaabbaabbbbbbabbbabaabbbabbabbbbababbbabbabaaababbbaabaaaba", "babaaa")); // 48
			Console.WriteLine(strStr("aaaaabbabbaaaababbbbaaabbbaababaababbaabaabaaabbabab", "bbbaababaa")); // 23	
		}
		public int strStrSol(string A, string B)
		{
			if (A.Length == 0)
				return -1;
			if (A.Length == 0)
				return -1;
			int j = 0;
			int position;
			for (int i = 0; i <= A.Length - B.Length; i++)
			{
				position = i;
				while (j < B.Length && A[position] == B[j])
				{
					j++;
					position++;
				}
				if (j == B.Length)
				{
					return i;
				}
				j = 0;
			}
			return -1;
		}
		public static int strStr(string A, string B)
		{
			if (string.IsNullOrEmpty(B))
			{
				return -1;
			}

			if (A.ToLower() == B.ToLower())
			{
				return 0;
			}
			if (string.IsNullOrEmpty(A))
			{
				return -1;
			}
			bool started = false;
			int index = 0;
			for (var idx = 0; idx < A.Length; idx++)
			{
				if (!started && A[idx].ToString().ToLower() == B[0].ToString().ToLower())
				{
					started = true;
					index++;
					// index = idx;
				}
				else  if (started)
				{
					if (A[idx].ToString().ToLower() == B[index].ToString().ToLower())
					{
						index++;
					}
					else
					{
						idx -= index;
						index = 0;
						started = false;
					}
					if (index == B.Length)
					{
						return idx + 1 - B.Length;
					}
				}
			}

			return -1;
		}
	}
}