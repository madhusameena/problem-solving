using System;

namespace CSharpProblemSolving.Strings
{
	// https://www.interviewbit.com/problems/length-of-last-word/
	public static class LengthOfLastWord
	{
		public static void Samples()
		{
			Console.WriteLine(lengthOfLastWord("      "));
		}
		public static int lengthOfLastWord(string A)
		{
			int count = 0;
			for (var idx = A.Length - 1; idx >= 0; idx--)
			{
				if (count == 0 && A[idx] == ' ')
				{
					continue;
				}
				if(count == 0 && A[idx] != ' ')
				{
					count = 1;
				}
				else if (A[idx] != ' ')
				{
					count++;
				}
				else
				{
					return count;
				}
			}

			return count;
		}
	}
}