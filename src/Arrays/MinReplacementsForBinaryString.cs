using System;

namespace CSharpProblemSolving.Arrays
{
	// https://www.geeksforgeeks.org/minimum-number-of-replacements-to-make-the-binary-string-alternating-set-2/
	public class MinReplacementsForBinaryString
	{
		public static void Samples()
		{
			Console.WriteLine(Solve("1100"));
		}
		public static int Solve(string str)
		{
			int count = 0;
			for (var idx = 0; idx < str.Length; idx++)
			{
				if (idx % 2 == 0 && str[idx] == '0')
				{
					count++;
				}
				if (idx % 2 == 1 && str[idx] == '1')
				{
					count++;
				}
			}

			return Math.Min(count, str.Length - count);
		}
	}
}