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
			// Console.WriteLine(compareVersion("000000604461", "27899983539021.416"));
			Console.WriteLine(compareVersion("1648.8.95312.3378707.2530123939901556270131046778.45772.67.86.913874252893151481671.59488303379083791479371.17190.6367835481.128806560675344486050941993.748884990949.286015060316233.11527570.64595461332962.77273115595.1649.3614518.2113209.2561509423860496.6.5354.19770147443523.67696.4968677567930782796881.8510.284.868.8652.5.63305002.45.793201339.948672.48.84.1565275776931.82980180914046.61.617315.671496094.2139804.363700156283466.342698767.1594.1059845860.848.576997020050.187123490.1213980767.52097959158107270928659647.399.9.558558783419.9.60638", "1648.8.95312.3378707.2530123939901556270131046778.45772.67.86.913874252893151481671.59488303379083791479371.17190.6367835481.128806560675344486050941993.748884990949.286015060316233.11527570.64595461332962.77273115595.1649.3614518.2113209.2561509423860496.6.5354.19770147443523.67696.4968677567930782796881.8510.284.868.8652.5.63305002.45.793201339.948672.48.84.1565275776931.82980180914046.61.617315.671496094.2139804.363700156283466.342698767.1594.1059845860.848.576997020050.187123490.1213980767.52097959158107270928659647.399.9.558558783419.9.60638"));
		}
		public static int compareVersion(string A, string B)
		{
			string regEx = @"^([0-9]*)\.?([0-9]*)?\.?([0-9]*)?\.?([0-9]*)?\.?([0-9]*)?\.?([0-9]*)?\.?([0-9]*)?$?([0-9]*)?$?([0-9]*)?$?([0-9]*)?$?([0-9]*)?$?([0-9]*)?$?([0-9]*)?$?([0-9]*)?$?([0-9]*)?$?([0-9]*)?$?([0-9]*)?$?([0-9]*)?$?([0-9]*)?$?([0-9]*)?$?([0-9]*)?$?([0-9]*)?$?([0-9]*)?$?([0-9]*)?$?([0-9]*)?$?([0-9]*)?$?([0-9]*)?$?([0-9]*)?$?([0-9]*)?$?([0-9]*)?$";
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