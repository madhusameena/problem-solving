using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpProblemSolving.Greedy
{
	// https://leetcode.com/problems/largest-number
	// https://www.youtube.com/watch?v=qEIGhVtZ-sg&list=RDCMUCnxhETjJtTPs37hOZ7vQ88g&index=3
	public class LargestNumberProblem
	{
		public static void Samples()
		{
			var obj = new LargestNumberProblem();
			Console.WriteLine(obj.LargestNumberSol(new int[] { 0, 0 }));
		}
		private class CustumComparator : IComparer<string>
		{
			public int Compare(string x, string y)
			{
				StringBuilder sb1 = new StringBuilder();
				sb1.Append(x);
				sb1.Append(y);
				string s1 = sb1.ToString();
				sb1.Clear();
				sb1.Append(y);
				sb1.Append(x);
				string s2 = sb1.ToString();
				return string.Compare(s2, s1, StringComparison.Ordinal);
			}
		}
		public string LargestNumberSol(int[] nums)
		{
			var comparer = new CustumComparator();
			var strList = nums.Select(x => x.ToString()).ToArray();
			Array.Sort(strList, comparer);
			var str = strList.Aggregate((x, y) => x + y);
			str = str.TrimStart('0');
			return str == string.Empty ? "0" : str;
		}
		public string LargestNumber(int[] nums)
		{
			if (nums.Length == 0)
			{
				return string.Empty;
			}

			if (nums.Length == 1)
			{
				return nums[0].ToString();
			}

			for (int i = 0; i < nums.Length - 1; i++)
			{
				for (int j = i + 1; j < nums.Length; j++)
				{
					if (Compare(nums[i], nums[j]) < 0)
					{
						(nums[i], nums[j]) = (nums[j], nums[i]);
					}
				}
			}

			StringBuilder sb = new StringBuilder();
			bool started = false;
			for (var index = 0; index < nums.Length; index++)
			{
				var num = nums[index];
				if (!started && num == 0 && index != nums.Length - 1)
				{
					continue;
				}

				started = true;
				sb.Append(num);
			}

			return sb.ToString();
		}

		int Compare(int i1, int i2)
		{
			StringBuilder sb1 = new StringBuilder();
			sb1.Append(i1);
			sb1.Append(i2);
			string s1 = sb1.ToString();
			sb1.Clear();
			sb1.Append(i2);
			sb1.Append(i1);
			string s2 = sb1.ToString();
			return string.Compare(s1, s2, StringComparison.Ordinal);
		}
	}
}
