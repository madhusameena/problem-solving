using System;
using System.Text.RegularExpressions;

namespace CSharpProblemSolving.Strings
{
	public static class CompareVersionNumbers
	{
		public static void Samples()
		{
			// Console.WriteLine(compareVersion("1.0", "1.0.8"));
			// Console.WriteLine(compareVersion("3346237295", "898195413.2.6243"));
			// Console.WriteLine(compareVersion("444444444444444444444444", "4444444444444444444444444"));
			// Console.WriteLine(compareVersion("01", "1"));
			// Console.WriteLine(compareVersion("7611096.45.537.4", "6.1905074"));
			Console.WriteLine(compareVersion("000000604461", "27899983539021.416"));
		}
		public static int compareVersion(string A, string B)
		{
			string regEx = @"^([0-9]*)\.?([0-9]*)?\.?([0-9]*)?\.?([0-9]*)?\.?([0-9]*)?\.?([0-9]*)?\.?([0-9]*)?$";
			var mathesA = Regex.Match(A, regEx);
			var mathesB = Regex.Match(B, regEx);
			int count = Math.Max(mathesA.Groups.Count, mathesB.Groups.Count);
			for (int idx = 1; idx < count; idx++)
			{
				int verA = 0;
				int verB = 0;
				string strA = mathesA.Groups[idx].Value.TrimStart('0');
				string strB = mathesB.Groups[idx].Value.TrimStart('0');
				Console.WriteLine($"StrA = {strA}, strB = {strB}");
				// Console.WriteLine($"A len = {strA.Length}, B len  = {strB.Length}");
				if (string.IsNullOrEmpty(strA) && string.IsNullOrEmpty(strB))
				{
					continue;
				}

				if (strA.Length > strB.Length)
				{
					return 1;
				}
				if (strA.Length < strB.Length)
				{
					return -1;
				}

				int digitsCount = Math.Max(strA.Length, strB.Length) - 1;
				int num = 5;
				int cnt = (digitsCount / num) + 1;
				for (int i = 0; i < cnt; i++)
				{
					var start = num * i;
					var end = num * (i + 1) - 1;
					int intA = 0;
					if (start < strA.Length)
					{
						int length = Math.Min((end - start + 1), (strA.Length - start));
						intA = int.Parse(strA.Substring(start, length));
						// Console.WriteLine($"inta = {intA}");
					}
					int intB = 0;
					if (start < strB.Length)
					{
						int length = Math.Min((end - start + 1), (strB.Length - start));
						intB = int.Parse(strB.Substring(start, length));
						// Console.WriteLine($"intB = {intB}");
					}
					if (intA > intB)
					{
						return 1;
					}

					if (intA < intB)
					{
						return -1;
					}
					
				}
			}

			return 0;
		}
	}
}