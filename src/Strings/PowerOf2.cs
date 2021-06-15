using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpProblemSolving.Strings
{
	public static class PowerOf2
	{
		public static int power_or(string a) 
		{
			int res = 0;
			int i;
			for (i = 0; i < a.Length; i++)
			{
				res = res * 10 + a[i] - '0';
			}

			if (res == 1)
				return 0;
			return ((res & (res - 1)) == 0) ? 1 : 0;
		}
		public static int power(string A)
		{
			if (A.Length == 1)
			{
				var num = int.Parse(A);
				// https://www.geeksforgeeks.org/program-to-find-whether-a-no-is-power-of-two/
				return num != 0 && ((num & (num - 1)) == 0) ? 1 : 0;
			}
			// var array = new int[A.Length];
			// for (var idx = 0; idx < A.Length; idx++)
			// {
			// 	array[idx] = int.Parse(A[idx].ToString());
			// }

			// // My Initial Way
			// while (true)
			// {
			// 	int carry = 0;
			// 	var zeroCount = 0;
			// 	for (var idx = 0; idx < array.Length; idx++)
			// 	{
			// 		var num = array[idx] + carry;
			// 		carry = num % 2 == 1 ? 10 : 0;
			// 		num /= 2;
			// 		array[idx] = num;
			// 		if (num == 0 && idx != array.Length - 1)
			// 		{
			// 			zeroCount++;
			// 		}
			// 		// Console.Write($"{num} ");
			// 	}
			//
			// 	// Console.WriteLine($"zeroCount = {zeroCount}");
			// 	if (zeroCount == array.Length - 1)
			// 	{
			// 		return array[array.Length - 1] % 2 == 0 ? 1 : 0;
			// 	}
			// 	if (array[array.Length - 1] % 2 != 0)
			// 	{
			// 		return 0;
			// 	}
			// }

			StringBuilder sb = new StringBuilder(A);
			StringBuilder newSb  = new StringBuilder();
			List<int> ints = new List<int>();
			while (true)
			{
				newSb.Append(sb.ToString());
				sb.Clear();
				int carry = 0;
				for (var idx = 0; idx <newSb.Length; idx++)
				{
					var num = newSb[idx] - '0' + carry;
					carry = num % 2 == 1 ? 10 : 0;
					num /= 2;
					if (sb.Length == 0 && num == 0)
					{
						continue;
					}
					Console.Write($"{num} ");
					sb.Append(num);

					if (idx == newSb.Length - 1 && num % 2 != 0)
					{
						return 0;
					}
				}

				Console.WriteLine();

				if (sb.Length == 1)
				{
					return int.Parse(sb.ToString()) % 2 == 0 ? 1 : 0;
				}

				newSb.Clear();
			}
		}
	}
}