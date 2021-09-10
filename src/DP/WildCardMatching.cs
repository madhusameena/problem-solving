using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpProblemSolving.DP
{
	// https://www.interviewbit.com/problems/regular-expression-match/
	// https://leetcode.com/problems/wildcard-matching/submissions/
	// https://www.youtube.com/watch?v=3ZDZ-N0EPV0
	public class WildCardMatching
	{
		public bool IsMatch(string text, string pattern)
		{
			int rows = text.Length, cols = pattern.Length;
			var dpArray = new bool[rows + 1, cols + 1];
			int row = 0, col = 0;
			dpArray[row, col] = true;
			// First row
			for (col = 1; col < cols + 1; col++)
			{
				// If * check prev val
				if (pattern[col - 1] == '*')
				{
					dpArray[row, col] = dpArray[row, col - 1];
				}
			}
			for (row = 1; row < rows + 1; row++)
			{
				for (col = 1; col < cols + 1; col++)
				{
					if (text[row - 1] == pattern[col - 1] ||
						pattern[col - 1] == '?')
					{
						dpArray[row, col] = dpArray[row - 1, col - 1];
					}
					else if (pattern[col - 1] == '*') // Check 0 based * or remove last char from text and try match
					{
						dpArray[row, col] = dpArray[row, col - 1] ||
							dpArray[row - 1, col];
					}
				}
			}
			return dpArray[rows, cols];
		}
	}
}
