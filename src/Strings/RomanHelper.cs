using System;
using System.Collections.Generic;
using System.Linq;

namespace CSharpProblemSolving.Strings
{
	public static class RomanHelper
	{
		public static string IntToRoman(int num)
		{
			Dictionary<int, string> dic = new Dictionary<int, string>
			{
				{1, "I"},
				{4, "IV"},
				{5, "V"},
				{9, "IX"},
				{10, "X"},
				{40, "XL"},
				{50, "L"},
				{90, "XC"},
				{100, "C"},
				{400, "CD"},
				{500, "D"},
				{900, "CM"},
				{1000, "M"}
			};
			string result;
			if (dic.TryGetValue(num, out result))
				return result;

			while (num != 0)
			{
				var temp = dic.LastOrDefault(x => x.Key <= num);
				num -= temp.Key;
				result += temp.Value;
			}

			return result;
		}

		// https://leetcode.com/problems/roman-to-integer/submissions/
		public static int RomanToInt(string s)
		{
			Dictionary<char, int> dictValues = new Dictionary<char, int>()
			{
				{'I', 1},
				{'V', 5},
				{'X', 10},
				{'L', 50},
				{'C', 100},
				{'D', 500},
				{'M', 1000},
			};
			int sum = 0;
			for (int i = 0; i < s.Length; i++)
			{
				var val = dictValues[s[i]];
				if (i < s.Length - 1 && val < dictValues[s[i + 1]])
				{
					sum -= val;
				}
				else
					sum += val;
			}
			return sum;
		}
	}
}