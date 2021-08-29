using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpProblemSolving.Arrays
{
	// https://www.geeksforgeeks.org/find-next-greater-number-set-digits/
	public class NextGreaterSmallNum
	{
		public static void Samples()
		{
			Console.WriteLine(Solve("218765"));
			Console.WriteLine(Solve("1234"));
			Console.WriteLine(Solve("4321"));
			Console.WriteLine(Solve("534976"));
		}

		public static string Solve(string number)
		{
			var ints = new int[number.Length];
			for (var idx = 0; idx < number.Length; idx++)
			{
				ints[idx] = int.Parse(number[idx].ToString());
			}

			bool found = false;

			int lastIdx = ints.Length - 1;
			for (; lastIdx > 0; lastIdx--)
			{
				if (ints[lastIdx] > ints[lastIdx - 1])
				{
					lastIdx--;
					found = true;
					(ints[lastIdx], ints[^1]) = (ints[^1], ints[lastIdx]);
					break;
				}
			}

			if (!found)
			{
				return "Not Possible";
			}

			if (lastIdx < ints.Length - 1)
			{
				Array.Sort(ints, lastIdx + 1, (ints.Length - lastIdx - 1));
			}
			StringBuilder sb = new StringBuilder();
			foreach (var i in ints)
			{
				sb.Append(i);
			}

			return sb.ToString();
		}
	}
}