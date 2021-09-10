using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpProblemSolving.DP
{
	public class EditDistance
	{
		public static void Samples()
		{
			Console.WriteLine(MinDistance("abac", "aac"));
		}
		// https://leetcode.com/problems/edit-distance/
		// https://www.interviewbit.com/problems/edit-distance/
		// https://www.youtube.com/watch?v=AuYujVj646Q
		public static int MinDistance(string word1, string word2)
		{
			if (word1.Length == 0)
			{
				return word2.Length;
			}
			if (word2.Length == 0)
			{
				return word1.Length;
			}
			var dpArray = new int[word1.Length + 1, word2.Length + 1];
			// If not equal
			// Insert => array[i, j] = 1 + arr[i, j - 1]
			// Remove => array[i, j] = 1 + arr[i - 1, j]
			// Replace => array[i, j] = 1 + arr[i - 1, j - 1]

			// If equal
			// array[i, j] = arr[i - 1, j - 1]
			for (int i = 0; i <= word1.Length; i++)
			{
				for (int j = 0; j <= word2.Length; j++)
				{
					if (i == 0)
					{
						dpArray[i, j] = j;
					}
					else if (j == 0)
					{
						dpArray[i, j] = i;
					}
					else
					{
						if (word1[i - 1] == word2[j - 1])
						{
							dpArray[i, j] = dpArray[i - 1, j - 1];
						}
						else
						{
							dpArray[i, j] = 1 + Math.Min(Math.Min(dpArray[i, j - 1], dpArray[i - 1, j]), dpArray[i - 1, j - 1]);
						}
					}
				}
			}
			return dpArray[word1.Length, word2.Length];
		}
	}
}
