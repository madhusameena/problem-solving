using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpProblemSolving.DP
{
	public class InterleavingString
	{
		// https://leetcode.com/problems/interleaving-string/
		// https://www.interviewbit.com/problems/interleaving-strings/
		// https://www.youtube.com/watch?v=ih2OZ9-M3OM&t=339s
		public bool IsInterleave(string s1, string s2, string s3)
		{
			if (s3.Length != s1.Length + s2.Length)
			{
				return false;
			}
			var dp = new bool[s1.Length + 1, s2.Length + 1];
			for (int i = 0; i <= s1.Length; i++)
			{
				for (int j = 0; j <= s2.Length; j++)
				{
					if (i == 0 && j == 0)
					{
						// All empty - can form valid one
						dp[i, j] = true;
					}
					else if (i == 0)
					{
						if (s2[j - 1] == s3[i + j - 1]) // -1 coz we added 1 at the start
						{
							dp[i, j] = dp[i, j - 1];
						}
						else
						{
							dp[i, j] = false;
						}
					}
					else if (j == 0)
					{
						if (s1[i - 1] == s3[i + j - 1]) // -1 coz 0 based index
						{
							dp[i, j] = dp[i - 1, j];
						}
						else
						{
							dp[i, j] = false;
						}
					}
					else
					{
						// Check from both s1 side and s2 side
						var s1Val = s1[i - 1] == s3[i + j - 1] ? dp[i - 1, j] : false;
						var s2Val = s2[j - 1] == s3[i + j - 1] ? dp[i, j - 1] : false;
						dp[i, j] = s1Val || s2Val;
					}
				}
			}
			return dp[s1.Length, s2.Length];
		}
	}
}
