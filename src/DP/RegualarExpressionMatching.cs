using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpProblemSolving.DP
{
	public class RegualarExpressionMatching
	{
		// https://www.youtube.com/watch?v=l3hda49XcDE
		// https://www.interviewbit.com/problems/regular-expression-ii/
		// https://leetcode.com/problems/regular-expression-matching/

		public bool IsMatch(string text, string pattern)
		{
			int rows = text.Length + 1, cols = pattern.Length + 1;
			var dpArray = new bool[rows, cols];
			// Fill first row
			int row = 0, col = 0;
			dpArray[row, col] = true;
			for (col = 1; col < cols; col++)
			{
				// Check for a*, a*b* ... -> remove star and letter check the prev val
				if (pattern[col - 1] == '*')
				{
					dpArray[row, col] = dpArray[row, col - 2];
				}
			}

			for (row = 1; row < rows; row++)
			{
				for (col = 1; col < cols; col++)
				{
					if (text[row - 1] == pattern[col - 1] ||
						pattern[col - 1] == '.')
					{
						dpArray[row, col] = dpArray[row - 1, col - 1];
					}
					else if (pattern[col - 1] == '*')
					{
						// Check for 0 based index - by moving 2 in left dir in pattern
						dpArray[row, col] = dpArray[row, col - 2];
						// Check if prev val to * is same as last val in text or prev val is .
						if (pattern[col - 2] == '.' ||
							pattern[col - 2] == text[row - 1])
						{
							dpArray[row, col] = dpArray[row, col] || dpArray[row - 1, col];
						}
					}
				}
			}
			return dpArray[rows - 1, cols - 1];
		}
	}
}
