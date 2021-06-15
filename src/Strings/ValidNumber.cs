using System;
using System.Linq;

namespace CSharpProblemSolving.Strings
{
	public static class ValidNumber
	{
		public static void Samples()
		{
			// Console.WriteLine(isNumber("0"));
			// Console.WriteLine(isNumber(" 0.1 "));
			// Console.WriteLine(isNumber("abc"));
			// Console.WriteLine(isNumber("1 a"));
			// Console.WriteLine(isNumber("2e10"));
			Console.WriteLine(isNumber("-011e-10"));
			Console.WriteLine(isNumber("011e-10"));
			Console.WriteLine(isNumber("-011"));
			Console.WriteLine(isNumber("-011-10"));
			Console.WriteLine(isNumber("-011-e10"));
			Console.WriteLine(isNumber("-0-11e-10"));
			Console.WriteLine(isNumber("       1e   1"));
			
		}
		public static int isNumber(string A)
		{
			var eIndex = A.IndexOf("e", StringComparison.OrdinalIgnoreCase);
			var dotIndex = A.IndexOf(".");
			if (eIndex != -1)
			{
				if (eIndex != A.LastIndexOf("e", StringComparison.OrdinalIgnoreCase))
				{
					return 0;
				}
			}
			if (dotIndex != -1)
			{
				if (dotIndex != A.LastIndexOf(".", StringComparison.OrdinalIgnoreCase))
				{
					return 0;
				}
			}

			if (eIndex == A.Length -1 || dotIndex== A.Length - 1)
			{
				return 0;
			}
			
			if ((eIndex != -1 && dotIndex > eIndex) || eIndex == dotIndex + 1)
			{
				return 0;
			}

			var minusIndex = A.IndexOf("-");
			if (minusIndex != -1 && (minusIndex != 0 && minusIndex != eIndex + 1))
			{
				return 0;
			}
			if (minusIndex != -1 && A.LastIndexOf("-") != 0 && A.LastIndexOf("-") != eIndex +1)
			{
				return 0;
			}

			if (A.Count(c => c == '-') > 2)
			{
				return 0;
			}

			if (A.Count(c => c == ' ') == A.Length)
			{
				return 0;
			}
			
			for (var idx = 0; idx < A.Length; idx++)
			{
				var c = A[idx];
				if ((c >= '0' && c <= '9') || c == '.' || c == ' ' || c == 'e' || c == 'E' || c == '-')
				{
					continue;
				}
				return 0;
			}

			return 1;
		}
	}
}