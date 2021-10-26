using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpProblemSolving.DP
{
	public class Digitswith1And2
	{
		public static void Samples()
		{
			var list = Print(4);
			// Should print 1111,211,
			// 121,112, 22 
			foreach (var item in list)
			{
				Console.WriteLine(item);
			}
		}
		public static List<string> Print(int num)
		{
			var dp = new Dictionary<int, List<string>>();
			dp.Add(1, new List<string>() { "1" });
			dp.Add(2, new List<string>() { "11", "2" });
			return PrintRecursive(num, dp);
		}

		private static List<string> PrintRecursive(int num, Dictionary<int, List<string>> dp)
		{
			if (dp.ContainsKey(num))
			{
				return dp[num];
			}
			var list = new List<string>();
			var oneList = PrintRecursive(num - 1, dp);
			foreach (var item in oneList)
			{
				list.Add("1" + item);
			}
			var TwoList = PrintRecursive(num - 2, dp);
			foreach (var item in TwoList)
			{
				list.Add("2" + item);
			}
			dp[num] = list;
			return list;
		}
	}
}
