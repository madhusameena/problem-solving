using System;
using System.Text;

namespace CSharpProblemSolving.Strings
{
	// https://www.interviewbit.com/problems/reverse-the-string/
	public static class ReverseString
	{
		public static void Samples()
		{
			// var test = solve("    A MadB us     Me      ");
			// Console.WriteLine(test);
			// test = solve("      ");
			// Console.WriteLine(test);
			var test = solve2(
				"       fwbpudnbrozzifml osdt ulc jsx kxorifrhubk ouhsuhf sswz qfho dqmy sn myq igjgip iwfcqq                 ");
			Console.WriteLine(test);
		}	
		
		public static string solve(string A)
		{
			StringBuilder sb = new StringBuilder();
			bool space = false;
			for (var idx = A.Length - 1; idx >= 0; idx--)
			{
				if (A[idx] != ' ')
				{
					sb.Append(A[idx]);
					space = false;
				}
				else if (sb.Length != 0 && !space)
				{
					sb.Append(' ');
					space = true;
				}

				if (idx == 0 && space)
				{
					sb.Remove(sb.Length - 1, 1);
				}
			}

			return sb.ToString();
		}
		public static string solve2(string A)
		{
			var strs = A.Split(' ');
			StringBuilder sb = new StringBuilder();
			for (var idx = strs.Length - 1; idx >= 0; idx--)
			{
				var str = strs[idx].Trim(' ');
				if (!string.IsNullOrEmpty(str))
				{
					sb.Append(str);
					if (idx != 0)
					{
						sb.Append(' ');
					}
				}
			}

			if (sb[^1] == ' ')
			{
				sb.Remove(sb.Length - 1, 1);
			}

			return sb.ToString();
		}
	}
}