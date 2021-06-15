using System;
using System.Text;

namespace CSharpProblemSolving.Strings
{
	public class AtoI
	{
		public static void Samples()
		{
			Console.WriteLine(TestFromWeb("-+1563.4343"));
			Console.WriteLine(TestFromWeb("-1563.4343"));
			Console.WriteLine(TestFromWeb("-15656565656563.4343"));
			Console.WriteLine(TestFromWeb("-15656-565656563.4343"));
			Console.WriteLine(TestFromWeb("-15.4sdgsfgxcbxc343"));
			Console.WriteLine(TestFromWeb("123sdfgjfbglsfbg"));
			Console.WriteLine(TestFromWeb("    -156    56565656563.4343"));
			Console.WriteLine(TestFromWeb("    +   000000156    56565656563.4343"));
			Console.WriteLine(TestFromWeb("0 14119"));
			Console.WriteLine(TestFromWeb("   00000000000000000000000000000000000000000000000002 14119"));
			Console.WriteLine(TestFromWeb("   -00002 14119"));
		}
		public static int atoi(string A) 
		{
			// Trim all leading spaces
			A = A.TrimStart(' ');
			// Trim all leading 0s
			A = A.TrimStart('0');
			bool isNegativeNum = A.IndexOf("-") == 0;
			if (isNegativeNum)
			{
				// remove - symbol
				A = A.Remove(0, 1);
			}
			else
			{
				// Remove + symbol
				if (A[0] == '+')
				{
					A = A.Remove(0, 1);
				}
			}

			// Trim all leading 0s - after removing - or +
			A = A.TrimStart('0');
			
			// Check at least one valid number is present
			if (A[0] >= '0' && A[0] <= '9')
			{
			}
			else
			{
				return 0;
			}

			StringBuilder sb = new StringBuilder();
			for (var idx = 0; idx < A.Length; idx++)
			{
				if (A[idx] >= '0' &&A[idx] <= '9')
				{
					sb.Append(A[idx]);
				}
				else
				{
					break;
				}
			}
			// Try based on length, If more then the len - return min or max
			string maxString = Int32.MaxValue.ToString();
			if (sb.Length > maxString.Length)
			{
				return isNegativeNum ? Int32.MinValue : Int32.MaxValue;
			}
			var actualString = sb.ToString();
			if (actualString.Length == maxString.Length)
			{
				for (var idx = 0; idx < actualString.Length; idx++)
				{
					if (actualString[idx] > maxString[idx])
					{
						return isNegativeNum ? Int32.MinValue : Int32.MaxValue;
					}
				}
			}

			int rowVal = 1;
			int actualVal = 0;
			for (var i = actualString.Length - 1; i >= 0; i--)
			{
				actualVal += (CharToInt(actualString[i]) * rowVal);
				rowVal *= 10;
			}

			return isNegativeNum ? actualVal * -1 : actualVal;
		}

		private static int CharToInt(char ch)
		{
			switch (ch)
			{
				case '0':
					return 0;
				case '1':
					return 1;
				case '2':
					return 2;
				case '3':
					return 3;
				case '4':
					return 4;
				case '5':
					return 5;
				case '6':
					return 6;
				case '7':
					return 7;
				case '8':
					return 8;
				case '9':
					return 9;
			}

			return -1;
		}

		public static int TestFromWeb(string s)
		{
			{
				int i = 0;
				while(s[i] == ' ')
				{
					i++;
				}
    
				long l = 0, f = 1;
				if(s[i] == '-')
				{
					f = -1;
					i++;
				}
				else if(s[i] == '+') i++;
    
				while(s[i] >= 48 && s[i] <= 57)
				{
					l = l * 10 + (s[i] - 48);
					i++;

					if(l > int.MaxValue)
					{
						if(f == -1) return int.MinValue;
						return int.MaxValue;
					}
				}
    
				if(f == -1) return (int)(f * l);
				return (int)l;
			}


		}
	}
}