using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpProblemSolving.Strings
{
	// https://www.interviewbit.com/problems/valid-ip-addresses/
	public static class ValidIpAddresses
	{
		public static void Samples()
		{
			var list = restoreIpAddresses("25525511135");
			list = restoreIpAddresses("123456");
			// var list = restoreIpAddresses("0100100");
			foreach (var item in list)
			{
				Console.WriteLine(item);
			}
		}
		public static List<string> restoreIpAddresses(string A) 
		{
			// We have to find valid 4 group combinations
			// Assumption is that A contains only numbers, no invalid chars
			var list = new List<string>();
			if (A.Length < 4)
			{
				return list;
			}
			// Any number must be less then 255
			// Use back trace
			var tempList = new List<string>();
			for (var i = 0; i < A.Length; i++)
			{
				var str = A.Substring(0, i + 1);
				int num;
				if (!int.TryParse(str, out num) || num > 255)
				{
					continue;
				}

				// 0.DDDD is valid but not 00.ggg or 01.ddfd
				if (str.StartsWith("0") && str.Length > 1)
				{
					continue;
				}
				tempList.Add(str);
				ProcessData(tempList, A, i + 1, list);
				tempList.RemoveAt(tempList.Count - 1);
			}

			return list;
		}
		private static void ProcessData(List<string> tempList, string actualStr, int i, List<string> list)
		{
			if (tempList.Count == 3)
			{
				ProcessFourthDigit(tempList, actualStr, i, list);
				return;
			}
			for (int idx = i; idx < actualStr.Length; idx++)
			{
				var str = actualStr.Substring(i, (idx - i) + 1);
				int num;
				if (!int.TryParse(str, out num) || num > 255)
				{
					continue;
				}
				// 0.DDDD is valid but not 00.ggg or 01.ddfd
				if (str.StartsWith("0") && str.Length > 1)
				{
					continue;
				}
				tempList.Add(str);
				ProcessData(tempList, actualStr, idx + 1, list);
				tempList.RemoveAt(tempList.Count - 1);
			}
		}

		private static void ProcessSecondDigit(List<string> tempList, string actualStr, int i, List<string> list)
		{
			for (int idx = i; idx < actualStr.Length; idx++)
			{
				var str = actualStr.Substring(i, (idx - i) + 1);
				int num;
				if (!int.TryParse(str, out num) || num > 255)
				{
					continue;
				}
				// 0.DDDD is valid but not 00.ggg or 01.ddfd
				if (str.StartsWith("0") && str.Length > 1)
				{
					continue;
				}
				tempList.Add(str);
				ProcessThirdDigit(tempList, actualStr, idx + 1, list);
				tempList.RemoveAt(tempList.Count - 1);
			}
		}

		private static void ProcessThirdDigit(List<string> tempList, string actualStr, int i, List<string> list)
		{
			for (int idx = i; idx < actualStr.Length; idx++)
			{
				var str = actualStr.Substring(i, (idx - i) + 1);
				int num;
				if (!int.TryParse(str, out num) || num > 255)
				{
					continue;
				}
				// 0.DDDD is valid but not 00.ggg or 01.ddfd
				if (str.StartsWith("0") && str.Length > 1)
				{
					continue;
				}
				tempList.Add(str);
				ProcessFourthDigit(tempList, actualStr, idx + 1, list);
				tempList.RemoveAt(tempList.Count - 1);
			}
		}

		private static void ProcessFourthDigit(List<string> tempList, string actualStr, int i, List<string> list)
		{
			var str = actualStr.Substring(i, (actualStr.Length - i));
			int num;
			if (!int.TryParse(str, out num) || num > 255)
			{
				return;
			}
			// 0.DDDD is valid but not 00.ggg or 01.ddfd
			if (str.StartsWith("0") && str.Length > 1)
			{
				return;
			}
			tempList.Add(str);
			StringBuilder sb = new StringBuilder();
			for (var i1 = 0; i1 < tempList.Count; i1++)
			{
				if (i1 != 0)
				{
					sb.Append(".");
				}

				sb.Append(tempList[i1]);
			}
			list.Add(sb.ToString());
			tempList.RemoveAt(tempList.Count - 1);
		}
		public static List<string> restoreIpAddressesSol(string str) {
			if (str == null) return null;
			var validIps = new List<string>();
        
			for (var i = 1; i < 4 && i < str.Length; i++) {
				var first = str.Substring(0, i);
				if (valid(first)) {
					for (var j = 1; j + i < str.Length && j < 4; j++) {
						var second = str.Substring(i, j);
						if (valid(second)) {
							for (var k = 1; k + j + i < str.Length && k < 4; k++) {
								var third = str.Substring(j + i, k);
								var fourth = str.Substring(i + j + k);
								if (valid(third) && valid(fourth)) {
									validIps.Add(first + "." + second + "." + third + "." + fourth);
								}
							}
						}
					}
				}
			}
			return validIps;
		}
    
		private static bool valid(string str) {
			if (str.Length == 0 || str.Length > 3) return false;
			if (str[0] == '0' && str.Length > 1) return false;
			var value = int.Parse(str);
			return value >= 0 && value <= 255;
		}
	}
	
}