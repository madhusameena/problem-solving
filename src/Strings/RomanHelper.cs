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

		public static int RomanToInt(string romanNum)
		{
			if (string.IsNullOrEmpty(romanNum))
			{
				return 0;
			}
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
			if (romanNum.Length == 0)
			{
				return 0;
			}
			if (romanNum.Length == 1)
			{
				return dictValues[romanNum[0]];
			}
			
			int num = 0;
			int prev = dictValues[romanNum[0]];
			for (var idx = 1; idx < romanNum.Length; idx++)
			{
				var current = dictValues[romanNum[idx]];
				if (current > prev)
				{
					num += (current - prev);
					prev = 0;
					idx++;
					if (idx < romanNum.Length)
					{
						prev = dictValues[romanNum[idx]];
					}
				}
				else
				{
					num += prev;
					prev = current;
				}
				if (idx == romanNum.Length - 1)
				{
					num += prev;
				}
			}
			return num;
		}
	}
}